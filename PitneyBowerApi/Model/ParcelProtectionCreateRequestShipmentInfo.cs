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
    /// ParcelProtectionCreateRequestShipmentInfo
    /// </summary>
    [DataContract]
    public partial class ParcelProtectionCreateRequestShipmentInfo :  IEquatable<ParcelProtectionCreateRequestShipmentInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelProtectionCreateRequestShipmentInfo" /> class.
        /// </summary>
        /// <param name="trackingNumber">trackingNumber.</param>
        /// <param name="carrier">carrier.</param>
        /// <param name="serviceId">serviceId.</param>
        /// <param name="insuranceCoverageValue">insuranceCoverageValue.</param>
        /// <param name="insuranceCoverageValueCurrency">insuranceCoverageValueCurrency.</param>
        /// <param name="parcelInfo">parcelInfo.</param>
        /// <param name="shipperInfo">shipperInfo.</param>
        /// <param name="consigneeInfo">consigneeInfo.</param>
        public ParcelProtectionCreateRequestShipmentInfo(string trackingNumber = default(string), string carrier = default(string), string serviceId = default(string), int insuranceCoverageValue = default(int), string insuranceCoverageValueCurrency = default(string), ParcelProtectionCreateRequestShipmentInfoParcelInfo parcelInfo = default(ParcelProtectionCreateRequestShipmentInfoParcelInfo), ParcelProtectionCreateRequestShipmentInfoShipperInfo shipperInfo = default(ParcelProtectionCreateRequestShipmentInfoShipperInfo), ParcelProtectionCreateRequestShipmentInfoConsigneeInfo consigneeInfo = default(ParcelProtectionCreateRequestShipmentInfoConsigneeInfo))
        {
            this.TrackingNumber = trackingNumber;
            this.Carrier = carrier;
            this.ServiceId = serviceId;
            this.InsuranceCoverageValue = insuranceCoverageValue;
            this.InsuranceCoverageValueCurrency = insuranceCoverageValueCurrency;
            this.ParcelInfo = parcelInfo;
            this.ShipperInfo = shipperInfo;
            this.ConsigneeInfo = consigneeInfo;
        }
        
        /// <summary>
        /// Gets or Sets TrackingNumber
        /// </summary>
        [DataMember(Name="trackingNumber", EmitDefaultValue=false)]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or Sets Carrier
        /// </summary>
        [DataMember(Name="carrier", EmitDefaultValue=false)]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or Sets ServiceId
        /// </summary>
        [DataMember(Name="serviceId", EmitDefaultValue=false)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or Sets InsuranceCoverageValue
        /// </summary>
        [DataMember(Name="insuranceCoverageValue", EmitDefaultValue=false)]
        public int InsuranceCoverageValue { get; set; }

        /// <summary>
        /// Gets or Sets InsuranceCoverageValueCurrency
        /// </summary>
        [DataMember(Name="insuranceCoverageValueCurrency", EmitDefaultValue=false)]
        public string InsuranceCoverageValueCurrency { get; set; }

        /// <summary>
        /// Gets or Sets ParcelInfo
        /// </summary>
        [DataMember(Name="parcelInfo", EmitDefaultValue=false)]
        public ParcelProtectionCreateRequestShipmentInfoParcelInfo ParcelInfo { get; set; }

        /// <summary>
        /// Gets or Sets ShipperInfo
        /// </summary>
        [DataMember(Name="shipperInfo", EmitDefaultValue=false)]
        public ParcelProtectionCreateRequestShipmentInfoShipperInfo ShipperInfo { get; set; }

        /// <summary>
        /// Gets or Sets ConsigneeInfo
        /// </summary>
        [DataMember(Name="consigneeInfo", EmitDefaultValue=false)]
        public ParcelProtectionCreateRequestShipmentInfoConsigneeInfo ConsigneeInfo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelProtectionCreateRequestShipmentInfo {\n");
            sb.Append("  TrackingNumber: ").Append(TrackingNumber).Append("\n");
            sb.Append("  Carrier: ").Append(Carrier).Append("\n");
            sb.Append("  ServiceId: ").Append(ServiceId).Append("\n");
            sb.Append("  InsuranceCoverageValue: ").Append(InsuranceCoverageValue).Append("\n");
            sb.Append("  InsuranceCoverageValueCurrency: ").Append(InsuranceCoverageValueCurrency).Append("\n");
            sb.Append("  ParcelInfo: ").Append(ParcelInfo).Append("\n");
            sb.Append("  ShipperInfo: ").Append(ShipperInfo).Append("\n");
            sb.Append("  ConsigneeInfo: ").Append(ConsigneeInfo).Append("\n");
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
            return this.Equals(input as ParcelProtectionCreateRequestShipmentInfo);
        }

        /// <summary>
        /// Returns true if ParcelProtectionCreateRequestShipmentInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelProtectionCreateRequestShipmentInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelProtectionCreateRequestShipmentInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TrackingNumber == input.TrackingNumber ||
                    (this.TrackingNumber != null &&
                    this.TrackingNumber.Equals(input.TrackingNumber))
                ) && 
                (
                    this.Carrier == input.Carrier ||
                    (this.Carrier != null &&
                    this.Carrier.Equals(input.Carrier))
                ) && 
                (
                    this.ServiceId == input.ServiceId ||
                    (this.ServiceId != null &&
                    this.ServiceId.Equals(input.ServiceId))
                ) && 
                (
                    this.InsuranceCoverageValue == input.InsuranceCoverageValue ||
                    (this.InsuranceCoverageValue != null &&
                    this.InsuranceCoverageValue.Equals(input.InsuranceCoverageValue))
                ) && 
                (
                    this.InsuranceCoverageValueCurrency == input.InsuranceCoverageValueCurrency ||
                    (this.InsuranceCoverageValueCurrency != null &&
                    this.InsuranceCoverageValueCurrency.Equals(input.InsuranceCoverageValueCurrency))
                ) && 
                (
                    this.ParcelInfo == input.ParcelInfo ||
                    (this.ParcelInfo != null &&
                    this.ParcelInfo.Equals(input.ParcelInfo))
                ) && 
                (
                    this.ShipperInfo == input.ShipperInfo ||
                    (this.ShipperInfo != null &&
                    this.ShipperInfo.Equals(input.ShipperInfo))
                ) && 
                (
                    this.ConsigneeInfo == input.ConsigneeInfo ||
                    (this.ConsigneeInfo != null &&
                    this.ConsigneeInfo.Equals(input.ConsigneeInfo))
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
                if (this.TrackingNumber != null)
                    hashCode = hashCode * 59 + this.TrackingNumber.GetHashCode();
                if (this.Carrier != null)
                    hashCode = hashCode * 59 + this.Carrier.GetHashCode();
                if (this.ServiceId != null)
                    hashCode = hashCode * 59 + this.ServiceId.GetHashCode();
                if (this.InsuranceCoverageValue != null)
                    hashCode = hashCode * 59 + this.InsuranceCoverageValue.GetHashCode();
                if (this.InsuranceCoverageValueCurrency != null)
                    hashCode = hashCode * 59 + this.InsuranceCoverageValueCurrency.GetHashCode();
                if (this.ParcelInfo != null)
                    hashCode = hashCode * 59 + this.ParcelInfo.GetHashCode();
                if (this.ShipperInfo != null)
                    hashCode = hashCode * 59 + this.ShipperInfo.GetHashCode();
                if (this.ConsigneeInfo != null)
                    hashCode = hashCode * 59 + this.ConsigneeInfo.GetHashCode();
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
