using System.ComponentModel.DataAnnotations;
using HomeApp.ApiCore.Entities.Domain;

namespace HomeApp.ApiCore.Entities.Model
{
    public class MealModel
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(120)]
        public string Description { get; set; }
        [Required]
        public string Receipe { get; set; }
        [Required]
        public TypeOfDay TypeOfDay { get; set; }
        public Lunch? Lunch { get; set; }

        public Meal ToDomain()
        {
            return new Meal
            {
                Name = Name,
                Description = Description,
                Receipe = Receipe,
                TypeOfDay = TypeOfDay,
                Lunch = Lunch
            };
        }
    }
}
