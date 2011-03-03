using System;
using System.Data;
using Codefire.Storm;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class ClaimQueueRepository : BaseRepository
    {
        public DataTable GetByUser(int userId)
        {
            var qry = Context.Sql.Select("dbo.v_ClaimQueues")
                                 .Where("UserId", Criteria.IsEqualTo(userId))
                                 .OrderDesc("QueueDate");

            return qry.Build().FillTable();
        }

        public void Add(int claimId, int userId)
        {
        }

        public void Remove(int claimId)
        {
        }
    }
}