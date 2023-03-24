using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    [Serializable]
    public enum FilterOperation
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual,
        Like,
        NotLike,
        StartsWith,
        DoesNotStartWith,
        EndsWith,
        DoesNotEndWith,
        IsNull,
        IsNotNull
    }
}