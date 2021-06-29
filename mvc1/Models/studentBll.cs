using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Web.UI.WebControls;

namespace mvc1.Models
{
    public class studentBll
    {
        string cs = ConfigurationManager.ConnectionStrings["sivamvc"].ConnectionString;
        //string cstrinadh = ConfigurationManager.ConnectionStrings["trinadhmvc"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public string InsertUserDtls(studentVos objuser)
        {
            string output = string.Empty;
            try
            {

                con = new SqlConnection(cs);
                cmd = new SqlCommand("USP_INS_STUDENT_FORM", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@STUDENT_FNAME", objuser.STUDENT_FNAME.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@STUDENT_LNAME", objuser.STUDENT_LNAME.ToUpper());
                cmd.Parameters.AddWithValue("@FATHER_NAME", objuser.FATHER_NAME.ToUpper());
                cmd.Parameters.AddWithValue("@MOBILE_NO", objuser.MOBILE_NO);
                cmd.Parameters.AddWithValue("@CLASS", objuser.CLASS);
                cmd.Parameters.AddWithValue("@ROLL_NO", objuser.ROLL_NO);
                cmd.Parameters.Add("@output", SqlDbType.VarChar, 100);
                cmd.Parameters["@output"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                output = cmd.Parameters["@output"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return output;
        }
        //  accessspecifie retunrtyoe name
        // Get All Student Details
        public List<studentVos> gettotalstudents()
        {
            DataSet ds = new DataSet();
            List<studentVos> liitem = new List<studentVos>();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("USP_GET_STDDTLS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            adp.Fill(ds);
            foreach (DataRow drrow in ds.Tables[0].Rows)
            {
                studentVos obj = new studentVos();
                obj.slno = drrow["SL_NO"].ToString();
                obj.STUDENT_FNAME = drrow["STUDENT_FNAME"].ToString();
                obj.STUDENT_LNAME = drrow["STUDENT_LNAME"].ToString();
                obj.FATHER_NAME = drrow["FATHER_NAME"].ToString();
                obj.MOBILE_NO = drrow["MOBILE_NO"].ToString();
                obj.CLASS = drrow["CLASS"].ToString();
                obj.ROLL_NO = Convert.ToInt32(drrow["ROLL_NO"].ToString());
                obj.active = drrow["ACTIVE"].ToString();
                obj.created = drrow["CREATED_DATED"].ToString();
                liitem.Add(obj);
            }
            return liitem;
        }

        // Get Student Details By Sl No.
        public studentVos gettotalstudentsbySlno(int slno)
        {
            DataSet ds = new DataSet();
            studentVos obj = new studentVos();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("USP_GET_STDDTLS_BYSLNO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SLNO", slno);
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = cmd;
            cmd.ExecuteNonQuery();
            adp.Fill(ds);
            foreach (DataRow drrow in ds.Tables[0].Rows)
            {
                obj.slno = drrow["SL_NO"].ToString();
                obj.STUDENT_FNAME = drrow["STUDENT_FNAME"].ToString();
                obj.STUDENT_LNAME = drrow["STUDENT_LNAME"].ToString();
                obj.FATHER_NAME = drrow["FATHER_NAME"].ToString();
                obj.MOBILE_NO = drrow["MOBILE_NO"].ToString();
                obj.CLASS = drrow["CLASS"].ToString();
                obj.ROLL_NO = Convert.ToInt32(drrow["ROLL_NO"].ToString());
                obj.active = drrow["ACTIVE"].ToString();
                obj.created = drrow["CREATED_DATED"].ToString();
            }
            return obj;
        }

        //Upd details

        // Get Student Details By Sl No.
        public string updstdDetailsbyslno(int slno, studentVos obj)
        {
            try
            {
                string output = "";
                con = new SqlConnection(cs);
                cmd = new SqlCommand("USP_UPD_STUDENTDTLS_BYSLNO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SLNO", slno);
                cmd.Parameters.AddWithValue("@STUDENT_FNAME", obj.STUDENT_FNAME);
                cmd.Parameters.AddWithValue("@STUDENT_LNAME", obj.STUDENT_LNAME);
                cmd.Parameters.AddWithValue("@FATHER_NAME", obj.FATHER_NAME);
                cmd.Parameters.AddWithValue("@MOBILE_NO", obj.MOBILE_NO);
                cmd.Parameters.AddWithValue("@CLASS", obj.CLASS);
                cmd.Parameters.AddWithValue("@ROLL_NO", obj.ROLL_NO);
                cmd.Parameters.Add("@output", SqlDbType.VarChar, 100);
                cmd.Parameters["@output"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                output = cmd.Parameters["@output"].Value.ToString();
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}