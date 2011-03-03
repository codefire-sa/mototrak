using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class ModelRepository : EntityRepository<ModelEntity>
    {
        public ModelEntity GetByCode(string code)
        {
            return Context.FindOne<ModelEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "ModelCode";
            mgr.NameColumn = "ModelName";
            mgr.TableName = "dbo.Models";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}