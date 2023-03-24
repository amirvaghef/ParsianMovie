using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

namespace Common
{
    public class SQLFilterTranslator : IFilterTranslator
    {
        // Fields
        protected SearchFilter Filter;
        protected ArrayList TableNames = new ArrayList();

        // Methods
        public SQLFilterTranslator(SearchFilter filter)
        {
            this.Filter = filter;
            if (filter != null)
            {
                ArrayList filters = new ArrayList();
                this.AddTablesToArray(filter, filters);
                foreach (string str in filters)
                {
                    this.AddTableToJoin(str);
                }
            }
        }

        private void AddTablesToArray(SearchFilter sf, ArrayList filters)
        {
            foreach (object obj2 in sf.Filters)
            {
                FilterDefinition definition = obj2 as FilterDefinition;
                if ((definition != null) && !filters.Contains(definition.Column.TableName))
                {
                    filters.Add(definition.Column.TableName);
                    continue;
                }
                if (obj2 is SearchFilter)
                {
                    this.AddTablesToArray(obj2 as SearchFilter, filters);
                }
            }
        }

        public void AddTableToJoin(string tblName)
        {
            bool flag = false;
            foreach (string str in this.TableNames)
            {
                if (str == tblName)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                this.TableNames.Add(tblName);
            }
        }

        private DataRelation FindRelation(DataRelationCollection drc, string mainTable, string secondTable)
        {
            foreach (DataRelation relation in drc)
            {
                if ((relation.ParentTable.TableName == mainTable) && (relation.ChildTable.TableName == secondTable))
                {
                    return relation;
                }
                if ((relation.ChildTable.TableName == mainTable) && (relation.ParentTable.TableName == secondTable))
                {
                    return relation;
                }
            }
            return null;
        }

        private string GetColumnName(AMDataColumn dc)
        {
            if (this.GetTableCount() == 1)
            {
                return dc.ColumnName;
            }
            return ("tbl" + this.TableNames.IndexOf(dc.TableName).ToString() + "." + dc.ColumnName);
        }

        public string GetFromClause(DataRelationCollection drc)
        {
            if (this.GetTableCount() == 1)
            {
                return this.GetTable(0);
            }
            StringBuilder builder = new StringBuilder();
            ArrayList list = new ArrayList();
            foreach (string str in this.TableNames)
            {
                list.Add(str);
            }
            ArrayList list2 = (ArrayList)list.Clone();
            foreach (string str2 in list)
            {
                string mainTable = str2;
                for (int i = 0; i < list.Count; i++)
                {
                    string secondTable = (string)list[i];
                    if (secondTable != mainTable)
                    {
                        DataRelation relation = this.FindRelation(drc, mainTable, secondTable);
                        if ((relation != null) && (list2.Contains(secondTable) || list2.Contains(mainTable)))
                        {
                            bool flag = false;
                            bool flag2 = false;
                            if (list2.Contains(mainTable))
                            {
                                flag = true;
                                list2.Remove(mainTable);
                            }
                            if (list2.Contains(secondTable))
                            {
                                flag2 = true;
                                list2.Remove(secondTable);
                            }
                            if (flag && flag2)
                            {
                                builder.Append(mainTable);
                                builder.Append(" as ");
                                builder.Append(this.GetTableAlias(mainTable));
                                builder.Append(" inner join ");
                                builder.Append(secondTable);
                                builder.Append(" as ");
                                builder.Append(this.GetTableAlias(secondTable));
                            }
                            else
                            {
                                string str5;
                                if (flag)
                                {
                                    str5 = mainTable;
                                }
                                else
                                {
                                    str5 = secondTable;
                                }
                                builder.Append(" inner join ");
                                builder.Append(str5);
                                builder.Append(" as ");
                                builder.Append(this.GetTableAlias(str5));
                            }
                            builder.Append(" on ");
                            for (int j = 0; j < relation.ParentColumns.Length; j++)
                            {
                                if (j > 0)
                                {
                                    builder.Append(" and ");
                                }
                                builder.Append(this.GetTableAlias(relation.ParentColumns[j].Table.TableName));
                                builder.Append(".");
                                builder.Append(relation.ParentColumns[j].ColumnName);
                                builder.Append(" = ");
                                builder.Append(this.GetTableAlias(relation.ChildColumns[j].Table.TableName));
                                builder.Append(".");
                                builder.Append(relation.ChildColumns[j].ColumnName);
                            }
                        }
                    }
                }
            }
            if (list2.Count > 0)
            {
                throw new ApplicationException("The tables in the constraint are not fully connected");
            }
            return builder.ToString();
        }

