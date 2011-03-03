using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class ClaimRepository : EntityRepository<ClaimEntity>
    {
        public DataTable Search(ClaimSearchRequest request)
        {
            var qry = Context.Sql.Select("dbo.v_ClaimSearch")
                             .Top(request.Limit)
                             .OrderAsc("ClaimCode");

            if (!string.IsNullOrEmpty(request.ClaimCode)) qry.And("ClaimCode", Criteria.Like(request.ClaimCode));
            if (!string.IsNullOrEmpty(request.JobCardNumber)) qry.And("JobCardNumber", Criteria.Like(request.JobCardNumber));
            if (!string.IsNullOrEmpty(request.ExternalNumber)) qry.And("ExternalNumber", Criteria.Like(request.ExternalNumber));
            if (!string.IsNullOrEmpty(request.DealerName)) qry.And("DealerName", Criteria.Like(request.DealerName));
            if (!string.IsNullOrEmpty(request.VinNumber)) qry.And("VinNumber", Criteria.Like(request.VinNumber));
            if (!string.IsNullOrEmpty(request.ChassisNumber)) qry.And("ChassisNumber", Criteria.Like(request.ChassisNumber));

            return qry.Build().FillTable();
        }
    }
}