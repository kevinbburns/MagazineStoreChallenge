using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MagazineStoreChallenge.Interfaces;
using MagazineStoreChallenge.Responses;

namespace MagazineStoreChallenge
{
    internal interface IMagazineStoreService
    {
        string Token { get; }

        /// <summary>
        /// Gets the token from the remote API, must call this before starting anything else.
        /// </summary>
        /// <exception cref="Exception">Unable to properly get token from endpoint.</exception>
        /// <exception cref="Exception">There was an issue in getting the token, check your status code and try again.</exception>
        Task GetToken();

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>Task&lt;ICollection&lt;System.String&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        Task<List<string>> GetCategories();

        /// <summary>
        /// Gets a list of magazine subscribers.
        /// </summary>
        /// <returns>Task&lt;List&lt;ISubscriber&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        Task<List<ISubscriber>> GetSubscribers();

        /// <summary>
        /// Gets a list of magazines based on the provided category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Task&lt;List&lt;IMagazine&gt;&gt;.</returns>
        /// <exception cref="Exception">Token or Query is invalid.</exception>
        Task<List<IMagazine>> GetMagazines(string category);

        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="subscriberIds">The subscriber ids.</param>
        /// <returns>Task&lt;AnswerResponse&gt;.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        Task<AnswerResponse> SubmitAnswer(List<Guid> subscriberIds);
    }
}