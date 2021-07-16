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
    /// SchedulePickup
    /// </summary>
    [DataContract]
    public partial class SchedulePickup :  IEquatable<SchedulePickup>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchedulePickup" /> class.
        /// </summary>
        /// <param name="pickupAddress">pickupAddress.</param>
        /// <param name="carrier">carrier.</param>
        /// <param name="pickupSummary">pickupSummary.</param>
        /// <param name="reference">reference.</param>
        /// <param name="packageLocation">packageLocation.</param>
        /// <param name="specialInstructions">specialInstructions.</param>
        public SchedulePickup(Address pickupAddress = default(Address), string carrier = default(string), List<SchedulePickupPickupSummary> pickupSummary = default(List<SchedulePickupPickupSummary>), string reference = default(string), string packageLocation = default(string), string specialInstructions = default(string))
        {
            this.PickupAddress = pickupAddress;
            this.Carrier = carrier;
            this.PickupSummary = pickupSummary;
            this.Reference = reference;
            this.PackageLocation = packageLocation;
            this.SpecialInstructions = specialInstructions;
        }
        
        /// <summary>
        /// Gets or Sets PickupAddress
        /// </summary>
        [DataMember(Name="pickupAddress", EmitDefaultValue=false)]
        public Address PickupAddress { get; set; }

        /// <summary>
        /// Gets or Sets Carrier
        /// </summary>
        [DataMember(Name="carrier", EmitDefaultValue=false)]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or Sets PickupSummary
        /// </summary>
        [DataMember(Name="pickupSummary", EmitDefaultValue=false)]
        public List<SchedulePickupPickupSummary> PickupSummary { get; set; }

        /// <summary>
        /// Gets or Sets Reference
        /// </summary>
        [DataMember(Name="reference", EmitDefaultValue=false)]
        public string Reference { get; set; }

        /// <summary>
        /// Gets or Sets PackageLocation
        /// </summary>
        [DataMember(Name="packageLocation", EmitDefaultValue=false)]
        public string PackageLocation { get; set; }

        /// <summary>
        /// Gets or Sets SpecialInstructions
        /// </summary>
        [DataMember(Name="specialInstructions", EmitDefaultValue=false)]
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SchedulePickup {\n");
            sb.Append("  PickupAddress: ").Append(PickupAddress).Append("\n");
            sb.Append("  Carrier: ").Append(Carrier).Append("\n");
            sb.Append("  PickupSummary: ").Append(PickupSummary).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  PackageLocation: ").Append(PackageLocation).Append("\n");
            sb.Append("  SpecialInstructions: ").Append(SpecialInstructions).Append("\n");
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
            return this.Equals(input as SchedulePickup);
        }

        /// <summary>
        /// Returns true if SchedulePickup instances are equal
        /// </summary>
        /// <param name="input">Instance of SchedulePickup to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SchedulePickup input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PickupAddress == input.PickupAddress ||
                    (this.PickupAddress != null &&
                    this.PickupAddress.Equals(input.PickupAddress))
                ) && 
                (
                    this.Carrier == input.Carrier ||
                    (this.Carrier != null &&
                    this.Carrier.Equals(input.Carrier))
                ) && 
                (
                    this.PickupSummary == input.PickupSummary ||
                    this.PickupSummary != null &&
                    input.PickupSummary != null &&
                    this.PickupSummary.SequenceEqual(input.PickupSummary)
                ) && 
                (
                    this.Reference == input.Reference ||
                    (this.Reference != null &&
                    this.Reference.Equals(input.Reference))
                ) && 
                (
                    this.PackageLocation == input.PackageLocation ||
                    (this.PackageLocation != null &&
                    this.PackageLocation.Equals(input.PackageLocation))
                ) && 
                (
                    this.SpecialInstructions == input.SpecialInstructions ||
                    (this.SpecialInstructions != null &&
                    this.SpecialInstructions.Equals(input.SpecialInstructions))
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
                if (this.PickupAddress != null)
                    hashCode = hashCode * 59 + this.PickupAddress.GetHashCode();
                if (this.Carrier != null)
                    hashCode = hashCode * 59 + this.Carrier.GetHashCode();
                if (this.PickupSummary != null)
                    hashCode = hashCode * 59 + this.PickupSummary.GetHashCode();
                if (this.Reference != null)
                    hashCode = hashCode * 59 + this.Reference.GetHashCode();
                if (this.PackageLocation != null)
                    hashCode = hashCode * 59 + this.PackageLocation.GetHashCode();
                if (this.SpecialInstructions != null)
                    hashCode = hashCode * 59 + this.SpecialInstructions.GetHashCode();
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
