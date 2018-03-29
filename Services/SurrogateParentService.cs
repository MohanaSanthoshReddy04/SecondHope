using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Surrogacy.Data;
using Surrogacy.Helper;
using Surrogacy.Models;
using Surrogacy.Util;

namespace Surrogacy.Service
{
    public class SurrogateParentService
    {
        public SurrogateParent ViewSurrogateParentData(SurrogateParent parentsurrogate)
        {
            SurrogateParent localinfosurrogate = new SurrogateParent();
            SurrogateParentData infosurrogatedata = new SurrogateParentData();
            DataSet dataSet = new DataSet();
            try
            {
                dataSet = infosurrogatedata.ViewSurrogateParentData(parentsurrogate);

                if (dataSet.Tables["SurrogateParent"].Rows.Count > 0)
                { 
                    localinfosurrogate.SurrogateID = Convert.ToInt16(dataSet.Tables["SurrogateParent"].Rows[0]["SURROGATEID"].ToString());
                    localinfosurrogate.SurroagateFirstName = dataSet.Tables["SurrogateParent"].Rows[0]["SURRROGATEFIRSTNAME"].ToString();
                    localinfosurrogate.SurrogateLastName = dataSet.Tables["SurrogateParent"].Rows[0]["SURROGATELASTNAME"].ToString();
                    localinfosurrogate.SurrogateEmailID = dataSet.Tables["SurrogateParent"].Rows[0]["EMAIL"].ToString();
                    localinfosurrogate.ParentFirstName = dataSet.Tables["SurrogateParent"].Rows[0]["PARENTFIRSTNAME"].ToString();
                    localinfosurrogate.ParentID = Convert.ToInt16(dataSet.Tables["SurrogateParent"].Rows[0]["PARENTID"].ToString());
                    localinfosurrogate.ParentEmailID = dataSet.Tables["SurrogateParent"].Rows[0]["PARENTEMAIL"].ToString();
                    localinfosurrogate.ParentLastName = dataSet.Tables["SurrogateParent"].Rows[0]["PARENTLASTNAME"].ToString();
                    localinfosurrogate.DoctorName = dataSet.Tables["SurrogateParent"].Rows[0]["DOCTORNAME"].ToString();
                    localinfosurrogate.DoctorEmailID = dataSet.Tables["SurrogateParent"].Rows[0]["DOCTOREMAIL"].ToString();
                    
                }
            }
            catch (SqlException sqlEx)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = sqlEx.Message;
            }
            catch (Exception ex)
            {
                localinfosurrogate.responseDetail.responseType = ResponseType.Error;
                localinfosurrogate.responseDetail.ResponseMessage = ApplicationManager.GenericErrorMessage;

                LoggerHelper.WriteToLog(ex);
            }

            return localinfosurrogate == null ? new SurrogateParent() : localinfosurrogate;
        }

        public List<SurrogateParent> ViewSurrogateParentDataList(SurrogateParent parentsurrogate)
        {
            List<SurrogateParent> localinfosurrogate = new List<SurrogateParent>();
            SurrogateParentData infosurrogatedata = new SurrogateParentData();
            DataSet dataSet = new DataSet();
            SurrogateParent lcsurrogateparent = new SurrogateParent();
            lcsurrogateparent.UserID = ApplicationManager.LoggedInUser.UserID;
            try
            {
                dataSet = infosurrogatedata.ViewSurrogateParentData(lcsurrogateparent);

                if (dataSet.Tables["SurrogateParent"].Rows.Count > 0)
                {
                    for (int i = 0; i < dataSet.Tables["SurrogateParent"].Rows.Count; i++)
                    {
                        SurrogateParent lc = new SurrogateParent();
                        lc.SurrogateID = Convert.ToInt16(dataSet.Tables["SurrogateParent"].Rows[i]["SURROGATEID"].ToString());
                        lc.SurroagateFirstName = dataSet.Tables["SurrogateParent"].Rows[i]["SURRROGATEFIRSTNAME"].ToString();
                        lc.SurrogateLastName = dataSet.Tables["SurrogateParent"].Rows[i]["SURROGATELASTNAME"].ToString();
                        lc.SurrogateEmailID = dataSet.Tables["SurrogateParent"].Rows[i]["EMAIL"].ToString();
                        lc.ParentFirstName = dataSet.Tables["SurrogateParent"].Rows[i]["PARENTFIRSTNAME"].ToString();
                        lc.ParentID = Convert.ToInt16(dataSet.Tables["SurrogateParent"].Rows[i]["PARENTID"].ToString());
                        lc.ParentEmailID = dataSet.Tables["SurrogateParent"].Rows[i]["PARENTEMAIL"].ToString();
                        lc.ParentLastName = dataSet.Tables["SurrogateParent"].Rows[i]["PARENTLASTNAME"].ToString();
                        lc.DoctorName = dataSet.Tables["SurrogateParent"].Rows[i]["DOCTORNAME"].ToString();
                        lc.DoctorEmailID = dataSet.Tables["SurrogateParent"].Rows[i]["DOCTOREMAIL"].ToString();
                        localinfosurrogate.Add(lc);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteToLog(ex);
            }

            return localinfosurrogate;
        }
    }
}