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
    /// CarrierFacilityResponseFacilityTimings
    /// </summary>
    [DataContract]
    public partial class CarrierFacilityResponseFacilityTimings :  IEquatable<CarrierFacilityResponseFacilityTimings>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierFacilityResponseFacilityTimings" /> class.
        /// </summary>
        /// <param name="closesAt">closesAt.</param>
        /// <param name="opensAt">opensAt.</param>
        public CarrierFacilityResponseFacilityTimings(string closesAt = default(string), string opensAt = default(string))
        {
            this.ClosesAt = closesAt;
            this.OpensAt = opensAt;
        }
        
        /// <summary>
        /// Gets or Sets ClosesAt
        /// </summary>
        [DataMember(Name="closesAt", EmitDefaultValue=false)]
        public string ClosesAt { get; set; }

        /// <summary>
        /// Gets or Sets OpensAt
        /// </summary>
        [DataMember(Name="opensAt", EmitDefaultValue=false)]
        public string OpensAt { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CarrierFacilityResponseFacilityTimings {\n");
            sb.Append("  ClosesAt: ").Append(ClosesAt).Append("\n");
            sb.Append("  OpensAt: ").Append(OpensAt).Append("\n");
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
            return this.Equals(input as CarrierFacilityResponseFacilityTimings);
        }

        /// <summary>
        /// Returns true if CarrierFacilityResponseFacilityTimings instances are equal
        /// </summary>
        /// <param name="input">Instance of CarrierFacilityResponseFacilityTimings to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CarrierFacilityResponseFacilityTimings input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ClosesAt == input.ClosesAt ||
                    (this.ClosesAt != null &&
                    this.ClosesAt.Equals(input.ClosesAt))
                ) && 
                (
                    this.OpensAt == input.OpensAt ||
                    (this.OpensAt != null &&
                    this.OpensAt.Equals(input.OpensAt))
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
                if (this.ClosesAt != null)
                    hashCode = hashCode * 59 + this.ClosesAt.GetHashCode();
                if (this.OpensAt != null)
                    hashCode = hashCode * 59 + this.OpensAt.GetHashCode();
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