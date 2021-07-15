using System.ComponentModel.DataAnnotations;

namespace Technobel_Student.DAL.Models.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Ce champ est requis")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères")]
        [MaxLength(15, ErrorMessage = "La longueur maximale est de 15 caractères")]
        public string Nom { get; set; }
        [Required(ErrorMessage = "Ce champ est requis")]
        [MinLength(2, ErrorMessage = "La longueur minimale est de 2 caractères")]
        [MaxLength(15, ErrorMessage = "La longueur maximale est de 15 caractères")]
        public string Prenom { get; set; }
        public string Numero { get; set; }
    }
}
