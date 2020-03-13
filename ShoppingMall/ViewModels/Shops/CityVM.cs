using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.ViewModels.Shops
{
    /// <summary>
    /// Город VM
    /// </summary>
    public class CityVM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "- Вы не выбрали город!")]
        /// <summary>
        /// Наименование города
        /// </summary>
        public string Name { get; set; }
    }
}