using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _06_DemoHtmlHelpers.Models
{
    public class Salarie
    {
        [Required]
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [DataType(DataType.Password)]

        public string Password { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date d'entrée: ")]
        public DateTime DateEntree { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 10)]
        public int Evaluation { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Commentaire { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public string Photo { get; set; }
    }
}