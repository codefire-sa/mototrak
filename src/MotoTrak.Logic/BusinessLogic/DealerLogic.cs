using System;
using System.Collections.Generic;
using System.Data;
using MotoTrak.Entities;
using Codefire.Extensions;

namespace MotoTrak.BusinessLogic
{
    public class DealerLogic : BaseLogic
    {
        public DealerLogic(SecurityTicket ticket)
            : base(ticket)
        {
        }

        public DealerEntity GetById(int id)
        {
            using (var db = CreateCatalog())
            {
                return db.Dealers.GetById(id);
            }
        }

        public DealerEntity GetByCode(string code)
        {
            using (var db = CreateCatalog())
            {
                return db.Dealers.GetByCode(code);
            }
        }

        public AjaxMessage GetAjax(string code)
        {
            using (var db = CreateCatalog())
            {
                var ajaxObj = new AjaxMessage();

                var dealerObj = db.Dealers.GetByCode(code);
                if (dealerObj == null)
                {
                    ajaxObj.ErrorMessage = "'{0}' does not exist.".FormatWith(code);
                }
                else
                {
                    ajaxObj.Id = dealerObj.Id;
                    ajaxObj.Code = dealerObj.Code;
                    ajaxObj.Name = dealerObj.Name;
                }

                return ajaxObj;
            }
        }

        public List<SearchEntity> Search(SearchRequest request)
        {
            using (var db = CreateCatalog())
            {
                return db.Dealers.Search(request);
            }
        }
    }
}