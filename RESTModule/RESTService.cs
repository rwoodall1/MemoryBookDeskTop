﻿
using Core;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Configuration;
//using Exceptionless;
using BaseClass.Classes;
using BindingModels;
//This class has been modified to only use Mixbook end points and what pertains to Mixbook and uses xml not json
namespace RESTModule {
    public class RESTAPIInit {
        public string BaseURL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiName { get; set; }
        public string AuthHeaderName { get; set; }
        //AuthHeaderValue must be formatted from calling function if using username/password:
        //var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(Username + ":" + Password));
        //string.Format("Basic {0}", credentials)
        public Uri CookieURI { get; set; }
        public Cookie CookieValue { get; set; }
        public AuthenticationHeaderValue AuthHeaderValue { get; set; }
        public string AuthHeaderString { get; set; }
        public List<Header> AdditionalHeaders { get; set; }
    }
    public class RESTAPIResult {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string APIResult { get; set; }
    }
    public class RESTService {
        private string BaseURL { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string ApiName { get; set; }
        private string AuthHeaderName { get; set; }
        private AuthenticationHeaderValue AuthHeaderValue { get; set; }
        private string AuthHeaderString { get; set; }
        private List<Header> AdditionalHeaders { get; set; }
        public Uri CookieURI { get; set; }
        private Cookie CookieValue { get; set; }
        private string ContentType { get; set; }
        private string EndPoint { get; set; } =ConfigurationManager.AppSettings["MixBookEndPoint"].ToString();

        public RESTService(bool isPitney = false,string token="") {
            if (isPitney)
            {
                if (!string.IsNullOrEmpty(token)) {
                    AuthHeaderName = "Authorization";
                    AuthHeaderString = "Basic " + token;
                }
               
            }
        }

      

        public async Task<ApiProcessingResult<RESTAPIResult>> MakeRESTCall(string actionType=default(string), string sentRequestData=default(string), List<Header> headers =default(List<Header>),string vEndPoint="",string vContentType= "application/xml") {
            var result = new ApiProcessingResult<RESTAPIResult> { IsError = false, Data = new RESTAPIResult() };
            this.AdditionalHeaders = headers;
            this.ContentType = vContentType;
            if (!string.IsNullOrEmpty(vEndPoint))
            {
                this.EndPoint = vEndPoint;
            }
            var logData = new LogMetadata()
            {
                RequestContent = sentRequestData,
                RequestMethod = actionType,
                RequestTimestamp = DateTime.Now,
                RequestUri = EndPoint,
                Source="RestApiCall"
            };
   
            try {
                var cookieContainer = new CookieContainer();
               
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                using (var httpClient = new HttpClient(handler) { BaseAddress = new Uri(EndPoint) }) {
                    if (!string.IsNullOrEmpty(AuthHeaderName) && AuthHeaderValue != null) { httpClient.DefaultRequestHeaders.Add(AuthHeaderName, AuthHeaderValue.ToString()); }
                    if (!string.IsNullOrEmpty(AuthHeaderName) && AuthHeaderString != null) { httpClient.DefaultRequestHeaders.Add(AuthHeaderName, AuthHeaderString); }

                    if (AdditionalHeaders != null) {
                        foreach (Header header in AdditionalHeaders) {
                            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                        }
                    }

                    if (CookieURI != null && CookieValue != null) {
                        cookieContainer.Add(CookieURI, CookieValue);
                    }
                    
                

                    var requestData = new StringContent(sentRequestData,Encoding.UTF8, this.ContentType);
                    var apiResponse = new HttpResponseMessage();
                    if (actionType.ToUpper() == "POST") {
                        
                            apiResponse = await httpClient.PostAsync(EndPoint, requestData);
                        
                    } else if (actionType.ToUpper() == "DELETE") {
                        apiResponse = await httpClient.DeleteAsync(EndPoint);
                    } else {
                        apiResponse = await httpClient.GetAsync(EndPoint);
                    }

                        var responseContent = "";
                        if (apiResponse.StatusCode == HttpStatusCode.Unauthorized) {
                            result.IsError = true;
                            result.Errors.Add(new ApiProcessingError("An error occurred API (Unauthorized). Please try again, if error persists contact support", "An error occurred calling  API (Unauthorized). Please try again, if error persists contact support", "401"));
                        logData.ResponseStatusCode = apiResponse.StatusCode;
                        logData.ResponseContent = "An error occurred API (Unauthorized). Please try again, if error persists contact support";
                        logData.ResponseTimestamp = DateTime.Now;
                    } else if (apiResponse.StatusCode == HttpStatusCode.BadRequest) {
                        responseContent = await apiResponse.Content.ReadAsStringAsync();
                        result.IsError = true;
                            result.Errors.Add(new ApiProcessingError("An error occurred calling  API (Bad request). Please try again, if error persists contact support", "An error occurred calling  API (Bad request). Please try again, if error persists contact support", "400"));
                        logData.ResponseStatusCode = apiResponse.StatusCode;
                        logData.ResponseContent = "An error occurred calling  API (Bad request), if error persists contact support";
                        logData.ResponseTimestamp = DateTime.Now;
                    } else if (apiResponse.StatusCode == HttpStatusCode.InternalServerError) {
                            result.IsError = true;
                            result.Errors.Add(new ApiProcessingError("An error occurred calling  API (External API error). Please try again, if error persists contact support", "An error occurred calling  API (External API error). Please try again, if error persists contact support", "500"));
                        if (apiResponse.Content != null)
                        {
                            logData.ResponseContent = await apiResponse.Content.ReadAsStringAsync();
                            result.Data.APIResult = responseContent;
                          

                        }
                        else
                        {
                            logData.ResponseContent = "An error occurred calling  API(External API error). if error persists contact support ";
                        }
                        logData.ResponseStatusCode = apiResponse.StatusCode;
                        logData.ResponseTimestamp = DateTime.Now;
                    } else if (!apiResponse.IsSuccessStatusCode) {
                            result.IsError = true;
                            if (apiResponse.Content != null)
                            {
                               responseContent = await apiResponse.Content.ReadAsStringAsync();
                            result.Data.APIResult = responseContent;
                            logData.ResponseStatusCode = apiResponse.StatusCode;
                            logData.ResponseContent = responseContent;
                            logData.ResponseTimestamp = DateTime.Now;
                        }
                       
                            result.Errors.Add(new ApiProcessingError("An error occurred calling  API (Unsuccessful Status Code -  Response: " + responseContent, "An error occurred calling  API (Unsuccessful Response - " + apiResponse.StatusCode + "). Please try again, if error persists contact support", ""));
                        } else if (apiResponse.Content == null) {
                            result.Data.IsError = true;
                            result.Data.ErrorMessage = "An error occurred calling  API (No data). Please try again, if error persists contact support";
                        } else {
                        //good calll 200
                            responseContent = await apiResponse.Content.ReadAsStringAsync();
                            responseContent = responseContent.Trim();
                            result.Data.APIResult = responseContent;
                        logData.ResponseStatusCode = apiResponse.StatusCode;
                        logData.ResponseContent = responseContent;
                        logData.ResponseTimestamp = DateTime.Now;
                    }
                    }
                } catch (WebException exception) {
                string responseText;

                using (var reader = new StreamReader(exception.Response.GetResponseStream())) {
                    responseText = reader.ReadToEnd();
                }
                //exception.ToExceptionless()
                //    .SetMessage("Error calling " + ApiName  +":"+ responseText)
                //    .MarkAsCritical()
                //    .Submit();
                result.IsError = true;
                result.Data.IsError = false;
                result.Errors.Add(new ApiProcessingError("Error calling   API - " + responseText, "Error calling  API - " + responseText, ""));
              
            } catch (Exception ex) {
                //ex.ToExceptionless()
                //   .SetMessage("Error calling " + ApiName )
                //   .MarkAsCritical()
                //   .Submit();
                result.IsError = true;
                result.Data.IsError = false;
                result.Errors.Add(new ApiProcessingError("Error calling  API", "Error calling  API", ""));

            }
            LogData(logData);
            return result;
        }
        private bool LogData(LogMetadata logMetadata)
        {
            var sqlClient = new SQLCustomClient();
            sqlClient.CommandText(@"INSERT INTO [dbo].[ApiLog]
           ([RequestContentType]
           ,[RequestUri]
           ,[RequestMethod]
           ,[RequestContent]
           ,[RequestTimeStamp]
           ,[ResponseTimeStamp]
           ,[ResponseContentType]
           ,[ResponseContent]
           ,[ResponseStatusCode]
            ,[Source]
           
            ) VALUES
           (@RequestContentType
            ,@RequestUri
            ,@RequestMethod
            ,@RequestContent
            ,@RequestTimeStamp
            ,@ResponseTimeStamp
            ,@ResponseContentType
            ,@ResponseContent
            ,@ResponseStatusCode
            ,@Source
            )");

            sqlClient.AddParameter("@RequestContentType", logMetadata.RequestContentType);
            sqlClient.AddParameter("@RequestUri", logMetadata.RequestUri);
            sqlClient.AddParameter("@RequestMethod", logMetadata.RequestMethod);
            sqlClient.AddParameter("@RequestContent", logMetadata.RequestContent);
            sqlClient.AddParameter("@RequestTimeStamp", logMetadata.RequestTimestamp);
            sqlClient.AddParameter("@ResponseTimeStamp", logMetadata.ResponseTimestamp);
            sqlClient.AddParameter("@ResponseContentType", logMetadata.ResponseContentType);
            sqlClient.AddParameter("@ResponseContent", logMetadata.ResponseContent);
            sqlClient.AddParameter("@ResponseStatusCode", logMetadata.ResponseStatusCode);
            sqlClient.AddParameter("@Source", logMetadata.Source);
            var result = sqlClient.Insert();
            if (result.IsError)
            {

            }
            return true;
        }
    }
public class Header
{
    public string Key { get; set; }
    public string Value { get; set; }
}
}
