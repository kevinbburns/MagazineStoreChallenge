namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IApiResponse
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiResponse<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IApiResponse{T}"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        bool Success { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        string Token { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        T Data { get; set; }
    }
}