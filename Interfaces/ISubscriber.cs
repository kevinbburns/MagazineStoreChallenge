using System;
using System.Collections.Generic;

namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IApiSubscriber
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        string LastName { get; set; }
        /// <summary>
        /// Gets or sets the magazine ids.
        /// </summary>
        /// <value>The magazine ids.</value>
        List<int> MagazineIds { get; set; }
    }
}