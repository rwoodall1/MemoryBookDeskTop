/* 
 * Shipping API
 *
 * Shipping API Sample.
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: support@pb.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using pitneyBower.Client;
using pitneyBower.Model;

namespace pitneyBower.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAddressValidationApi : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Address validation
        /// </summary>
        /// <remarks>
        /// Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Address</returns>
        Address VerifyAddress (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?));

        /// <summary>
        /// Address validation
        /// </summary>
        /// <remarks>
        /// Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>ApiResponse of Address</returns>
        ApiResponse<Address> VerifyAddressWithHttpInfo (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?));
        /// <summary>
        /// Address Suggestion
        /// </summary>
        /// <remarks>
        /// This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>AddressSuggestionResponse</returns>
        AddressSuggestionResponse VerifyAndSuggestAddress (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?));

        /// <summary>
        /// Address Suggestion
        /// </summary>
        /// <remarks>
        /// This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>ApiResponse of AddressSuggestionResponse</returns>
        ApiResponse<AddressSuggestionResponse> VerifyAndSuggestAddressWithHttpInfo (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?));
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// Address validation
        /// </summary>
        /// <remarks>
        /// Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Task of Address</returns>
        System.Threading.Tasks.Task<Address> VerifyAddressAsync (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?));

        /// <summary>
        /// Address validation
        /// </summary>
        /// <remarks>
        /// Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Task of ApiResponse (Address)</returns>
        System.Threading.Tasks.Task<ApiResponse<Address>> VerifyAddressAsyncWithHttpInfo (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?));
        /// <summary>
        /// Address Suggestion
        /// </summary>
        /// <remarks>
        /// This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>Task of AddressSuggestionResponse</returns>
        System.Threading.Tasks.Task<AddressSuggestionResponse> VerifyAndSuggestAddressAsync (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?));

        /// <summary>
        /// Address Suggestion
        /// </summary>
        /// <remarks>
        /// This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </remarks>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>Task of ApiResponse (AddressSuggestionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<AddressSuggestionResponse>> VerifyAndSuggestAddressAsyncWithHttpInfo (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AddressValidationApi : IAddressValidationApi
    {
        private pitneyBower.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AddressValidationApi(String basePath)
        {
            this.Configuration = new pitneyBower.Client.Configuration { BasePath = basePath };

            ExceptionFactory = pitneyBower.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidationApi"/> class
        /// </summary>
        /// <returns></returns>
        public AddressValidationApi()
        {
            this.Configuration = pitneyBower.Client.Configuration.Default;

            ExceptionFactory = pitneyBower.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidationApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AddressValidationApi(pitneyBower.Client.Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = pitneyBower.Client.Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = pitneyBower.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public pitneyBower.Client.Configuration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public pitneyBower.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        /// Address validation Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Address</returns>
        public Address VerifyAddress (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?))
        {
             ApiResponse<Address> localVarResponse = VerifyAddressWithHttpInfo(address, xPBUnifiedErrorStructure, minimalAddressValidation);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Address validation Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>ApiResponse of Address</returns>
        public ApiResponse<Address> VerifyAddressWithHttpInfo (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?))
        {
            // verify the required parameter 'address' is set
            if (address == null)
                throw new ApiException(400, "Missing required parameter 'address' when calling AddressValidationApi->VerifyAddress");

            var localVarPath = "/v1/addresses/verify";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (minimalAddressValidation != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "minimalAddressValidation", minimalAddressValidation)); // query parameter
            if (xPBUnifiedErrorStructure != null) localVarHeaderParams.Add("X-PB-UnifiedErrorStructure", this.Configuration.ApiClient.ParameterToString(xPBUnifiedErrorStructure)); // header parameter
            if (address != null && address.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(address); // http body (model) parameter
            }
            else
            {
                localVarPostBody = address; // byte array
            }

            // authentication (oAuth2ClientCredentials) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Address>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Address) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Address)));
        }

        /// <summary>
        /// Address validation Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Task of Address</returns>
        public async System.Threading.Tasks.Task<Address> VerifyAddressAsync (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?))
        {
             ApiResponse<Address> localVarResponse = await VerifyAddressAsyncWithHttpInfo(address, xPBUnifiedErrorStructure, minimalAddressValidation);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Address validation Address validation verifies and cleanses postal addresses within the United States to help ensure packages are rated accurately and shipments arrive at their final destinations on time.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="address">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <param name="minimalAddressValidation">When set to true, the complete address (delivery line and last line) is validated but only the last line (city, state, and postal code) would be changed by the validation check. (optional)</param>
        /// <returns>Task of ApiResponse (Address)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Address>> VerifyAddressAsyncWithHttpInfo (Address address, bool? xPBUnifiedErrorStructure = default(bool?), bool? minimalAddressValidation = default(bool?))
        {
            // verify the required parameter 'address' is set
            if (address == null)
                throw new ApiException(400, "Missing required parameter 'address' when calling AddressValidationApi->VerifyAddress");

            var localVarPath = "/v1/addresses/verify";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (minimalAddressValidation != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "minimalAddressValidation", minimalAddressValidation)); // query parameter
            if (xPBUnifiedErrorStructure != null) localVarHeaderParams.Add("X-PB-UnifiedErrorStructure", this.Configuration.ApiClient.ParameterToString(xPBUnifiedErrorStructure)); // header parameter
            if (address != null && address.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(address); // http body (model) parameter
            }
            else
            {
                localVarPostBody = address; // byte array
            }

            // authentication (oAuth2ClientCredentials) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<Address>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (Address) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(Address)));
        }

        /// <summary>
        /// Address Suggestion This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>AddressSuggestionResponse</returns>
        public AddressSuggestionResponse VerifyAndSuggestAddress (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?))
        {
             ApiResponse<AddressSuggestionResponse> localVarResponse = VerifyAndSuggestAddressWithHttpInfo(returnSuggestions, addressVerifySuggest, xPBUnifiedErrorStructure);
             return localVarResponse.Data;
        }

        /// <summary>
        /// Address Suggestion This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>ApiResponse of AddressSuggestionResponse</returns>
        public ApiResponse<AddressSuggestionResponse> VerifyAndSuggestAddressWithHttpInfo (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?))
        {
            // verify the required parameter 'returnSuggestions' is set
            if (returnSuggestions == null)
                throw new ApiException(400, "Missing required parameter 'returnSuggestions' when calling AddressValidationApi->VerifyAndSuggestAddress");
            // verify the required parameter 'addressVerifySuggest' is set
            if (addressVerifySuggest == null)
                throw new ApiException(400, "Missing required parameter 'addressVerifySuggest' when calling AddressValidationApi->VerifyAndSuggestAddress");

            var localVarPath = "/v1/addresses/verify-suggest";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (returnSuggestions != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "returnSuggestions", returnSuggestions)); // query parameter
            if (xPBUnifiedErrorStructure != null) localVarHeaderParams.Add("X-PB-UnifiedErrorStructure", this.Configuration.ApiClient.ParameterToString(xPBUnifiedErrorStructure)); // header parameter
            if (addressVerifySuggest != null && addressVerifySuggest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(addressVerifySuggest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = addressVerifySuggest; // byte array
            }

            // authentication (oAuth2ClientCredentials) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) this.Configuration.ApiClient.CallApi(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAndSuggestAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<AddressSuggestionResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (AddressSuggestionResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(AddressSuggestionResponse)));
        }

        /// <summary>
        /// Address Suggestion This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>Task of AddressSuggestionResponse</returns>
        public async System.Threading.Tasks.Task<AddressSuggestionResponse> VerifyAndSuggestAddressAsync (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?))
        {
             ApiResponse<AddressSuggestionResponse> localVarResponse = await VerifyAndSuggestAddressAsyncWithHttpInfo(returnSuggestions, addressVerifySuggest, xPBUnifiedErrorStructure);
             return localVarResponse.Data;

        }

        /// <summary>
        /// Address Suggestion This operation returns suggested addresses. Use this if the [Address Validation API](https://shipping.pitneybowes.com/api/post-address-verify.html) call has returned an error.
        /// </summary>
        /// <exception cref="pitneyBower.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="returnSuggestions">To return suggested addresses, set this to true.</param>
        /// <param name="addressVerifySuggest">Address object that needs to be validated.</param>
        /// <param name="xPBUnifiedErrorStructure">Set this to true to use the standard [error object](https://shipping.pitneybowes.com/reference/error-object.html#standard-error-object) if an error occurs. (optional, default to true)</param>
        /// <returns>Task of ApiResponse (AddressSuggestionResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<AddressSuggestionResponse>> VerifyAndSuggestAddressAsyncWithHttpInfo (string returnSuggestions, AddressVerifySuggest addressVerifySuggest, bool? xPBUnifiedErrorStructure = default(bool?))
        {
            // verify the required parameter 'returnSuggestions' is set
            if (returnSuggestions == null)
                throw new ApiException(400, "Missing required parameter 'returnSuggestions' when calling AddressValidationApi->VerifyAndSuggestAddress");
            // verify the required parameter 'addressVerifySuggest' is set
            if (addressVerifySuggest == null)
                throw new ApiException(400, "Missing required parameter 'addressVerifySuggest' when calling AddressValidationApi->VerifyAndSuggestAddress");

            var localVarPath = "/v1/addresses/verify-suggest";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
                "application/json"
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (returnSuggestions != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "returnSuggestions", returnSuggestions)); // query parameter
            if (xPBUnifiedErrorStructure != null) localVarHeaderParams.Add("X-PB-UnifiedErrorStructure", this.Configuration.ApiClient.ParameterToString(xPBUnifiedErrorStructure)); // header parameter
            if (addressVerifySuggest != null && addressVerifySuggest.GetType() != typeof(byte[]))
            {
                localVarPostBody = this.Configuration.ApiClient.Serialize(addressVerifySuggest); // http body (model) parameter
            }
            else
            {
                localVarPostBody = addressVerifySuggest; // byte array
            }

            // authentication (oAuth2ClientCredentials) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarHeaderParams["Authorization"] = "Bearer " + this.Configuration.AccessToken;
            }

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse) await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.POST, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int) localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("VerifyAndSuggestAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<AddressSuggestionResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (AddressSuggestionResponse) this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(AddressSuggestionResponse)));
        }

    }
}
