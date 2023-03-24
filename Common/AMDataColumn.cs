using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Common
{
    [Serializable]
    public class AMDataColumn
    {
        // Fields
        private string InternalColumnName;
        private string InternalTableName;

        // Methods
        public AMDataColumn(DataColumn dc)
        {
            this.InternalColumnName = dc.ColumnName;
            this.InternalTableName = dc.Table.TableName;
        }

        public AMDataColumn(string tableName, string columnName)
        {
            this.InternalColumnName = columnName;
            this.InternalTableName = tableName;
        }

        public static implicit operator AMDataColumn(DataColumn dc)
        {
            return new AMDataColumn(dc);
        }

        // Properties
        public string ColumnName
        {
            get
            {
                return this.InternalColumnName;
            }
        }

        public string TableName
        {
            get
            {
                return this.InternalTableName;
            }
        }
    }
}