using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp_mvc_2.Models.ViewModel
{
    public class MenuView
    {
        [Key]
        public int id_menu { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "menu")]
        public string menu { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "stock")]
        public int? stock { get; set; }
        [Display(Name = "Harga")]
        public int? harga { get; set; }
    }
    public class MenuDataView
    {
        public IEnumerable<MenuView> MenuProfile { get; set; }
    }
}