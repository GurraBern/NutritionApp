﻿using NutritionTrackR.Core.Foods.ValueObjects;
using NutritionTrackR.Core.Shared;
using NutritionTrackR.Core.Shared.Abstractions;

namespace NutritionTrackR.Core.Foods;

public class Food : Entity
{
    public string Name { get; set;  }
    public List<Nutrient> Nutrients { get; set; } = [];

    private Food() { }
    
    private Food(string name, List<Nutrient> nutrients)
    {
        Name = name;
        Nutrients = nutrients;
    }

    public static Result<Food> Create(string name, List<Nutrient> nutrients)
    {
        var food = new Food(name, nutrients);

        return Result.Success(food);
    }
}