
using Exceptionless;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClass.Classes;

namespace BaseClass.Classes
{
    public static class SQLCore {
        public static int ExecuteNonQuery(SQLQueryProperties _sqlProperties) {
            int returnResult=0;

            using (var connection = new SqlConnection(_sqlProperties.ConnectionString)) {
                using (var command = new SqlCommand(_sqlProperties.CommandText, connection)) {
                    try {
                        command.CommandType = _sqlProperties.CommandType;
                        command.Parameters.Clear();
                        if (_sqlProperties.CommandParameters != null) { command.Parameters.AddRange(_sqlProperties.CommandParameters.ToArray()); }
                        connection.Open();

                        var sqlResult = command.ExecuteNonQuery();
                       returnResult = sqlResult;
                    } catch (Exception ex) {
                       
                    } finally {
                        connection.Close();
                    }

                    return returnResult;
                }
            }
        }

        public static object ExecuteReader<T>(SQLQueryProperties _sqlProperties) {

            
            using (var connection = new SqlConnection(_sqlProperties.ConnectionString)) {
                object returnResult = null;
                using (var command = new SqlCommand(_sqlProperties.CommandText, connection)) {
                    try {
                        var dt = new DataTable();
                        command.CommandType = _sqlProperties.CommandType;
                        command.Parameters.Clear();
                        if (_sqlProperties.CommandParameters != null) { command.Parameters.AddRange(_sqlProperties.CommandParameters.ToArray()); }
                        command.CommandTimeout = _sqlProperties.Timeout;
                        connection.Open();

                        using (SqlDataAdapter a = new SqlDataAdapter(command)) {
                            a.Fill(dt);
                        }

                        if (dt.Rows.Count < 1) {
                            returnResult = null;
                            return null;
                        }

                        try {
                            IList<T> ValsList;
                            T ValsObject;

                            if (_sqlProperties.ReturnList) {
                                ValsList = CollectionHelper.ConvertTo<T>(dt);
                                returnResult = ValsList;
                            } else {
                                ValsObject = CollectionHelper.ConvertToObject<T>(dt);
                                returnResult = ValsObject;
                            }
                        } catch (Exception ex) {
                            //processingResult.IsError = true;
                            //processingResult.Errors.Add(new ApiProcessingError("Error retrieving data from ExecuteReader.", "Error retrieving data from ExecuteReader.", ""));

                            //ex.ToExceptionless()
                            //   .SetMessage("Collection Helper Error")
                            //   .AddTags("Collection Helper")
                            //   .MarkAsCritical()
                            //   .Submit();
                        }

                        return returnResult;
                    } catch (Exception ex) {
                        //processingResult.IsError = true;

                        //ex.ToExceptionless()
                        //   .SetMessage("Error running ExecuteReaderAsync(object).")
                        //   .AddTags("Sql Query Wrapper")
                        //   .AddObject(_sqlProperties.CommandText, "Query")
                        //   .AddObject(Utils.CommandParametersToObj(_sqlProperties.CommandParameters.ToArray()), "Query Parameters")
                        //   .MarkAsCritical()
                        //   .Submit();
                        //processingResult.Errors.Add(new ApiProcessingError("Error running ExecuteReaderAsync. Ex: " + ex.ToString(), "Error running ExecuteReaderAsync. Ex: " + ex.ToString(), ""));
                        return returnResult;
                    } finally {
                        connection.Close();
                    }
                }
            }
        }

        public static string ExecuteScalar(SQLQueryProperties _sqlProperties) {
            string returnResult = "";
            if (_sqlProperties.ReturnSqlIdentityId) {
                _sqlProperties.CommandText += ";SELECT CAST(scope_identity() AS varchar)";
            }

            using (var connection = new SqlConnection(_sqlProperties.ConnectionString)) {
                using (var command = new SqlCommand(_sqlProperties.CommandText, connection)) {
                    try {
                        command.CommandType = _sqlProperties.CommandType;
                        command.Parameters.Clear();

                        if (_sqlProperties.CommandParameters != null) { command.Parameters.AddRange(_sqlProperties.CommandParameters.ToArray()); }
                        connection.Open();

                        var sqlResult = command.ExecuteScalar();
                        returnResult = sqlResult.ToString();
                    } catch (Exception ex) {
                       //
                    } finally {
                        connection.Close();
                    }

                    return returnResult;
                }
            }
        }

      //  public static ApiProcessingResult<string> AddAuditLog(SQLQueryProperties _sqlProperties) {
      //      var result = new ApiProcessingResult<string>();
      //      if (_sqlProperties.ReturnSqlIdentityId) {
      //          _sqlProperties.CommandText += ";SELECT CAST(scope_identity() AS varchar)";
      //      }

      //      using (var connection = new SqlConnection(_sqlProperties.ConnectionString)) {
      //          using (var command = new SqlCommand(_sqlProperties.CommandText, connection)) {
      //              try {
      //                  command.CommandType = _sqlProperties.CommandType;
      //                  command.Parameters.Clear();

      //                  if (_sqlProperties.CommandParameters != null) { command.Parameters.AddRange(_sqlProperties.CommandParameters.ToArray()); }
      //                  connection.Open();

      //                  var sqlResult = command.ExecuteScalar();
						//if (sqlResult == null)
						//{
						//	sqlResult = "";
						//}
						//result.Data = sqlResult.ToString();
      //              } catch (Exception ex) {
      //                  result.IsError = true;

      //                  ex.ToExceptionless()
      //                    .SetMessage("Error running ExecuteScalarAsync.")
      //                    .AddTags("SqlQueryWrapper")
      //                    .AddObject(_sqlProperties.CommandText, "Query")
      //                    .AddObject(Utils.CommandParametersToObj(_sqlProperties.CommandParameters.ToArray()), "Query Parameters")
      //                    .MarkAsCritical()
      //                    .Submit();
      //                  result.Errors.Add(new ApiProcessingError("Error processing ExecuteScalarAsync", "Error processing ExecuteScalarAsync", ""));
      //              } finally {
      //                  connection.Close();
      //              }

      //              return result;
      //          }
      //      }
      //  }

    }
}
