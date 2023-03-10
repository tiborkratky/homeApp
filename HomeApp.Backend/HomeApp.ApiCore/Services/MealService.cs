using HomeApp.ApiCore.Database;
using HomeApp.ApiCore.Entities.Domain;
using HomeApp.ApiCore.Entities.DTO;
using HomeApp.ApiCore.Entities.Model;
using HomeApp.ApiCore.Exceptions;
using HomeApp.ApiCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeApp.ApiCore.Services
{
    public class MealService : IMealService
    {
        private ApplicationContext _context;
        public MealService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<MealDto> CreateMealAsync(string useremail, MealModel model, CancellationToken ct = default)
        {
            User userData = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserEmail == useremail, ct);

            Meal meal = model.ToDomain();
            meal.PublicId = Guid.NewGuid();
            meal.UserId = userData.Id;

            await _context.AddAsync(meal, ct);
            await _context.SaveChangesAsync(ct);

            return meal.ToDto();
        }

        public async Task DeleteMealAsync(string useremail, Guid mealId, CancellationToken ct = default)
        {
            User userDate = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserEmail == useremail, ct);
            if(userDate == null)
            {
                throw new NotPermissions();
            }

            var meal = await _context.Meals.AsNoTracking().SingleOrDefaultAsync(x => x.PublicId == mealId, ct);
            if(meal == null)
            {
                throw new NotFoundException($"Meal with ID {mealId} not exists.");
            }

            _context.Remove(meal);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<List<MealDto>> GetListOfMealAsync(MealListModel model, CancellationToken ct = default)
        {
            IQueryable<Meal> query = _context.Meals
                .AsNoTracking()
                .AsQueryable().Skip(model.pageSize * model.page - model.pageSize).Take(model.pageSize);

            List<Meal> meals = await query.ToListAsync();
            List<MealDto> dtos = meals.Select(x => x.ToDto()).ToList();

            return dtos;
        }

        public async Task<MealDto> GetMealAsync(Guid mealId, CancellationToken ct = default)
        {
            var mealDto = await _context.Meals.AsNoTracking().SingleOrDefaultAsync(x => x.PublicId == mealId, ct);
            if(mealDto == null)
            {
                throw new NotFoundException($"Meal with ID {mealId} doesn't exist.");
            }

            return mealDto.ToDto();
        }

        public async Task<MealDto> UpdateMealAsync(string useremail, Guid mealId, MealModel model, CancellationToken ct = default)
        {
            User userDate = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserEmail == useremail, ct);
            if (userDate == null)
            {
                throw new NotPermissions();
            }

            var meal = await _context.Meals.AsNoTracking().SingleOrDefaultAsync(x => x.PublicId == mealId, ct);
            if (meal == null)
            {
                throw new NotFoundException("Meal with ID {mealId} doesn't exist.");
            }

            meal.Name = model.Name;
            meal.Description = model.Description;
            meal.Lunch = model.Lunch;
            meal.Receipe = model.Receipe;
            meal.TypeOfDay = model.TypeOfDay;
            meal.UpdatedDate = DateTime.UtcNow;

            _context.Meals.Update(meal);
            await _context.SaveChangesAsync(ct);

            return meal.ToDto();
        }
    }
}
