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
    /// CarrierRule
    /// </summary>
    [DataContract]
    public partial class CarrierRule :  IEquatable<CarrierRule>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets ServiceId
        /// </summary>
        [DataMember(Name="serviceId", EmitDefaultValue=false)]
        public Services? ServiceId { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierRule" /> class.
        /// </summary>
        /// <param name="serviceId">serviceId.</param>
        /// <param name="brandedName">brandedName.</param>
        /// <param name="parcelTypeRules">parcelTypeRules.</param>
        /// <param name="parameters">parameters.</param>
        public CarrierRule(Services? serviceId = default(Services?), string brandedName = default(string), List<ParcelTypeRules> parcelTypeRules = default(List<ParcelTypeRules>), List<string> parameters = default(List<string>))
        {
            this.ServiceId = serviceId;
            this.BrandedName = brandedName;
            this.ParcelTypeRules = parcelTypeRules;
            this.Parameters = parameters;
        }
        

        /// <summary>
        /// Gets or Sets BrandedName
        /// </summary>
        [DataMember(Name="brandedName", EmitDefaultValue=false)]
        public string BrandedName { get; set; }

        /// <summary>
        /// Gets or Sets ParcelTypeRules
        /// </summary>
        [DataMember(Name="parcelTypeRules", EmitDefaultValue=false)]
        public List<ParcelTypeRules> ParcelTypeRules { get; set; }

        /// <summary>
        /// Gets or Sets Parameters
        /// </summary>
        [DataMember(Name="parameters", EmitDefaultValue=false)]
        public List<string> Parameters { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CarrierRule {\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  BrandedName: ").Append(BrandedName).Append("\n");
            sb.Append("  ParcelTypeRules: ").Append(ParcelTypeRules).Append("\n");
            sb.Append("  Parameters: ").Append(Parameters).Append("\n");
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
            return this.Equals(input as CarrierRule);
        }

        /// <summary>
        /// Returns true if CarrierRule instances are equal
        /// </summary>
        /// <param name="input">Instance of CarrierRule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CarrierRule input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ServiceId == input.ServiceId ||
                    (this.ServiceId != null &&
                    this.ServiceId.Equals(input.ServiceId))
                ) && 
                (
                    this.BrandedName == input.BrandedName ||
                    (this.BrandedName != null &&
                    this.BrandedName.Equals(input.BrandedName))
                ) && 
                (
                    this.ParcelTypeRules == input.ParcelTypeRules ||
                    this.ParcelTypeRules != null &&
                    input.ParcelTypeRules != null &&
                    this.ParcelTypeRules.SequenceEqual(input.ParcelTypeRules)
                ) && 
                (
                    this.Parameters == input.Parameters ||
                    this.Parameters != null &&
                    input.Parameters != null &&
                    this.Parameters.SequenceEqual(input.Parameters)
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
                if (this.ServiceId != null)
                    hashCode = hashCode * 59 + this.ServiceId.GetHashCode();
                if (this.BrandedName != null)
                    hashCode = hashCode * 59 + this.BrandedName.GetHashCode();
                if (this.ParcelTypeRules != null)
                    hashCode = hashCode * 59 + this.ParcelTypeRules.GetHashCode();
                if (this.Parameters != null)
                    hashCode = hashCode * 59 + this.Parameters.GetHashCode();
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
