using HomeApp.ApiCore.Entities.DTO;
using HomeApp.ApiCore.Entities.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeApp.ApiCore.Services.Interfaces
{
    public interface IMealService
    {
        Task<MealDto> CreateMealAsync(string useremail, MealModel model, CancellationToken ct = default);
        Task<MealDto> GetMealAsync(Guid mealId, CancellationToken ct = default);
        Task<List<MealDto>> GetListOfMealAsync(MealListModel model, CancellationToken ct = default);
        Task<MealDto> UpdateMealAsync(string useremail, Guid mealId, MealModel model, CancellationToken ct = default);
        Task DeleteMealAsync(string useremail, Guid mealId, CancellationToken ct = default);
    }
}
