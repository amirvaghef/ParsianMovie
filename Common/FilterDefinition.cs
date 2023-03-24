using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public class FilterDefinition
    {
        // Fields
        public AMDataColumn Column;
        public FilterOperation Operation;
        public object Value;

        // Methods
        public FilterDefinition(AMDataColumn column, FilterOperation operation, object val)
        {
            this.Column = column;
            this.Operation = operation;
            this.Value = val;
        }
    }
}