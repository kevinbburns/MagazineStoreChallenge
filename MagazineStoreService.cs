using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MagazineStoreChallenge.Interfaces;
using MagazineStoreChallenge.Models;
using MagazineStoreChallenge.Requests;
using MagazineStoreChallenge.Responses;
using RestSharp;

namespace MagazineStoreChallenge
{
    /// <summary>
    /// Class MagazineStoreService. This class cannot be inherited.
    /// </summary>
    internal sealed class MagazineStoreService : IMagazineStoreService
    {
        private readonly RestClient _restClient;

        public string Token { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MagazineStoreService"/> class.
        /// </summary>
        /// <param name="baseWebApi">The base web API.</param>
        public MagazineStoreService(string baseWebApi)
        {
           ServicePointManager.DefaultConnectionLimit = 20;
            _restClient = new RestClient(baseWebApi);
        }

        /// <summary>
        /// Gets the token from the remote API, must call this before starting anything else.
        /// </summary>
        /// <exception cref="Exception">Unable to properly get token from endpoint.</exception>
        /// <exception cref="Exception">There was an issue in getting the token, check your status code and try again.</exception>
        public async Task GetToken()
        {
            var request  = new RestRequest("token",Method.GET);
            var response = await _restClient.ExecuteAsync<ApiToken>(request);
            if(response.StatusCode != HttpStatusCode.OK || response == null || !response.Data.Success)
                throw new Exception("There was an issue in getting the token, check your status code and try again.");

            Token        = response.Data.Token;
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;System.String&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        public async Task<List<string>> GetCategories()
        {
            var request  = new RestRequest($"categories/{Token}",Method.GET);
            var response = await _restClient.ExecuteAsync<ApiResponse<List<string>>>(request);
            if (response.StatusCode != HttpStatusCode.OK || response?.Data.Data == null)
                throw new Exception("Category : Token or Query is invalid.");

            return response.Data.Data;
        }

        /// <summary>
        /// Gets a list of magazine subscribers.
        /// </summary>
        /// <returns>Task&lt;List&lt;ISubscriber&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        public async Task<List<ISubscriber>> GetSubscribers()
        {
            var request  = new RestRequest($"subscribers/{Token}", Method.GET);
            var response = await _restClient.ExecuteAsync<ApiResponse<List<Subscriber>>>(request);
            if (response.StatusCode != HttpStatusCode.OK || response?.Data.Data == null)
                throw new Exception("Subscriber : Token or Query is invalid.");

            return response.Data.Data.Cast<ISubscriber>().ToList();
        }

        /// <summary>
        /// Gets a list of magazines based on the provided category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Task&lt;List&lt;IMagazine&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        public async Task<List<IMagazine>> GetMagazines(string category)
        {
            var request = new RestRequest($"magazines/{Token}/{category}", Method.GET);
            var response = await _restClient.ExecuteAsync<ApiResponse<List<Magazine>>>(request);
            if (response.StatusCode != HttpStatusCode.OK || response?.Data.Data == null)
                throw new Exception("Magazine : Token or Query is invalid.");

            return response.Data.Data.Cast<IMagazine>().ToList();
        }

        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="subscriberIds">The subscriber ids.</param>
        /// <returns>Task&lt;AnswerResponse&gt;.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<AnswerResponse> SubmitAnswer(List<Guid> subscriberIds)
        {
            var request     = new RestRequest($"answer/{Token}", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(new AnswerSubmitRequest
            {
                Subscribers = subscriberIds
            });

            var response    = await _restClient.ExecuteAsync<ApiResponse<AnswerResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK || response?.Data.Data == null)
                throw new Exception("Answer : Token or Query is invalid.");

            return response.Data.Data;
        }
    }
}
