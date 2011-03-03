using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class PartRepository : EntityRepository<PartEntity>
    {
        public PartEntity GetByCode(string code)
        {
            return Context.FindOne<PartEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "PartCode";
            mgr.NameColumn = "PartName";
            mgr.TableName = "dbo.Parts";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}