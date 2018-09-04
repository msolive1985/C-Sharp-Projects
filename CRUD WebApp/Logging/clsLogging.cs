using System;
using System.Collections.Generic;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace Logging
{
    public class clsLogging
    {
        public void WriteLog(Exception ex)
        {
            SQLHelper sqlHelper = new SQLHelper();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@dtError", DateTime.Now));
            parameters.Add(new SqlParameter("@vcError", ex.Message));
            parameters.Add(new SqlParameter("@vcErrorStack", ex.StackTrace));

            sqlHelper.executeSP<DataSet>(parameters, "InsertLog");
        }
    }
}
