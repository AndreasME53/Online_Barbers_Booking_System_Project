using System;
using System.Data;
using System.Data.SqlClient;

namespace projectmain1._1
{
    /// <summary>
    /// Base response object that is going to be used to reference data from the services calls that interact with the database
    /// </summary>
    public class Base_Response
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


    /// <summary>
    /// Generic Services class. The services in this class allow for a reusable set of functions to create, read and update records in a database.
    /// </summary>
    public static class GenericServices
    {
        /// <summary>
        /// Read record is a generic class that allows the user to pass a SQL string and an open database connection, the class then executes the SQL against the database referenced in the SQL Connection paramater and returnes an populated data table with the results. The reason is so that we can reuse the read component everytime we need to populate a datatable.
        /// </summary>
        public static class ReadRecord
        {
            /// <summary>
            /// Data table that will be populated after the SQL has completed.
            /// </summary>
            public static DataTable ResponseTable = null;
            /// <summary>
            /// Process a database read
            /// </summary>
            /// <param name="SqlString">SQL String that will  be executed on the database, [Mandatory]</param>
            /// <param name="Connection">Open SQL Connection, [Mandatory]</param>
            /// <returns>Populated BaseResponse</returns>
            public static Base_Response ProcessRead(string SqlString, SqlConnection Connection)
            {
                //creates an object of the base response class to be sent back to the variables that requested the ReadRecord function
                Base_Response _Response = new Base_Response();
                try
                {
                    //Initialise the data set which is a snapshot of all the information in a database at a given moment in time
                    DataSet ResultDataSet = new DataSet("dataset");
                    //Declare the SQL Adapater which is used to fill a DataSet or DataTable and so you will have access to the data after your connection has been closed 
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    try
                    {
                        //Assign the Passed in the SQL String to executes SQL commands on a database
                        Adapter.SelectCommand = new SqlCommand(SqlString, Connection);
                        //Set the timeout for the results in case the database hangs.
                        Adapter.SelectCommand.CommandTimeout = 600;
                        //Fill the adapter with results.
                        Adapter.Fill(ResultDataSet);
                        // sets the transactioncomplete variable in the _response object to true
                        _Response.TransactionCompleted = true;
                        //stores the response message variable in the _response object
                        _Response.ResponseMessage = "Response successful.";
                        //Response table is assigned to the result set table 0
                        ResponseTable = ResultDataSet.Tables[0];
                    }
                    catch (Exception Error)
                    {
                        //if the try portion failes then the response message is populated with an error
                        _Response.ResponseMessage = Error.Message;
                    }
                }
                catch
                {
                    //Response message is populated with a connection error message
                    _Response.ResponseMessage = "The connection is currently unavailable.";
                }
                return _Response;
            }
        }
        /// <summary>
        /// Createrecord is a generic class that allows the user to pass a SQL string and an open database connection, the class then executes the SQL against the database that is to create a new record with in the database and finally returns a response saying if its been achieved. The reason is so that we can reuse the create component everytime we need tocreate a new record within the database.
        /// </summary>
        public static class CreateRecord
        {
            /// <summary>
            /// process a database create
            /// </summary>
            /// <param name="SqlString">The insert SQL String that will be executed on the database to create a record, [Mandatory]</param>
            /// <param name="ReturnIndex">Boolean value to instruct the service on wether or not to return a created index., [Mandatory]</param>
            /// <param name="Connection">Open SQL Connection, [Mandatory]</param>
            /// <returns>Populated BaseResponse</returns>
            public static Base_Response Processcreate(string SqlString, Boolean ReturnIndex, SqlConnection Connection)
            {
                //creates an object of the base response class to be sent back to the variables that requested the CreateRecord function
                Base_Response _Response = new Base_Response();

                if (ReturnIndex)   // * Why is this needed if its allways passed in as true
                    SqlString += " SELECT SCOPE_IDENTITY() ";
                //SqlCommand object is declared and the SQL statement set along with the database connection.
                SqlCommand Comm = new SqlCommand(SqlString, Connection);
                //Set the timeout for the results in case the database hangs.
                Comm.CommandTimeout = 600;
                try //created to deal with errors that might occur, and prevent the systme from crashing
                {
                    if (ReturnIndex)
                    {
                        //Executes the insert statement on the database and populates a newly created index in the newID's _Response object.
                        _Response.NewID = Comm.ExecuteScalar().ToString();
                        //Stores "Record created" in the object _Response
                        _Response.ResponseMessage = "Record created";
                        // sets the transactioncomplete variable in the _response object to true
                        _Response.TransactionCompleted = true;
                    }
                    else
                    {
                        //Executes the SQL to the database without a return response.
                        Comm.ExecuteNonQuery();
                    }
                }
                catch (SqlException SqlError)
                {
                    //if the try portion failes then the response message is populated with an error
                    _Response.ResponseMessage = SqlString + SqlError.Message;
                }
                return _Response;
            }
        }
        /// <summary>
        /// UpdateRecord is a generic class that allows the user to pass a SQL string and an open database connection, the class then executes the SQL against the database referenced in the SQL Connection paramater and Updates a record in the dattabase. The reason is so that we can reuse the update component everytime we need to update the database.
        /// </summary>

        public static class UpdateRecord
        {
            /// <summary>
            /// Process a database update
            /// </summary>
            /// <param name="SqlString">The update SQL String that will be executed on the database to update a record, [Mandatory]</param>
            /// <param name="Connection">Open SQL Connection, [Mandatory]</param>
            /// <returns>Populated BaseResponse</returns>
            public static Base_Response ProcessUpdate(string SqlString, SqlConnection Connection)
            {
                //creates an object of the base response class to be sent back to the variables that requested the UpdateRecord function
                Base_Response _Response = new Base_Response();
                //SqlCommand object is declared and the SQL statement set along with the database connection.
                SqlCommand Comm = new SqlCommand(SqlString, Connection);
                //Set the timeout for the results in case the database hangs.
                Comm.CommandTimeout = 600;
                try//here incase there is an error and protects systrem from crashing
                {
                    //stores the result used for executing updateRecords as it does not return any data back and if the update is successful the rows number is returned and then the _respond object can pass a response message of the createion being successful or unsuccessful
                    string Result = Comm.ExecuteNonQuery().ToString();
                    if (Result != "0")
                    {
                        //Stores "Record Updated" in the object _Response
                        _Response.ResponseMessage = "Record Updated";
                        // sets the transactioncomplete variable in the _response object to true
                        _Response.TransactionCompleted = true;
                    }
                    else
                    {
                        _Response.ResponseMessage = "Record Not Updated";
                    }
                }
                catch (SqlException SqlError)
                {
                    //if the try portion fails then the response message is populated with an error
                    _Response.ResponseMessage = SqlString + SqlError.Message;
                }
                return _Response;
            }
        }


    }
}