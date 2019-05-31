using System.ComponentModel.DataAnnotations;

namespace Recommender_system.Models
{
    public enum TypeOfSubject
    {
        [Display(Name = "Математика")]
        Math,
        [Display(Name = "Русский язык")]
        RussianLanguage,
        [Display(Name = "Информатика")]
        Information,
        [Display(Name = "Физика")]
        Physics,
        [Display(Name = "Химия")]
        Chemistry
    }
}