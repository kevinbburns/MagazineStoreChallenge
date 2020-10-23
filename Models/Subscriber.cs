using System;
using System.Collections.Generic;
using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Models
{
    /// <summary>
    /// Class ApiSubscriber.
    /// Implements the <see cref="ISubscriber" />
    /// </summary>
    /// <seealso cref="ISubscriber" />
    public class Subscriber : ISubscriber
    {
        private List<int> _magazineIds;

        /// <inheritdoc />
        public Guid Id { get; set; }
        /// <inheritdoc />
        public string FirstName { get; set; }
        /// <inheritdoc />
        public string LastName { get; set; }
        /// <inheritdoc />
        public List<int> MagazineIds
        {
            get { return _magazineIds ?? (MagazineIds = new List<int>()); }
            set { _magazineIds = value; }
        }
    }
}