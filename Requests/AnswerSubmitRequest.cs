using System;
using System.Collections.Generic;
using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Requests
{
    /// <summary>
    /// Class AnswerSubmitRequest.
    /// Implements the <see>
    ///     <cref>MagazineStoreChallenge.Requests.IAnswerSubmitRequest</cref>
    /// </see>
    /// </summary>
    /// <seealso>
    ///     <cref>MagazineStoreChallenge.Requests.IAnswerSubmitRequest</cref>
    /// </seealso>
    public class AnswerSubmitRequest : IAnswerSubmitRequest
    {
        private List<Guid> _subscribers;

        /// <inheritdoc />
        public List<Guid> Subscribers
        {
            get { return _subscribers ?? (Subscribers = new List<Guid>()); }
            set { _subscribers = value; }
        }
    }
}