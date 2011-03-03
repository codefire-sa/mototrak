using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class VehicleServiceRepository : EntityRepository<VehicleServiceEntity>
    {
        public List<VehicleServiceEntity> GetByVehicle(int vehicleId)
        {
            return Context.Find<VehicleServiceEntity>()
                          .Where(x => x.VehicleId == vehicleId && x.IsActive == true)
                          .OrderAsc(x => x.ServiceDate)
                          .List();
        }
    }
}