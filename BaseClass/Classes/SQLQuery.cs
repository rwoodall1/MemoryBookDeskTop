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
        protected Logger Log { get; private set; }
        private static string _ConnectionString =ConfigurationManager.ConnectionStrings["Mbc"].ConnectionString;

        public SQLQuery() {
            Log = LogManager.GetLogger(GetType().FullName);
        }
      
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

        public object ExecuteReaderAsync<T>(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {

            object retval=null;

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

                        if (dt.Rows.Count < 1)
                            {
                           
                            return retval;
                            }
                        try
                            {
                            var Vals =BaseClass.Classes.CollectionHelper.ConvertTo<T>(dt);
                          
                            }
                        catch (Exception ex)
                            {
                         
                            Log.Fatal("Error retrieving data:" + ex.Message);
                            }

                        return retval;//has data 
                        }
                    catch (Exception ex)
                        {
                       
                       Log.Fatal("Error running ExecuteReaderAsync.",ex.Message);
                    
                        return retval;
                        }
                    finally
                        {
                        connection.Close();
                        }
                    }
                }
            }

        public  DataTable ExecuteReaderAsync(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {
            DataTable dt=null;

            using (var connection = new SqlConnection(_ConnectionString))
                {
                using (var command = new SqlCommand(cmdText,connection))
                    {
                    try
                        {
                       dt = new DataTable();
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

        public async Task<object> ExecuteScalarAsync(CommandType cmdType,string cmdText,params SqlParameter[] commandParameters) {
            object sqlResult=null;
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

                         sqlResult = await command.ExecuteScalarAsync();
                     
                        }
                    catch (Exception ex)
                        {
                      
                        Log.Fatal("Error running ExecuteScalarAsync.",ex.Message);
                       
                        }
                    finally
                        {
                        connection.Close();
                        }

                    return sqlResult ;
                    }
                }
            }

        protected string GetFormattedGenericLogMessage(string logMessage) {
            return String.Format(logMessage);
            }
        }
    }
