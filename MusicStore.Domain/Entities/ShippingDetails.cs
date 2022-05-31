using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Entities
{
    public class ShippingDetails

    {
        public int ShippingDetailsId { get; set; }

        [Required(ErrorMessage = "Укажите как вас зовут")]
        [Display(Name = "Фамилия Имя Отчество")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите ваш номер")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Некоректный email")]
        [RegularExpression(@"([a-zA-z])(.+)([a-zA-z])@((g)?mail|yahoo|rambler|yandex|ya)[\.](ru|com)$", ErrorMessage = "Некоректный email")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вставьте адрес доставки")]
        [Display(Name = "Адрес")]
        public string Line1 { get; set; }
       
        [Required(ErrorMessage = "Укажите город")]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        [Display(Name = "Страна")]
        public string Country { get; set; }


        [Display(Name = "Инструменты:")]
        public List<Instrument> instruments { get; set; }

        public ShippingDetails()
        {
            instruments = new List<Instrument>();
        }

    }
}
