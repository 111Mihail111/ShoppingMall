namespace ShoppingMall.Store.Models
{
    /// <summary>
    /// Город
    /// </summary>
    public class City
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор региона
        /// </summary>
        public int RegionId { get; set; }

        /// <summary>
        /// Наименование города
        /// </summary>
        public string Name { get; set; }
    }
}
