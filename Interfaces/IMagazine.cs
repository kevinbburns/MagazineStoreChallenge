namespace MagazineStoreChallenge.Interfaces
{
    /// <summary>
    /// Interface IMagazine
    /// </summary>
    public interface IMagazine
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        string Category { get; set; }
    }
}