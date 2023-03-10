using HomeApp.ApiCore.Entities.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeApp.ApiCore.Entities.Domain
{
    public class Meal
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Guid? PublicId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(120)]
        public string Description { get; set; }
        [Required]
        public string Receipe { get; set; }
        [Required]
        public TypeOfDay TypeOfDay { get; set; }
        public Lunch? Lunch { get; set; }
        [Required]
        public DateTime CreatedDate { get; set;} = DateTime.UtcNow;

        public DateTime UpdatedDate { get; set;}
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public MealDto ToDto()
        {
            return new MealDto
            {
                Name = Name,
                PublicId = PublicId.Value,
                Description = Description,
                Receipe = Receipe,
                TypeOfDay = TypeOfDay,
                Lunch = Lunch,
                CreatedDate = CreatedDate,
                UpdatedDate = UpdatedDate
            };
        }
    }

    public enum TypeOfDay
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2,
    }

    public enum Lunch
    {
        Appetizer = 0,
        MainMeal = 1,
        Desert = 2,
    }
}
