using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class RejectionReasonRepository : EntityRepository<RejectionReasonEntity>
    {
        public RejectionReasonEntity GetByCode(string code)
        {
            return Context.FindOne<RejectionReasonEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<RejectionReasonEntity> GetAll()
        {
            return Context.Find<RejectionReasonEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "RejectionReasonCode";
            mgr.NameColumn = "RejectionReasonName";
            mgr.TableName = "dbo.RejectionReasons";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}