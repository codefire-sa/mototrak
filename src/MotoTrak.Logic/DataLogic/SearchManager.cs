using System;
using System.Collections.Generic;
using Codefire.Storm;
using MotoTrak.Entities;
using Codefire.Extensions;
using Codefire.Utilities;
using Codefire.Storm.Querying;

namespace MotoTrak.DataLogic
{
    public class SearchManager
    {
        private IDataContext _context;
        private string _tableName = "";
        private string _idColumn = "";
        private string _codeColumn = "";
        private string _nameColumn = "";
        private bool _activeOnly;
        private int _siteId;

        public SearchManager(IDataContext context)
        {
            _context = context;
        }

        public IDataContext Context
        {
            get { return _context; }
        }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string IdColumn
        {
            get { return _idColumn; }
            set { _idColumn = value; }
        }

        public string CodeColumn
        {
            get { return _codeColumn; }
            set { _codeColumn = value; }
        }

        public string NameColumn
        {
            get { return _nameColumn; }
            set { _nameColumn = value; }
        }

        public bool ActiveOnly
        {
            get { return _activeOnly; }
            set { _activeOnly = value; }
        }

        public int SiteId
        {
            get { return _siteId; }
            set { _siteId = value; }
        }

        public List<SearchEntity> Execute(SearchRequest request)
        {
            var columnList = StringUtility.BuildList(",", _idColumn, _codeColumn, _nameColumn);
            var qry = Context.Sql.Select(_tableName)
                                 .Columns(columnList)
                                 .Top(request.Limit);

            if (!string.IsNullOrEmpty(request.Code))
            {
                qry.Where(_codeColumn, Criteria.Like(request.Code));
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                qry.Where(_nameColumn, Criteria.Like(request.Name));
            }

            if (_activeOnly)
            {
                qry.Where("IsActive", Criteria.IsEqualTo(true));
            }

            if (_siteId > 0)
            {
                qry.Where("SiteId", Criteria.IsEqualTo(_siteId));
            }

            if (!string.IsNullOrEmpty(request.OrderColumn))
            {
                qry.OrderAsc(request.OrderColumn);
            }

            var list = new List<SearchEntity>();
            using (var reader = qry.Build().ExecuteReader())
            {
                while (reader.Read())
                {
                    var obj = new SearchEntity();
                    obj.Id = reader.Get<int>(_idColumn);
                    obj.Code = reader.Get<string>(_codeColumn, "");
                    obj.Name = reader.Get<string>(_nameColumn, "");

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}