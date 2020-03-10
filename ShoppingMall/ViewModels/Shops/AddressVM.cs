using System.ComponentModel.DataAnnotations;

namespace ShoppingMall.ViewModels.Shops
{
    /// <summary>
    /// Адрес VM
    /// </summary>
    public class AddressVM
    {
        /// <summary>
        /// Идентификатор адрес
        /// </summary>
        public int AddressId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "- Поле адреса не может быть пустым!")]
        [RegularExpression("[^ ].{4,30}", ErrorMessage = "- Неверный адрес. Минимальная длинна символов 4, максимальная - 30!")]
        /// <summary>
        /// Наименование адреса
        /// </summary>
        public string AddressName { get; set; }
    }
}