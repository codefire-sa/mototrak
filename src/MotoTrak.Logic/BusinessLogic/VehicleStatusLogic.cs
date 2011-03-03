using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.BusinessLogic
{
    public class VehicleStatusLogic : BaseLogic
    {
        public VehicleStatusLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public List<VehicleStatusEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.VehicleStatuses.GetAll();
            }
        }
    }
}