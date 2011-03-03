using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class CustomerConcernRepository : EntityRepository<CustomerConcernEntity>
    {
        public CustomerConcernEntity GetByCode(string code)
        {
            return Context.FindOne<CustomerConcernEntity>(x => x.Code == code && x.IsActive == true);
        }

        public List<CustomerConcernEntity> GetAll()
        {
            return Context.Find<CustomerConcernEntity>()
                          .Where(x => x.IsActive == true)
                          .List();
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            var mgr = new SearchManager(Context);
            mgr.IdColumn = "Id";
            mgr.CodeColumn = "CustomerConcernCode";
            mgr.NameColumn = "CustomerConcernName";
            mgr.TableName = "dbo.CustomerConcerns";
            mgr.ActiveOnly = true;

            return mgr.Execute(request);
        }
    }
}