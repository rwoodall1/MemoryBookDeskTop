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
    /// CrossBorderQuotesRequestPricing
    /// </summary>
    [DataContract]
    public partial class CrossBorderQuotesRequestPricing :  IEquatable<CrossBorderQuotesRequestPricing>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossBorderQuotesRequestPricing" /> class.
        /// </summary>
        /// <param name="price">price.</param>
        /// <param name="codPrice">codPrice.</param>
        /// <param name="dutiableValue">dutiableValue.</param>
        public CrossBorderQuotesRequestPricing(int price = default(int), List<CrossBorderQuotesRequestPricingCodPrice> codPrice = default(List<CrossBorderQuotesRequestPricingCodPrice>), int dutiableValue = default(int))
        {
            this.Price = price;
            this.CodPrice = codPrice;
            this.DutiableValue = dutiableValue;
        }
        
        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public int Price { get; set; }

        /// <summary>
        /// Gets or Sets CodPrice
        /// </summary>
        [DataMember(Name="codPrice", EmitDefaultValue=false)]
        public List<CrossBorderQuotesRequestPricingCodPrice> CodPrice { get; set; }

        /// <summary>
        /// Gets or Sets DutiableValue
        /// </summary>
        [DataMember(Name="dutiableValue", EmitDefaultValue=false)]
        public int DutiableValue { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CrossBorderQuotesRequestPricing {\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  CodPrice: ").Append(CodPrice).Append("\n");
            sb.Append("  DutiableValue: ").Append(DutiableValue).Append("\n");
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
            return this.Equals(input as CrossBorderQuotesRequestPricing);
        }

        /// <summary>
        /// Returns true if CrossBorderQuotesRequestPricing instances are equal
        /// </summary>
        /// <param name="input">Instance of CrossBorderQuotesRequestPricing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CrossBorderQuotesRequestPricing input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Price == input.Price ||
                    (this.Price != null &&
                    this.Price.Equals(input.Price))
                ) && 
                (
                    this.CodPrice == input.CodPrice ||
                    this.CodPrice != null &&
                    input.CodPrice != null &&
                    this.CodPrice.SequenceEqual(input.CodPrice)
                ) && 
                (
                    this.DutiableValue == input.DutiableValue ||
                    (this.DutiableValue != null &&
                    this.DutiableValue.Equals(input.DutiableValue))
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
                if (this.Price != null)
                    hashCode = hashCode * 59 + this.Price.GetHashCode();
                if (this.CodPrice != null)
                    hashCode = hashCode * 59 + this.CodPrice.GetHashCode();
                if (this.DutiableValue != null)
                    hashCode = hashCode * 59 + this.DutiableValue.GetHashCode();
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
