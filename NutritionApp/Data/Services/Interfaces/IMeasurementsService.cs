﻿using Nutrition.Core;
using NutritionApp.Components;

namespace NutritionApp.Data.Services;

public interface IMeasurementsService

{
    public BodyMeasurements GetBodyMeasurements();

    public TargetMeasurements GetTargetMeasurements();

    public Task AddNewWeight(double weight);
}