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
    /// ParcelProtectionQuoteRequestShipmentInfo
    /// </summary>
    [DataContract]
    public partial class ParcelProtectionQuoteRequestShipmentInfo :  IEquatable<ParcelProtectionQuoteRequestShipmentInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelProtectionQuoteRequestShipmentInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ParcelProtectionQuoteRequestShipmentInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ParcelProtectionQuoteRequestShipmentInfo" /> class.
        /// </summary>
        /// <param name="carrier">carrier (required).</param>
        /// <param name="serviceId">serviceId (required).</param>
        /// <param name="insuranceCoverageValue">insuranceCoverageValue (required).</param>
        /// <param name="insuranceCoverageValueCurrency">insuranceCoverageValueCurrency (required).</param>
        /// <param name="parcelInfo">parcelInfo (required).</param>
        /// <param name="shipperInfo">shipperInfo (required).</param>
        /// <param name="consigneeInfo">consigneeInfo (required).</param>
        public ParcelProtectionQuoteRequestShipmentInfo(string carrier = default(string), string serviceId = default(string), int insuranceCoverageValue = default(int), string insuranceCoverageValueCurrency = default(string), ParcelProtectionQuoteRequestShipmentInfoParcelInfo parcelInfo = default(ParcelProtectionQuoteRequestShipmentInfoParcelInfo), ParcelProtectionQuoteRequestShipmentInfoShipperInfo shipperInfo = default(ParcelProtectionQuoteRequestShipmentInfoShipperInfo), ParcelProtectionQuoteRequestShipmentInfoConsigneeInfo consigneeInfo = default(ParcelProtectionQuoteRequestShipmentInfoConsigneeInfo))
        {
            // to ensure "carrier" is required (not null)
            if (carrier == null)
            {
                throw new InvalidDataException("carrier is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.Carrier = carrier;
            }
            
            // to ensure "serviceId" is required (not null)
            if (serviceId == null)
            {
                throw new InvalidDataException("serviceId is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.ServiceId = serviceId;
            }
            
            // to ensure "insuranceCoverageValue" is required (not null)
            if (insuranceCoverageValue == null)
            {
                throw new InvalidDataException("insuranceCoverageValue is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.InsuranceCoverageValue = insuranceCoverageValue;
            }
            
            // to ensure "insuranceCoverageValueCurrency" is required (not null)
            if (insuranceCoverageValueCurrency == null)
            {
                throw new InvalidDataException("insuranceCoverageValueCurrency is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.InsuranceCoverageValueCurrency = insuranceCoverageValueCurrency;
            }
            
            // to ensure "parcelInfo" is required (not null)
            if (parcelInfo == null)
            {
                throw new InvalidDataException("parcelInfo is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.ParcelInfo = parcelInfo;
            }
            
            // to ensure "shipperInfo" is required (not null)
            if (shipperInfo == null)
            {
                throw new InvalidDataException("shipperInfo is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.ShipperInfo = shipperInfo;
            }
            
            // to ensure "consigneeInfo" is required (not null)
            if (consigneeInfo == null)
            {
                throw new InvalidDataException("consigneeInfo is a required property for ParcelProtectionQuoteRequestShipmentInfo and cannot be null");
            }
            else
            {
                this.ConsigneeInfo = consigneeInfo;
            }
            
        }
        
        /// <summary>
        /// Gets or Sets Carrier
        /// </summary>
        [DataMember(Name="carrier", EmitDefaultValue=true)]
        public string Carrier { get; set; }

        /// <summary>
        /// Gets or Sets ServiceId
        /// </summary>
        [DataMember(Name="serviceId", EmitDefaultValue=true)]
        public string ServiceId { get; set; }

        /// <summary>
        /// Gets or Sets InsuranceCoverageValue
        /// </summary>
        [DataMember(Name="insuranceCoverageValue", EmitDefaultValue=true)]
        public int InsuranceCoverageValue { get; set; }

        /// <summary>
        /// Gets or Sets InsuranceCoverageValueCurrency
        /// </summary>
        [DataMember(Name="insuranceCoverageValueCurrency", EmitDefaultValue=true)]
        public string InsuranceCoverageValueCurrency { get; set; }

        /// <summary>
        /// Gets or Sets ParcelInfo
        /// </summary>
        [DataMember(Name="parcelInfo", EmitDefaultValue=true)]
        public ParcelProtectionQuoteRequestShipmentInfoParcelInfo ParcelInfo { get; set; }

        /// <summary>
        /// Gets or Sets ShipperInfo
        /// </summary>
        [DataMember(Name="shipperInfo", EmitDefaultValue=true)]
        public ParcelProtectionQuoteRequestShipmentInfoShipperInfo ShipperInfo { get; set; }

        /// <summary>
        /// Gets or Sets ConsigneeInfo
        /// </summary>
        [DataMember(Name="consigneeInfo", EmitDefaultValue=true)]
        public ParcelProtectionQuoteRequestShipmentInfoConsigneeInfo ConsigneeInfo { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ParcelProtectionQuoteRequestShipmentInfo {\n");
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
            return this.Equals(input as ParcelProtectionQuoteRequestShipmentInfo);
        }

        /// <summary>
        /// Returns true if ParcelProtectionQuoteRequestShipmentInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of ParcelProtectionQuoteRequestShipmentInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ParcelProtectionQuoteRequestShipmentInfo input)
        {
            if (input == null)
                return false;

            return 
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