        public string GetOrderByClause(string tableAlias, params AMDataColumn[] cols)
        {
            string str = "";
            string str2 = "";
            if ((tableAlias != null) && (tableAlias.Trim().Length > 0))
            {
                str2 = tableAlias.Trim() + ".";
            }
            foreach (AMDataColumn column in cols)
            {
                str = str + ((str.Length > 0) ? ", " : "") + str2 + column.ColumnName;
            }
            return str;
        }

        public string GetTable(int idx)
        {
            return (this.TableNames[idx] as string);
        }

        public string GetTableAlias(string tblName)
        {
            if (this.GetTableCount() <= 1)
            {
                return "";
            }
            int index = this.TableNames.IndexOf(tblName);
            return ("tbl" + index.ToString());
        }

        public int GetTableCount()
        {
            return this.TableNames.Count;
        }

        public string GetWhereClause()
        {
            return this.GetWhereClause(this.Filter);
        }

        private string GetWhereClause(SearchFilter sf)
        {
            StringBuilder builder = new StringBuilder();
            if ((sf == null) || (sf.Filters.Count == 0))
            {
                return "";
            }
            for (int i = 0; i < sf.Filters.Count; i++)
            {
                object obj2 = sf.Filters[i];
                if (obj2 is FilterDefinition)
                {
                    builder.Append(" " + this.TranslateFilter((FilterDefinition)obj2));
                }
                else if (obj2 is FilterRelation)
                {
                    builder.Append(" " + this.TranslateRelation((FilterRelation)obj2));
                }
                else if (obj2 is SearchFilter)
                {
                    string whereClause = this.GetWhereClause(obj2 as SearchFilter);
                    if (whereClause.Length > 0)
                    {
                        builder.Append(" (" + whereClause + ") ");
                    }
                }
            }
            return builder.ToString();
        }

        private string TranslateFilter(FilterDefinition fd)
        {
            if (fd.Value is IObjectId)
            {
                return ((IObjectId)fd.Value).GetWhereClausePart(fd.Operation, new string[] { this.GetColumnName(fd.Column) });
            }
            StringBuilder builder = new StringBuilder();
            if (((fd.Operation == FilterOperation.NotLike) || (fd.Operation == FilterOperation.DoesNotEndWith)) || ((fd.Operation == FilterOperation.DoesNotStartWith) || (fd.Operation == FilterOperation.IsNotNull)))
            {
                builder.Append("not (");
            }
            builder.Append(this.GetColumnName(fd.Column));
            builder.Append(" ");
            builder.Append(TranslateOperation(fd.Operation));
            if ((fd.Operation != FilterOperation.IsNotNull) && (fd.Operation != FilterOperation.IsNull))
            {
                if (((fd.Operation == FilterOperation.Like) || (fd.Operation == FilterOperation.NotLike)) || ((fd.Operation == FilterOperation.EndsWith) || (fd.Operation == FilterOperation.DoesNotEndWith)))
                {
                    builder.Append(" '%");
                }
                else
                {
                    builder.Append(" '");
                }
                if (fd.Value.GetType() == typeof(bool))
                {
                    builder.Append(((bool)fd.Value) ? "1" : "0");
                }
                else
                {
                    builder.Append(fd.Value.ToString().Replace("'", "''"));
                }
                if (((fd.Operation == FilterOperation.Like) || (fd.Operation == FilterOperation.NotLike)) || ((fd.Operation == FilterOperation.StartsWith) || (fd.Operation == FilterOperation.DoesNotStartWith)))
                {
                    builder.Append("%' ");
                }
                else
                {
                    builder.Append("' ");
                }
            }
            if (((fd.Operation == FilterOperation.NotLike) || (fd.Operation == FilterOperation.DoesNotEndWith)) || ((fd.Operation == FilterOperation.DoesNotStartWith) || (fd.Operation == FilterOperation.IsNotNull)))
            {
                builder.Append(")");
            }
            return builder.ToString();
        }

        public static string TranslateOperation(FilterOperation fo)
        {
            switch (fo)
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
                case FilterOperation.NotLike:
                case FilterOperation.StartsWith:
                case FilterOperation.DoesNotStartWith:
                case FilterOperation.EndsWith:
                case FilterOperation.DoesNotEndWith:
                    return "like";

                case FilterOperation.IsNull:
                case FilterOperation.IsNotNull:
                    return "is null";
            }
            throw new ApplicationException("Invalid Filter Operation");
        }

        private string TranslateRelation(FilterRelation fr)
        {
            switch (fr)
            {
                case FilterRelation.And:
                    return "and";

                case FilterRelation.Or:
                    return "or";
            }
            throw new ApplicationException("Invalid Filter Relation");
        }
    }
}