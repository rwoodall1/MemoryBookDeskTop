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
    /// DimensionRules
    /// </summary>
    [DataContract]
    public partial class DimensionRules :  IEquatable<DimensionRules>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionRules" /> class.
        /// </summary>
        /// <param name="required">required.</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement.</param>
        /// <param name="minParcelDimensions">minParcelDimensions.</param>
        /// <param name="maxParcelDimensions">maxParcelDimensions.</param>
        /// <param name="minLengthPlusGirth">minLengthPlusGirth.</param>
        /// <param name="maxLengthPlusGirth">maxLengthPlusGirth.</param>
        public DimensionRules(bool required = default(bool), string unitOfMeasurement = default(string), DimensionRulesMinParcelDimensions minParcelDimensions = default(DimensionRulesMinParcelDimensions), DimensionRulesMaxParcelDimensions maxParcelDimensions = default(DimensionRulesMaxParcelDimensions), int minLengthPlusGirth = default(int), int maxLengthPlusGirth = default(int))
        {
            this.Required = required;
            this.UnitOfMeasurement = unitOfMeasurement;
            this.MinParcelDimensions = minParcelDimensions;
            this.MaxParcelDimensions = maxParcelDimensions;
            this.MinLengthPlusGirth = minLengthPlusGirth;
            this.MaxLengthPlusGirth = maxLengthPlusGirth;
        }
        
        /// <summary>
        /// Gets or Sets Required
        /// </summary>
        [DataMember(Name="required", EmitDefaultValue=false)]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or Sets UnitOfMeasurement
        /// </summary>
        [DataMember(Name="unitOfMeasurement", EmitDefaultValue=false)]
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Gets or Sets MinParcelDimensions
        /// </summary>
        [DataMember(Name="minParcelDimensions", EmitDefaultValue=false)]
        public DimensionRulesMinParcelDimensions MinParcelDimensions { get; set; }

        /// <summary>
        /// Gets or Sets MaxParcelDimensions
        /// </summary>
        [DataMember(Name="maxParcelDimensions", EmitDefaultValue=false)]
        public DimensionRulesMaxParcelDimensions MaxParcelDimensions { get; set; }

        /// <summary>
        /// Gets or Sets MinLengthPlusGirth
        /// </summary>
        [DataMember(Name="minLengthPlusGirth", EmitDefaultValue=false)]
        public int MinLengthPlusGirth { get; set; }

        /// <summary>
        /// Gets or Sets MaxLengthPlusGirth
        /// </summary>
        [DataMember(Name="maxLengthPlusGirth", EmitDefaultValue=false)]
        public int MaxLengthPlusGirth { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DimensionRules {\n");
            sb.Append("  Required: ").Append(Required).Append("\n");
            sb.Append("  UnitOfMeasurement: ").Append(UnitOfMeasurement).Append("\n");
            sb.Append("  MinParcelDimensions: ").Append(MinParcelDimensions).Append("\n");
            sb.Append("  MaxParcelDimensions: ").Append(MaxParcelDimensions).Append("\n");
            sb.Append("  MinLengthPlusGirth: ").Append(MinLengthPlusGirth).Append("\n");
            sb.Append("  MaxLengthPlusGirth: ").Append(MaxLengthPlusGirth).Append("\n");
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
            return this.Equals(input as DimensionRules);
        }

        /// <summary>
        /// Returns true if DimensionRules instances are equal
        /// </summary>
        /// <param name="input">Instance of DimensionRules to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DimensionRules input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Required == input.Required ||
                    (this.Required != null &&
                    this.Required.Equals(input.Required))
                ) && 
                (
                    this.UnitOfMeasurement == input.UnitOfMeasurement ||
                    (this.UnitOfMeasurement != null &&
                    this.UnitOfMeasurement.Equals(input.UnitOfMeasurement))
                ) && 
                (
                    this.MinParcelDimensions == input.MinParcelDimensions ||
                    (this.MinParcelDimensions != null &&
                    this.MinParcelDimensions.Equals(input.MinParcelDimensions))
                ) && 
                (
                    this.MaxParcelDimensions == input.MaxParcelDimensions ||
                    (this.MaxParcelDimensions != null &&
                    this.MaxParcelDimensions.Equals(input.MaxParcelDimensions))
                ) && 
                (
                    this.MinLengthPlusGirth == input.MinLengthPlusGirth ||
                    (this.MinLengthPlusGirth != null &&
                    this.MinLengthPlusGirth.Equals(input.MinLengthPlusGirth))
                ) && 
                (
                    this.MaxLengthPlusGirth == input.MaxLengthPlusGirth ||
                    (this.MaxLengthPlusGirth != null &&
                    this.MaxLengthPlusGirth.Equals(input.MaxLengthPlusGirth))
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
                if (this.Required != null)
                    hashCode = hashCode * 59 + this.Required.GetHashCode();
                if (this.UnitOfMeasurement != null)
                    hashCode = hashCode * 59 + this.UnitOfMeasurement.GetHashCode();
                if (this.MinParcelDimensions != null)
                    hashCode = hashCode * 59 + this.MinParcelDimensions.GetHashCode();
                if (this.MaxParcelDimensions != null)
                    hashCode = hashCode * 59 + this.MaxParcelDimensions.GetHashCode();
                if (this.MinLengthPlusGirth != null)
                    hashCode = hashCode * 59 + this.MinLengthPlusGirth.GetHashCode();
                if (this.MaxLengthPlusGirth != null)
                    hashCode = hashCode * 59 + this.MaxLengthPlusGirth.GetHashCode();
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
