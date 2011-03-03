using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class VehicleStatusRepository : EntityRepository<VehicleStatusEntity>
    {
        public VehicleStatusEntity GetByCode(string code)
        {
            return Context.FindOne<VehicleStatusEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<VehicleStatusEntity> GetAll()
        {
            return Context.Find<VehicleStatusEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }
    }
}