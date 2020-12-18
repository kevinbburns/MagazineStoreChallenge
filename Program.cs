using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagazineStoreChallenge.Interfaces;
using NLog;

namespace MagazineStoreChallenge
{
    internal class Program
    {
        private static readonly List<IAnswerResponse> SubmitAnswerResponses = new List<IAnswerResponse>();

        public static void Main(string[] args)
        {
            try
            {
                const string menuOpt                       = "Enter in a number for times to execute the request[1-20] or [E] to exit:";
                var baseWebApi                             = Properties.Settings.Default.BaseWebApi;
                if (string.IsNullOrEmpty(baseWebApi))
                    throw new Exception("Must configure WebAPI address in config file.");

                Console.WriteLine(menuOpt);

                int numThreads;

                while (true)
                {
                    var res = Console.ReadLine();

                    if (string.IsNullOrEmpty(res))
                    {
                        Console.Clear();
                        Console.WriteLine(menuOpt);
                    }
                    else
                    {
                        if (res.ToLower() == "e")
                        {
                            return;
                        }

                        var intParseRes = int.TryParse(res, out numThreads);
                        if (!intParseRes || numThreads <= 0 || numThreads > 20)
                        {
                            Console.Clear();
                            Console.WriteLine(menuOpt);
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                for (var i = 0; i < numThreads; i++)
                    RunWebThread().Wait();

                Console.WriteLine($"Fastest Time To Complete: {GetFastest()}");
                Console.WriteLine($"Slowest Time To Complete: {GetSlowest()}");
                Console.WriteLine($"Average Time To Complete: {GetAvg()}");
                Console.WriteLine(
                    $"Number of attempts successful: {SubmitAnswerResponses.Count(x => x.AnswerCorrect)}");
                Console.WriteLine(
                    $"Number of attempts unsuccessful: {SubmitAnswerResponses.Count(x => !x.AnswerCorrect)}");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Press [any] key to exit.");

                Console.ReadLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine("There was a system failure; please review the logs in the Logs folder.");
                var logger = LogManager.GetLogger("fileLogger");
                logger.Error(exp.Message);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// This function will create a separate thread, and run the items from the service layer.
        /// At the service layer, we are consuming the data from the remote web api and grabbing the data.
        /// The task will aggregate the data, and run the results in parallel to determine which magazine
        /// belongs to which client.
        /// </summary>
        /// <exception cref="Exception">Unable to process data, check return from end-points.</exception>
        private static async Task RunWebThread()
        {
            var serviceLayer         = new MagazineStoreService(Properties.Settings.Default.BaseWebApi);
            await serviceLayer.GetToken();

            var categoriesTask       = serviceLayer.GetCategories();
            var subscribersTask      = serviceLayer.GetSubscribers();

            Task.WaitAll(categoriesTask, subscribersTask);

            var categories           = categoriesTask.Result;
            var subscribers          = subscribersTask.Result;
            var magazines            = new ConcurrentBag<IMagazine>();

            var magazineTasks        = new List<Task>(categories.Select(async c =>
             {
                 var mags                    = await serviceLayer.GetMagazines(c);
                 foreach (var m in mags)
                     magazines.Add(m);
             }));

            Task.WaitAll(magazineTasks.ToArray());

            if (!categories.Any() || !subscribers.Any() || !magazines.Any())
                throw new Exception("Unable to process data, check return from end-points.");

            var mvpSubscriber        = new ConcurrentBag<ISubscriber>();

            Parallel.ForEach(subscribers, subscriber =>
            {
                var subMags          = new List<IMagazine>();
                foreach (var sMag in subscriber.MagazineIds)
                    subMags.Add(magazines.FirstOrDefault(x => x.Id.Equals(sMag)));

                var subMagCategories = subMags.Select(x => x.Category).Distinct().ToArray();

                var isMvp            = true;

                foreach (var category in categories)
                {
                    if (subMagCategories.Contains(category))
                        continue;

                    isMvp            = false;
                    break;
                }

                if (isMvp)
                    mvpSubscriber.Add(subscriber);
            });

            var answerResponse       = await serviceLayer.SubmitAnswer(mvpSubscriber.Select(x => x.Id).ToList());
            if (answerResponse == null)
                return;

            SubmitAnswerResponses.Add(answerResponse);
        }

        /// <summary>
        /// Gets the fastest running web api task from the list.
        /// </summary>
        /// <returns>TimeSpan.</returns>
        private static TimeSpan GetFastest()
        {
            return SubmitAnswerResponses.Where(x => x.TotalTime != null).OrderBy(x => x.TotalTime).Select(x => x.TotalTime.Value)
                  .First();
        }

        /// <summary>
        /// Gets the slowest running web api task from the list.
        /// </summary>
        /// <returns>TimeSpan.</returns>
        private static TimeSpan GetSlowest()
        {
            return SubmitAnswerResponses.Where(x => x.TotalTime != null).OrderByDescending(x => x.TotalTime).Select(x => x.TotalTime.Value)
                .First();
        }

        /// <summary>
        /// Gets the average of all the running API tasks from the list.
        /// </summary>
        /// <returns>TimeSpan.</returns>
        private static TimeSpan GetAvg()
        {
            var doubleAverageTicks = SubmitAnswerResponses.Where(x => x.TotalTime != null).Select(x => x.TotalTime.Value).Average(timeSpan => timeSpan.Ticks);
            var longAverageTicks   = Convert.ToInt64(doubleAverageTicks);

            return new TimeSpan(longAverageTicks);
        }
    }
}
