using System;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class VehicleRepository : EntityRepository<VehicleEntity>
    {
        public DataTable Search(VehicleSearchRequest request)
        {
            var sql = Context.Sql.Select("dbo.v_VehicleSearch")
                             .Top(request.Limit)
                             .OrderAsc("ChassisNumber");

            if (!string.IsNullOrEmpty(request.VinNumber)) sql.And("VinNumber", Criteria.Like(request.VinNumber));
            if (!string.IsNullOrEmpty(request.ChassisNumber)) sql.And("ChassisNumber", Criteria.Like(request.ChassisNumber));
            if (!string.IsNullOrEmpty(request.EngineNumber)) sql.And("EngineNumber", Criteria.Like(request.EngineNumber));
            if (!string.IsNullOrEmpty(request.RegistrationNumber)) sql.And("RegistrationNumber", Criteria.Like(request.RegistrationNumber));
            if (!string.IsNullOrEmpty(request.Initials)) sql.And("Initials", Criteria.Like(request.Initials));
            if (!string.IsNullOrEmpty(request.LastName)) sql.And("LastName", Criteria.Like(request.LastName));

            return sql.Build().FillTable("Results");
        }
    }
}