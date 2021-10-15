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
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = pitneyBower.Client.OpenAPIDateConverter;

namespace pitneyBower.Model
{
    /// <summary>
    /// CrossBorderQuotesErrorsQuote
    /// </summary>
    [DataContract]
    public partial class CrossBorderQuotesErrorsQuote :  IEquatable<CrossBorderQuotesErrorsQuote>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossBorderQuotesErrorsQuote" /> class.
        /// </summary>
        /// <param name="quoteCurrency">quoteCurrency.</param>
        /// <param name="quoteLines">quoteLines.</param>
        /// <param name="errors">errors.</param>
        public CrossBorderQuotesErrorsQuote(string quoteCurrency = default(string), List<CrossBorderQuotesErrorsQuoteLines> quoteLines = default(List<CrossBorderQuotesErrorsQuoteLines>), CrossBorderQuotesErrorsErrors errors = default(CrossBorderQuotesErrorsErrors))
        {
            this.QuoteCurrency = quoteCurrency;
            this.QuoteLines = quoteLines;
            this.Errors = errors;
        }
        
        /// <summary>
        /// Gets or Sets QuoteCurrency
        /// </summary>
        [DataMember(Name="quoteCurrency", EmitDefaultValue=false)]
        public string QuoteCurrency { get; set; }

        /// <summary>
        /// Gets or Sets QuoteLines
        /// </summary>
        [DataMember(Name="quoteLines", EmitDefaultValue=false)]
        public List<CrossBorderQuotesErrorsQuoteLines> QuoteLines { get; set; }

        /// <summary>
        /// Gets or Sets Errors
        /// </summary>
        [DataMember(Name="errors", EmitDefaultValue=false)]
        public CrossBorderQuotesErrorsErrors Errors { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrossBorderQuotesErrorsQuote {\n");
            sb.Append("  QuoteCurrency: ").Append(QuoteCurrency).Append("\n");
            sb.Append("  QuoteLines: ").Append(QuoteLines).Append("\n");
            sb.Append("  Errors: ").Append(Errors).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as CrossBorderQuotesErrorsQuote);
        }

        /// <summary>
        /// Returns true if CrossBorderQuotesErrorsQuote instances are equal
        /// </summary>
        /// <param name="input">Instance of CrossBorderQuotesErrorsQuote to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrossBorderQuotesErrorsQuote input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.QuoteCurrency == input.QuoteCurrency ||
                    (this.QuoteCurrency != null &&
                    this.QuoteCurrency.Equals(input.QuoteCurrency))
                ) && 
                (
                    this.QuoteLines == input.QuoteLines ||
                    this.QuoteLines != null &&
                    input.QuoteLines != null &&
                    this.QuoteLines.SequenceEqual(input.QuoteLines)
                ) && 
                (
                    this.Errors == input.Errors ||
                    (this.Errors != null &&
                    this.Errors.Equals(input.Errors))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.QuoteCurrency != null)
                    hashCode = hashCode * 59 + this.QuoteCurrency.GetHashCode();
                if (this.QuoteLines != null)
                    hashCode = hashCode * 59 + this.QuoteLines.GetHashCode();
                if (this.Errors != null)
                    hashCode = hashCode * 59 + this.Errors.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
