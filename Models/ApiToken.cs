using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Models
{
    public class ApiToken : IApiToken
    {
        /// <inheritdoc />
        public bool Success { get; set; }
        /// <inheritdoc />
        public string Token { get; set; }
    }
}