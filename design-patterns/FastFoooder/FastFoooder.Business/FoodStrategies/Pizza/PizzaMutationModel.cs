using System.Text.Json.Serialization;
using FastFoooder.Business.Models;

namespace FastFoooder.Business.FoodStrategies.Pizza;

public class PizzaMutationModel : PizzaModel
{
    [JsonIgnore]
    public override int Id { get; set; }

    [JsonIgnore]
    public override decimal Price { get; set; }
}