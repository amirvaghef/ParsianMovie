using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Common
{
    [Serializable]
    public class SearchFilter
    {
        // Fields
        public ArrayList Filters = new ArrayList();

        // Methods
        public void AddFilter(FilterDefinition fd)
        {
            this.AndFilter(fd);
        }

        public void AddFilter(SearchFilter sf)
        {
            this.AndFilter(sf);
        }

        public void AndFilter(FilterDefinition fd)
        {
            if (this.Filters.Count != 0)
            {
                this.Filters.Add(FilterRelation.And);
            }
            this.Filters.Add(fd);
        }

        public void AndFilter(SearchFilter sf)
        {
            if (this.Filters.Count != 0)
            {
                this.Filters.Add(FilterRelation.And);
            }
            this.Filters.Add(sf);
        }

        private string GetDescription(FilterOperation operation)
        {
            switch (operation)
            {
                case FilterOperation.Equal:
                    return "=";

                case FilterOperation.NotEqual:
                    return "<>";

                case FilterOperation.GreaterThan:
                    return ">";

                case FilterOperation.GreaterThanEqual:
                    return ">=";

                case FilterOperation.LessThan:
                    return "<";

                case FilterOperation.LessThanEqual:
                    return "<=";

                case FilterOperation.Like:
                    return "like";

                case FilterOperation.NotLike:
                    return "not like";

                case FilterOperation.StartsWith:
                    return "starts with";

                case FilterOperation.DoesNotStartWith:
                    return "not starts with";

                case FilterOperation.EndsWith:
                    return "ends with";

                case FilterOperation.DoesNotEndWith:
                    return "not ends with";

                case FilterOperation.IsNull:
                    return "is null";

                case FilterOperation.IsNotNull:
                    return "is not null";
            }
            throw new ApplicationException("A filter operation that the translator does not understand was used.");
        }

        public void OrFilter(FilterDefinition fd)
        {
            if (this.Filters.Count != 0)
            {
                this.Filters.Add(FilterRelation.Or);
            }
            this.Filters.Add(fd);
        }

        public void OrFilter(SearchFilter sf)
        {
            if (this.Filters.Count != 0)
            {
                this.Filters.Add(FilterRelation.Or);
            }
            this.Filters.Add(sf);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.Filters.Count; i++)
            {
                object obj2 = this.Filters[i];
                if (obj2 is FilterRelation)
                {
                    switch (((FilterRelation)obj2))
                    {
                        case FilterRelation.And:
                            builder.Append(" and ");
                            goto Label_0112;

                        case FilterRelation.Or:
                            builder.Append(" or ");
                            break;
                    }
                Label_0112: ;
                }
                else if (obj2 is FilterDefinition)
                {
                    FilterDefinition definition = (FilterDefinition)obj2;
                    builder.Append(definition.Column.ColumnName);
                    builder.Append(" ");
                    builder.Append(this.GetDescription(definition.Operation));
                    if (definition.Value != null)
                    {
                        builder.Append(" '");
                        builder.Append(definition.Value.ToString());
                        builder.Append("'");
                    }
                }
                else
                {
                    if (!(obj2 is SearchFilter))
                    {
                        throw new ApplicationException("Unknown type was inserted into the Filter Array.");
                    }
                    SearchFilter filter = (SearchFilter)obj2;
                    builder.Append("(");
                    builder.Append(filter.ToString());
                    builder.Append(")");
                }
            }
            return "Empty Filter";
        }
    }
}