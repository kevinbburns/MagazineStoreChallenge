using System;
using System.Collections.Generic;
using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Responses
{
    /// <summary>
    /// Class AnswerResponse.
    /// Implements the <see cref="MagazineStoreChallenge.Interfaces.IAnswerResponse" />
    /// </summary>
    /// <seealso cref="MagazineStoreChallenge.Interfaces.IAnswerResponse" />
    public class AnswerResponse : IAnswerResponse
    {
        private List<Guid> _shouldBe;

        /// <inheritdoc />
        public TimeSpan? TotalTime { get; set; }
        /// <inheritdoc />
        public bool AnswerCorrect { get; set; }

        /// <inheritdoc />
        public List<Guid> ShouldBe
        {
            get { return _shouldBe ?? (ShouldBe = new List<Guid>()); }
            set { _shouldBe = value; }
        }
    }
}