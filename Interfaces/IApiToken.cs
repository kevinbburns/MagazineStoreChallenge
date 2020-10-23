namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IApiToken
    /// </summary>
    public interface IApiToken
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IApiToken"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        bool Success { get; set; }
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        string Token { get; set; }
    }
}