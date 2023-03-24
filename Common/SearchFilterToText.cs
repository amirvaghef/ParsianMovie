using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SearchFilterToText
    {
        // Fields
        private SearchFilter SearchFilter;
        private ColumnTranslator[] Translators;

        // Methods
        public SearchFilterToText(SearchFilter sf, ColumnTranslator[] translators)
        {
            this.SearchFilter = sf;
            this.Translators = translators;
        }

        private string GetDescription(FilterOperation operation)
        {
            switch (operation)
            {
                case FilterOperation.Equal:
                    return "برابر با";

                case FilterOperation.NotEqual:
                    return "نا برابر با";

                case FilterOperation.GreaterThan:
                    return "بزرگتر از";

                case FilterOperation.GreaterThanEqual:
                    return "بزرگتر و يا مساوي با";

                case FilterOperation.LessThan:
                    return "کوچکتر از";

                case FilterOperation.LessThanEqual:
                    return "کوچکتر و يا مساوي با";

                case FilterOperation.Like:
                    return "شبيه به";

                case FilterOperation.NotLike:
                    return "شبيه نيست به";

                case FilterOperation.StartsWith:
                    return "آغاز مي شود با";

                case FilterOperation.DoesNotStartWith:
                    return "آغاز نمي شود با";

                case FilterOperation.EndsWith:
                    return "خاتمه پيدا مي کند با";

                case FilterOperation.DoesNotEndWith:
                    return "خاتمه پيدا نمي کند با";

                case FilterOperation.IsNull:
                    return "خالي";

                case FilterOperation.IsNotNull:
                    return "خالي نيست";
            }
            throw new ApplicationException("A filter operation that the translator does not understand was used.");
        }

        private string GetDescription(AMDataColumn column)
        {
            foreach (ColumnTranslator translator in this.Translators)
            {
                if (translator.Column.ColumnName.Equals(column.ColumnName))
                {
                    return translator.DisplayName;
                }
            }
            throw new ApplicationException("The column '" + column.ColumnName + "', in the filter definition did not exist in the ColumnTranslator array.");
        }

        public override string ToString()
        {
            if (this.SearchFilter == null)
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.SearchFilter.Filters.Count; i++)
            {
                object obj2 = this.SearchFilter.Filters[i];
                if (obj2 is FilterRelation)
                {
                    switch (((FilterRelation)obj2))
                    {
                        case FilterRelation.And:
                            builder.Append(" و ");
                            goto Label_0140;

                        case FilterRelation.Or:
                            builder.Append(" يا ");
                            break;
                    }
                Label_0140: ;
                }
                else if (obj2 is FilterDefinition)
                {
                    FilterDefinition definition = (FilterDefinition)obj2;
                    builder.Append(this.GetDescription(definition.Column));
                    builder.Append(" ");
                    builder.Append(this.GetDescription(definition.Operation));
                    if ((definition.Operation != FilterOperation.IsNotNull) && (definition.Operation != FilterOperation.IsNull))
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
                        throw new ApplicationException("Invalid object in the search filter.");
                    }
                    builder.Append(" ( ");
                    builder.Append(new SearchFilterToText(obj2 as SearchFilter, this.Translators).Text);
                    builder.Append(" ) ");
                }
            }
            return builder.ToString();
        }

        // Properties
        public string Text
        {
            get
            {
                return this.ToString();
            }
        }
    }
}