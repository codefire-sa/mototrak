using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class VehicleNoteRepository : EntityRepository<VehicleNoteEntity>
    {
        public List<VehicleNoteEntity> GetByVehicle(int vehicleId)
        {
            return Context.Find<VehicleNoteEntity>()
                             .Top(1000)
                             .Where(x => x.VehicleId == vehicleId && x.IsActive == true)
                             .OrderAsc(x => x.ClaimId)
                             .OrderAsc(x => x.CreateDate)
                             .List();
        }

        public List<VehicleNoteEntity> GetByClaim(int claimId)
        {
            return Context.Find<VehicleNoteEntity>()
                             .Top(1000)
                             .Where(x => x.ClaimId == claimId && x.IsActive == true)
                             .OrderAsc(x => x.ClaimId)
                             .OrderAsc(x => x.CreateDate)
                             .List();
        }
    }
}
