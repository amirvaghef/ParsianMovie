using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ColumnTranslator
    {
        // Fields
        public AMDataColumn Column;
        public string DisplayName;

        // Methods
        public ColumnTranslator(AMDataColumn col, string dispName)
        {
            this.Column = col;
            this.DisplayName = dispName;
        }

        public override bool Equals(object o)
        {
            return o.ToString().Equals(this.ToString());
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}