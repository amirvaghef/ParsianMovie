using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class SQLHelper
    {
        private static string _connectionString;
        public static string connectionString
        {
            set
            {
                _connectionString = value;
            }
            get
            {
                return _connectionString;
            }
        }
    }
}
