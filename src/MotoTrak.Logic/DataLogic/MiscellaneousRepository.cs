using System;
using System.Collections.Generic;
using MotoTrak.Entities;

namespace MotoTrak.DataLogic
{
    public class MiscellaneousRepository : EntityRepository<MiscellaneousEntity>
    {
        public MiscellaneousEntity GetByCode(string code)
        {
            return Context.FindOne<MiscellaneousEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "MiscellaneousCode";
            mgr.NameColumn = "MiscellaneousName";
            mgr.TableName = "dbo.Miscellaneous";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}