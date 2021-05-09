﻿using System.Collections.Generic;

namespace JOIEnergy.Services
{
    public interface IPricePlanService
    {
        Dictionary<string, decimal> GetConsumptionCostOfElectricityReadingsForEachPricePlan(string smartMeterId);

        Dictionary<string, decimal> GetPeriodConsumptionCostOfElectricityReadingsForEachPricePlan(string smartMeterId);
    }
}