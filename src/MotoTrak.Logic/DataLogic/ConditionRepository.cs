using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class ConditionRepository : EntityRepository<ConditionEntity>
    {
        public ConditionEntity GetByCode(string code)
        {
            return Context.FindOne<ConditionEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<ConditionEntity> GetAll()
        {
            return Context.Find<ConditionEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "ConditionCode";
            mgr.NameColumn = "ConditionName";
            mgr.TableName = "dbo.Conditions";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}