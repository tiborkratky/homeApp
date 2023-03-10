using System.ComponentModel.DataAnnotations;

namespace HomeApp.ApiCore.Entities.Model
{
    public class MealListModel
    {
        [Required]
        public int pageSize { get; set; } = 10;
        public int page { get; set; } = 1;
    }
}
