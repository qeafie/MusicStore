using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class Instrument
    {
        public int InstrumentId { get; set; }

        [Required(ErrorMessage = "Укажите название")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Укажите категорию")]
        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Display(Name = "Цена")]
        [Range(0, double.MaxValue , ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Укажите Количество")]
        [Display(Name = "Количество")]
        [Range(0, int.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для количества")]
        public int Quantity { get; set; }

        [Display(Name = "Товар удалён?")]
        public bool IsDeleted { get; set; } = false;


        public List<ShippingDetails> ShippingDetails { get; set; } 

        public Instrument()
        {
            ShippingDetails = new List<ShippingDetails>();
        }
    }
}
