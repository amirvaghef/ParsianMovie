using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common
{
    public interface IFilterTranslator
    {
        // Methods
        void AddTableToJoin(string tblName);
        string GetFromClause(DataRelationCollection drc);
        string GetOrderByClause(string tableAlias, params AMDataColumn[] cols);
        string GetTable(int idx);
        string GetTableAlias(string tblName);
        int GetTableCount();
        string GetWhereClause();
    }
}
