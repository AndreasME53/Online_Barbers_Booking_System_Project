using System;
using System.Data;
using System.Data.SqlClient;

namespace projectmain1._1
{
    /// <summary>
    /// Base response object
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Flag for transaction completed
        /// </summary>
        public Boolean TransactionCompleted = false;
        /// <summary>
        /// Response message
        /// </summary>
        public String ResponseMessage = "";
        /// <summary>
        /// New ID
        /// </summary>
        public string NewID = "";
    }

    public static class GenericServices
    {
        public static class ReadRecord
        {
            public static DataTable ResponseTable = null;
            public static BaseResponse ProcessRead(string SqlString, SqlConnection Connection)
            {
                BaseResponse _Response = new BaseResponse();
                try
                {
                    DataSet ResultDataSet = new DataSet("dataset");
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    try
                    {
                        Adapter.SelectCommand = new SqlCommand(SqlString, Connection);
                        Adapter.SelectCommand.CommandTimeout = 600;
                        Adapter.Fill(ResultDataSet);
                    }
                    catch (Exception Error)
                    {
                        _Response.ResponseMessage = Error.Message;
                    }

                    ResponseTable = ResultDataSet.Tables[0];
                    _Response.TransactionCompleted = true;
                    _Response.ResponseMessage = "Response successful.";
                }
                catch
                {
                    _Response.ResponseMessage = "The connection is currently unavailable.";
                }
                return _Response;
            }
        }

        public static class CreateRecord
        {

            public static BaseResponse Processcreate(string SqlString, Boolean ReturnIndex, SqlConnection Connection)
            {
                BaseResponse _Response = new BaseResponse();

                if (ReturnIndex)
                    SqlString += " SELECT SCOPE_IDENTITY() ";
                SqlCommand Comm = new SqlCommand(SqlString, Connection);
                Comm.CommandTimeout = 600;
                try
                {
                    if (ReturnIndex)
                    {

                        _Response.NewID = Comm.ExecuteScalar().ToString();
                        _Response.ResponseMessage = "Record created";
                    }
                    else
                    {
                        _Response.NewID = "";
                        Comm.ExecuteNonQuery();
                    }
                }
                catch (SqlException SqlError)
                {
                    _Response.ResponseMessage = SqlString + SqlError.Message;
                }
                return _Response;
            }
        }

        public static class UpdateRecord
        {
            public static BaseResponse ProcessUpdate(string SqlString, SqlConnection Connection)
            {
                BaseResponse _Response = new BaseResponse();

                SqlCommand Comm = new SqlCommand(SqlString, Connection);
                Comm.CommandTimeout = 600;
                try
                {                    
                    string Result = Comm.ExecuteNonQuery().ToString();
                    if (Result != "0")
                    {
                        _Response.ResponseMessage = "Record Updated";
                    }
                    else
                    {
                        _Response.ResponseMessage = "Record Not Updated";
                    }
                }
                catch (SqlException SqlError)
                {
                    _Response.ResponseMessage = SqlString + SqlError.Message;
                }
                return _Response;
            }
        }

        //public static class DeleteRecord
        //{
        //    public static BaseResponse ProcessDelete(string SqlString, SqlConnection Connection)
        //    {
        //        BaseResponse _Response = new BaseResponse();

        //        SqlCommand Comm = new SqlCommand(SqlString, Connection);
        //        Comm.CommandTimeout = 600;
        //        try
        //        {
        //            string Result = Comm.ExecuteNonQuery().ToString();
        //            if (Result != "0")
        //            {
        //                _Response.ResponseMessage = "Record Deleted";
        //            }
        //            else
        //            {
        //                _Response.ResponseMessage = "Record Not Deleted";
        //            }
        //        }
        //        catch (SqlException SqlError)
        //        {
        //            _Response.ResponseMessage = SqlString + SqlError.Message;
        //        }
        //        return _Response;
        //    }
        //}
    }
}