using System;
using System.Collections.Generic;
using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Models
{
    public class Answer : IAnswer
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