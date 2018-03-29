using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Helper;
using Surrogacy.Models;

namespace Surrogacy.Data
{
    public class SurrogateParentData : BaseData
    {
        public DataSet ViewSurrogateParentData(SurrogateParent surrogateparent)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string storedProcedure = "pSRGs_SurrogateParentInfo";
                string parameterName = "@aXMLString";
                string parameterValue = ObjectHelper.GetXMLFromObject(surrogateparent);
                sqlCommand = new SqlCommand(storedProcedure, sqlConnection);
                sqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataSet);
                dataSet.Tables[0].TableName = "SurrogateParent";
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                sqlConnection.Close();
            }

            return dataSet;
        }
    }
}