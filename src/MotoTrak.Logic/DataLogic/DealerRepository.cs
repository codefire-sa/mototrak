using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class DealerRepository : EntityRepository<DealerEntity>
    {
        public DealerEntity GetByCode(string code)
        {
            return Context.FindOne<DealerEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "DealerCode";
            mgr.NameColumn = "DealerName";
            mgr.TableName = "dbo.Dealers";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}