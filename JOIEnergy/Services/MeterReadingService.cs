using System;
using System.Collections.Generic;
using JOIEnergy.Domain;

namespace JOIEnergy.Services
{
    public class MeterReadingService : IMeterReadingService
    {
        public Dictionary<string, List<ElectricityReading>> MeterAssociatedReadings { get; set; }
        public MeterReadingService(Dictionary<string, List<ElectricityReading>> meterAssociatedReadings)
        {
            MeterAssociatedReadings = meterAssociatedReadings;
        }

        public List<ElectricityReading> GetReadings(string smartMeterId) {
            if (MeterAssociatedReadings.ContainsKey(smartMeterId)) {
                return MeterAssociatedReadings[smartMeterId];
            }
            return new List<ElectricityReading>();
        }

        public void StoreReadings(string smartMeterId, List<ElectricityReading> electricityReadings) {
            if (!MeterAssociatedReadings.ContainsKey(smartMeterId)) {
                MeterAssociatedReadings.Add(smartMeterId, new List<ElectricityReading>());
            }

            electricityReadings.ForEach(electricityReading => MeterAssociatedReadings[smartMeterId].Add(electricityReading));
        }

        public List<ElectricityReading> GetLastWeekReading(string smartMeterId)
        {
            List<ElectricityReading> ResultList = new List<ElectricityReading>();
            if (MeterAssociatedReadings.ContainsKey(smartMeterId))
            {
                DateTime DTNow = System.DateTime.Now.AddDays(-1);
                DateTime DTLastWeek = System.DateTime.Now.AddDays(-8);
                foreach (ElectricityReading er in MeterAssociatedReadings[smartMeterId])
                {
                    if (er.Time > DTLastWeek && er.Time <= DTNow)
                    {
                        ResultList.Add(er);
                    }
                }
            }
            if (ResultList != null && ResultList.Count > 0)
            {
                return ResultList;
            }
            else
                return null;
        }

    }
}
