using System;
using System.Collections.Generic;

namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IAnswerResponse
    /// </summary>
    public interface IAnswerResponse
    {
        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        /// <value>The total time.</value>
        TimeSpan? TotalTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [answer correct].
        /// </summary>
        /// <value><c>true</c> if [answer correct]; otherwise, <c>false</c>.</value>
        bool AnswerCorrect { get; set; }
        /// <summary>
        /// Gets or sets the should be.
        /// </summary>
        /// <value>The should be.</value>
        List<Guid> ShouldBe { get; set; }
    }
}