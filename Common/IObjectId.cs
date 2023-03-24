using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IObjectId
    {
        // Methods
        object GetValue();
        object GetValue(int partIdx);
        string GetWhereClausePart(FilterOperation op, params string[] fldNames);

        // Properties
        int ValuePartCount { get; }
    }
}