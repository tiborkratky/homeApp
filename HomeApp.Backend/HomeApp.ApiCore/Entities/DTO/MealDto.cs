using HomeApp.ApiCore.Entities.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeApp.ApiCore.Entities.DTO
{
    public class MealDto
    {
        public string Name { get; set; }
        public Guid? PublicId { get; set; }
        public string Description { get; set; }
        public string Receipe { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; } = null;
        public TypeOfDay TypeOfDay { get; set; }
        public Lunch? Lunch { get; set; }
    }
}
