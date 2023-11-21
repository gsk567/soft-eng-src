using System.Threading.Tasks;
using FastFoooder.Business.FoodStrategies.Pizza;
using FastFoooder.Business.Models;
using FastFoooder.Business.Services;
using FastFoooder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FastFoooder.Application.Controllers;

[Route("/foods/")]
[ApiController]
public class FoodController : ControllerBase
{
    private readonly FoodService foodService;

    public FoodController(FoodService foodService)
    {
        this.foodService = foodService;
    }

    [HttpGet("")]
    public async Task<IActionResult> FetchFoods()
    {
        return Ok(await this.foodService.FetchFoodsAsync());
    }

    [HttpPost("pizza")]
    public async Task<IActionResult> Create(PizzaMutationModel pizza) =>
        Ok(await this.foodService.CreateFoodAsync<Pizza>(pizza));
    
    [HttpPost("burger")]
    public async Task<IActionResult> Create(BurgerModel burger) =>
        Ok(await this.foodService.CreateFoodAsync<Burger>(burger));
}