using MagazineStoreChallenge.Interfaces;

namespace MagazineStoreChallenge.Models
{
    /// <summary>
    /// Class Magazine.
    /// Implements the <see cref="MagazineStoreChallenge.Interfaces.IMagazine" />
    /// </summary>
    /// <seealso cref="MagazineStoreChallenge.Interfaces.IMagazine" />
    public class Magazine : IMagazine
    {
        /// <inheritdoc />
        public int Id { get; set; }
        /// <inheritdoc />
        public string Name { get; set; }
        /// <inheritdoc />
        public string Category { get; set; }
    }
}