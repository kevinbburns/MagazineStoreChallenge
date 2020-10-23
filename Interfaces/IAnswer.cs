using System;
using System.Collections.Generic;

namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IAnswer
    /// </summary>
    public interface IAnswer
    {
        /// <summary>
        /// Gets or sets the subscribers.
        /// </summary>
        /// <value>The subscribers.</value>
        List<Guid> Subscribers { get; set; }
    }
}