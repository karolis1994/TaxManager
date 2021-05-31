namespace TaxManager.Domain.Core
{
    /// <summary>
    /// Abstract database entity class
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public long Id { get; set; }
    }
}
