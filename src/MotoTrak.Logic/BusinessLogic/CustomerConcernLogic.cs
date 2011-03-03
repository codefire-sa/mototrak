using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class CustomerConcernLogic : BaseLogic
    {
        public CustomerConcernLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public CustomerConcernEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.CustomerConcerns.GetById(id);
            }
        }

        public CustomerConcernEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.CustomerConcerns.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var concernObj = db.CustomerConcerns.GetByCode(code);
                if (concernObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = concernObj.Id;
                    ajaxObj.Code = concernObj.Code;
                    ajaxObj.Name = concernObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<CustomerConcernEntity> GetAll()
        {
            using (var db = CreateCatalog())
            {
                return db.CustomerConcerns.GetAll();
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.CustomerConcerns.Search(request);
            }
        }
    }
}