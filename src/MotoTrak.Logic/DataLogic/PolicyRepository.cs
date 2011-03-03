using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class PolicyRepository : EntityRepository<PolicyEntity>
    {
        public List<PolicyEntity> GetByVehicle(int vehicleId)
        {
            return Context.Find<PolicyEntity>()
                          .Where(x => x.VehicleId == vehicleId && x.IsActive == true)
                          .List();
        }

        public PolicySummaryEntity GetSummary(int id)
        {
            return Context.GetById<PolicySummaryEntity>(id);
        }
    }
}