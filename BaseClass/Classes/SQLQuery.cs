using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using NLog;
namespace BaseClase.Classes {
    public class SQLQuery {
     
        private static string _ConnectionString =ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SQLQuery() {
            
            }
        protected Logger Log { get; private set; }
        public int ExecuteNonQueryAsync(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {
            int retval = 0;

            using (var connection = new SqlConnection(_ConnectionString))
                {
                using (var command = new SqlCommand(cmdText,connection))
                    {
                    try
                        {
                        command.CommandType = cmdType;
                        command.Parameters.Clear();
                        command.Parameters.AddRange(commandParameters);
                        connection.Open();

                       var sqlResult = command.ExecuteNonQueryAsync();
                        retval = sqlResult.Result;
                         
                        }
                    catch (Exception ex)
                        {

                        Log.Fatal("Error running ExecuteNonQueryAsync.",ex.Message);
                     
                        }
                    finally
                        {
                        connection.Close();
                        }

                    return retval;
                    }
                }

            }

        //public async object ExecuteReaderAsync<T>(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {

        //    object retval;

        //    using (var connection = new SqlConnection(_ConnectionString))
        //        {
        //        using (var command = new SqlCommand(cmdText,connection))
        //            {
        //            try
        //                {
        //                var dt = new DataTable();
        //                command.CommandType = cmdType;
        //                command.Parameters.Clear();
        //                command.Parameters.AddRange(commandParameters);
        //                connection.Open();

        //                using (SqlDataAdapter a = new SqlDataAdapter(command))
        //                    {
        //                    a.Fill(dt);
        //                    }

        //                if (dt.Rows.Count < 1)
        //                    {
        //                    processingResult.IsSuccessful = false;
        //                    processingResult.Data = null;
        //                    return processingResult;
        //                    }
        //                try
        //                    {
        //                    var Vals = CollectionHelper.ConvertTo<T>(dt);
        //                    processingResult.Data = Vals;
        //                    }
        //                catch (Exception ex)
        //                    {
        //                    processingResult.IsSuccessful = false;
        //                    processingResult.Error = new ProcessingError("Error retrieving data.","Error retrieving data.",true,false);
        //                    Logger.Fatal("Error retrieving data:" + ex.Message);
        //                    }

        //                return processingResult;
        //                }
        //            catch (Exception ex)
        //                {
        //                processingResult.IsSuccessful = false;
        //                Logger.Fatal("Error running ExecuteReaderAsync.",ex);
        //                processingResult.Error = new ProcessingError("Error running ExecuteReaderAsync. Ex: " + ex.ToString(),"Error running ExecuteReaderAsync. Ex: " + ex.ToString(),false,false);
        //                return processingResult;
        //                }
        //            finally
        //                {
        //                connection.Close();
        //                }
        //            }
        //        }
        //    }

        public  DataTable ExecuteReaderAsync(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {
            DataTable dt=null;

            using (var connection = new SqlConnection(_ConnectionString))
                {
                using (var command = new SqlCommand(cmdText,connection))
                    {
                    try
                        {
                        var dt = new DataTable();
                        command.CommandType = cmdType;
                        command.Parameters.Clear();
                        command.Parameters.AddRange(commandParameters);
                        connection.Open();

                        using (SqlDataAdapter a = new SqlDataAdapter(command))
                            {
                            a.Fill(dt);
                            }
                        return dt;
                        }
                    catch (Exception ex)
                        {
                      
                        Log.Fatal("Error running ExecuteReaderAsync.",ex.Message);
                        
                        return dt;
                        }
                    finally
                        {
                        connection.Close();
                        }
                    }
                }
            }

        //public async Task<object> ExecuteScalarAsync(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {
        //    var result = new ServiceProcessingResult<object> { IsSuccessful = true };
        //    using (var connection = new SqlConnection(_ConnectionString))
        //        {
        //        using (var command = new SqlCommand(cmdText,connection))
        //            {
        //            try
        //                {
        //                command.CommandType = cmdType;
        //                command.Parameters.Clear();
        //                command.Parameters.AddRange(commandParameters);
        //                connection.Open();

        //                var sqlResult = await command.ExecuteScalarAsync();
        //                result.Data = sqlResult;
        //                }
        //            catch (Exception ex)
        //                {
        //                result.IsSuccessful = false;
        //                Logger.Fatal("Error running ExecuteScalarAsync.",ex);
        //                result.Error = new ProcessingError("Error processing ExecuteScalarAsync","Error processing ExecuteScalarAsync",true,false);
        //                }
        //            finally
        //                {
        //                connection.Close();
        //                }

        //            return result;
        //            }
        //        }
        //    }

        //protected string GetFormattedGenericLogMessage(string logMessage) {
        //    return String.Format(logMessage);
        //    }
        }
    }
