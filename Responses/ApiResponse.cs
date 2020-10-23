using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Responses
{
    /// <summary>
    /// Class ApiResponse.
    /// Implements the <see>
    ///     <cref>MagazineStoreChallenge.Responses.ApiResponse</cref>
    /// </see>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso>
    ///     <cref>MagazineStoreChallenge.Responses.ApiResponse</cref>
    /// </seealso>
    public class ApiResponse<T> : IApiResponse<T>
    {
        /// <inheritdoc />
        public bool Success { get; set; }
        /// <inheritdoc />
        public string Token { get; set; }
        /// <inheritdoc />
        public string Message { get; set; }
        /// <inheritdoc />
        public T Data { get; set; }
    }
}