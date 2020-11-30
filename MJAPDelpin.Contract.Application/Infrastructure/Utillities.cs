using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MJAPDelpin.Contract.Application.Infrastructure
{
   public static class Utillities
    {

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "den1.mssql7.gear.host";
                builder.UserID = "delpincontract";
                builder.Password = "Up4GZLm~pDo~";
                builder.InitialCatalog = "delpincontract";

                return builder.ConnectionString;
            }
            private set
            {
                ConnectionString = value;
            }
        }
    }
}
