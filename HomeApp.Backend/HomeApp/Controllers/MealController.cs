using HomeApp.ApiCore.Entities.Domain;
using HomeApp.ApiCore.Entities.DTO;
using HomeApp.ApiCore.Entities.Model;
using HomeApp.ApiCore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HomeApp.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[Authorize]
    public class MealController : ControllerBase
    {

        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMealService _mealService;

        public MealController(IHttpContextAccessor httpContextAccessor, IMealService mealService)
        {
            _httpContextAccessor = httpContextAccessor;
            _mealService = mealService;
        }

        public const string GetMealRouteName = "getmeal";

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MealDto))]
        [SwaggerOperation(
            summary: "Create meal",
            description: "Create new meal",
            OperationId = "CreateMeal",
            Tags = new[] { "Meal Management" }
        )]
        public async Task<IActionResult> CreateAsync(
            [Bind, FromBody] MealModel model,
            CancellationToken ct)
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email)!.Value;

            MealDto mealDto = await _mealService.CreateMealAsync(userEmail, model, ct);
            return CreatedAtRoute(
                GetMealRouteName,
                new { meal_id = mealDto.PublicId },
                mealDto
            );
        }

        [HttpGet("{meal_id}", Name = GetMealRouteName)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MealDto))]
        [SwaggerOperation(
            summary: "Get meal",
            description: "Get meal by ID.",
            OperationId = "GetMeal",
            Tags = new[] { "Meal Management" }
        )]
        public async Task<IActionResult> GetAsync(
            [Required, FromRoute(Name = "meal_id")] Guid? mealId,
            CancellationToken ct)
        {

            MealDto mealDto = await _mealService.GetMealAsync(mealId.Value, ct);
            return Ok(mealDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MealDto))]
        [SwaggerOperation(
            summary: "Get meals",
            description: "Get all meals",
            OperationId = "GetMeals",
            Tags = new[] { "Meal Management" }
        )]
        public async Task<IActionResult> GetAllAsync(
            [FromQuery] MealListModel model,
            CancellationToken ct)
        {

            List<MealDto> mealDto = await _mealService.GetListOfMealAsync(model, ct);
            return Ok(mealDto);
        }

        [HttpPut("{meal_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MealDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            summary: "Update meal",
            description: "Update new meal",
            OperationId = "UpdateMeal",
            Tags = new[] { "Meal Management" }
        )]
        public async Task<IActionResult> UpdateAsync(
            [Bind, FromBody] MealModel model,
            [Required, FromRoute(Name = "meal_id")] Guid? mealId,
            CancellationToken ct)
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email)!.Value;

            MealDto mealDto = await _mealService.UpdateMealAsync(userEmail, mealId.Value, model, ct);
            return Ok(mealDto);
        }

        [HttpDelete("{meal_id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MealDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            summary: "Delete meal",
            description: "Delete new meal",
            OperationId = "DeleteMeal",
            Tags = new[] { "Meal Management" }
        )]
        public async Task<IActionResult> DeleteAsync(
            [Required, FromRoute(Name = "meal_id")] Guid? mealId,
            CancellationToken ct)
        {
            var httpContext = _httpContextAccessor.HttpContext!;
            var userEmail = httpContext.User.FindFirst(ClaimTypes.Email)!.Value;

            await _mealService.DeleteMealAsync(userEmail, mealId.Value, ct);
            return NoContent();
        }

    }
}
