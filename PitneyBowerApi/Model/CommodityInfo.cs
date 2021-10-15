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
    /// CommodityInfo
    /// </summary>
    [DataContract]
    public partial class CommodityInfo :  IEquatable<CommodityInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommodityInfo" /> class.
        /// </summary>
        /// <param name="cargoAirCraft">cargoAirCraft.</param>
        /// <param name="hazardClass">hazardClass.</param>
        /// <param name="infectiousSubstanceContact">infectiousSubstanceContact.</param>
        /// <param name="innerReceptaclesQuantity">innerReceptaclesQuantity.</param>
        /// <param name="innerReceptaclesQuantityUOM">innerReceptaclesQuantityUOM.</param>
        /// <param name="packagingGroup">packagingGroup.</param>
        /// <param name="packagingInstructions">packagingInstructions.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="properShippingName">properShippingName.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="quantityUOM">quantityUOM.</param>
        /// <param name="radioActivityDetail">radioActivityDetail.</param>
        /// <param name="radioNuclideDetail">radioNuclideDetail.</param>
        /// <param name="reportableQuantity">reportableQuantity.</param>
        /// <param name="technicalName">technicalName.</param>
        /// <param name="unId">unId.</param>
        public CommodityInfo(bool cargoAirCraft = default(bool), string hazardClass = default(string), InfectiousSubstanceContact infectiousSubstanceContact = default(InfectiousSubstanceContact), int innerReceptaclesQuantity = default(int), string innerReceptaclesQuantityUOM = default(string), string packagingGroup = default(string), string packagingInstructions = default(string), decimal percentage = default(decimal), string properShippingName = default(string), int quantity = default(int), string quantityUOM = default(string), RadioActivityDetail radioActivityDetail = default(RadioActivityDetail), RadioNuclideDetail radioNuclideDetail = default(RadioNuclideDetail), bool reportableQuantity = default(bool), string technicalName = default(string), string unId = default(string))
        {
            this.CargoAirCraft = cargoAirCraft;
            this.HazardClass = hazardClass;
            this.InfectiousSubstanceContact = infectiousSubstanceContact;
            this.InnerReceptaclesQuantity = innerReceptaclesQuantity;
            this.InnerReceptaclesQuantityUOM = innerReceptaclesQuantityUOM;
            this.PackagingGroup = packagingGroup;
            this.PackagingInstructions = packagingInstructions;
            this.Percentage = percentage;
            this.ProperShippingName = properShippingName;
            this.Quantity = quantity;
            this.QuantityUOM = quantityUOM;
            this.RadioActivityDetail = radioActivityDetail;
            this.RadioNuclideDetail = radioNuclideDetail;
            this.ReportableQuantity = reportableQuantity;
            this.TechnicalName = technicalName;
            this.UnId = unId;
        }
        
        /// <summary>
        /// Gets or Sets CargoAirCraft
        /// </summary>
        [DataMember(Name="cargoAirCraft", EmitDefaultValue=false)]
        public bool CargoAirCraft { get; set; }

        /// <summary>
        /// Gets or Sets HazardClass
        /// </summary>
        [DataMember(Name="hazardClass", EmitDefaultValue=false)]
        public string HazardClass { get; set; }

        /// <summary>
        /// Gets or Sets InfectiousSubstanceContact
        /// </summary>
        [DataMember(Name="infectiousSubstanceContact", EmitDefaultValue=false)]
        public InfectiousSubstanceContact InfectiousSubstanceContact { get; set; }

        /// <summary>
        /// Gets or Sets InnerReceptaclesQuantity
        /// </summary>
        [DataMember(Name="innerReceptaclesQuantity", EmitDefaultValue=false)]
        public int InnerReceptaclesQuantity { get; set; }

        /// <summary>
        /// Gets or Sets InnerReceptaclesQuantityUOM
        /// </summary>
        [DataMember(Name="innerReceptaclesQuantityUOM", EmitDefaultValue=false)]
        public string InnerReceptaclesQuantityUOM { get; set; }

        /// <summary>
        /// Gets or Sets PackagingGroup
        /// </summary>
        [DataMember(Name="packagingGroup", EmitDefaultValue=false)]
        public string PackagingGroup { get; set; }

        /// <summary>
        /// Gets or Sets PackagingInstructions
        /// </summary>
        [DataMember(Name="packagingInstructions", EmitDefaultValue=false)]
        public string PackagingInstructions { get; set; }

        /// <summary>
        /// Gets or Sets Percentage
        /// </summary>
        [DataMember(Name="percentage", EmitDefaultValue=false)]
        public decimal Percentage { get; set; }

        /// <summary>
        /// Gets or Sets ProperShippingName
        /// </summary>
        [DataMember(Name="properShippingName", EmitDefaultValue=false)]
        public string ProperShippingName { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name="quantity", EmitDefaultValue=false)]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or Sets QuantityUOM
        /// </summary>
        [DataMember(Name="quantityUOM", EmitDefaultValue=false)]
        public string QuantityUOM { get; set; }

        /// <summary>
        /// Gets or Sets RadioActivityDetail
        /// </summary>
        [DataMember(Name="radioActivityDetail", EmitDefaultValue=false)]
        public RadioActivityDetail RadioActivityDetail { get; set; }

        /// <summary>
        /// Gets or Sets RadioNuclideDetail
        /// </summary>
        [DataMember(Name="radioNuclideDetail", EmitDefaultValue=false)]
        public RadioNuclideDetail RadioNuclideDetail { get; set; }

        /// <summary>
        /// Gets or Sets ReportableQuantity
        /// </summary>
        [DataMember(Name="reportableQuantity", EmitDefaultValue=false)]
        public bool ReportableQuantity { get; set; }

        /// <summary>
        /// Gets or Sets TechnicalName
        /// </summary>
        [DataMember(Name="technicalName", EmitDefaultValue=false)]
        public string TechnicalName { get; set; }

        /// <summary>
        /// Gets or Sets UnId
        /// </summary>
        [DataMember(Name="unId", EmitDefaultValue=false)]
        public string UnId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CommodityInfo {\n");
            sb.Append("  CargoAirCraft: ").Append(CargoAirCraft).Append("\n");
            sb.Append("  HazardClass: ").Append(HazardClass).Append("\n");
            sb.Append("  InfectiousSubstanceContact: ").Append(InfectiousSubstanceContact).Append("\n");
            sb.Append("  InnerReceptaclesQuantity: ").Append(InnerReceptaclesQuantity).Append("\n");
            sb.Append("  InnerReceptaclesQuantityUOM: ").Append(InnerReceptaclesQuantityUOM).Append("\n");
            sb.Append("  PackagingGroup: ").Append(PackagingGroup).Append("\n");
            sb.Append("  PackagingInstructions: ").Append(PackagingInstructions).Append("\n");
            sb.Append("  Percentage: ").Append(Percentage).Append("\n");
            sb.Append("  ProperShippingName: ").Append(ProperShippingName).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  QuantityUOM: ").Append(QuantityUOM).Append("\n");
            sb.Append("  RadioActivityDetail: ").Append(RadioActivityDetail).Append("\n");
            sb.Append("  RadioNuclideDetail: ").Append(RadioNuclideDetail).Append("\n");
            sb.Append("  ReportableQuantity: ").Append(ReportableQuantity).Append("\n");
            sb.Append("  TechnicalName: ").Append(TechnicalName).Append("\n");
            sb.Append("  UnId: ").Append(UnId).Append("\n");
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
            return this.Equals(input as CommodityInfo);
        }

        /// <summary>
        /// Returns true if CommodityInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of CommodityInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CommodityInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CargoAirCraft == input.CargoAirCraft ||
                    (this.CargoAirCraft != null &&
                    this.CargoAirCraft.Equals(input.CargoAirCraft))
                ) && 
                (
                    this.HazardClass == input.HazardClass ||
                    (this.HazardClass != null &&
                    this.HazardClass.Equals(input.HazardClass))
                ) && 
                (
                    this.InfectiousSubstanceContact == input.InfectiousSubstanceContact ||
                    (this.InfectiousSubstanceContact != null &&
                    this.InfectiousSubstanceContact.Equals(input.InfectiousSubstanceContact))
                ) && 
                (
                    this.InnerReceptaclesQuantity == input.InnerReceptaclesQuantity ||
                    (this.InnerReceptaclesQuantity != null &&
                    this.InnerReceptaclesQuantity.Equals(input.InnerReceptaclesQuantity))
                ) && 
                (
                    this.InnerReceptaclesQuantityUOM == input.InnerReceptaclesQuantityUOM ||
                    (this.InnerReceptaclesQuantityUOM != null &&
                    this.InnerReceptaclesQuantityUOM.Equals(input.InnerReceptaclesQuantityUOM))
                ) && 
                (
                    this.PackagingGroup == input.PackagingGroup ||
                    (this.PackagingGroup != null &&
                    this.PackagingGroup.Equals(input.PackagingGroup))
                ) && 
                (
                    this.PackagingInstructions == input.PackagingInstructions ||
                    (this.PackagingInstructions != null &&
                    this.PackagingInstructions.Equals(input.PackagingInstructions))
                ) && 
                (
                    this.Percentage == input.Percentage ||
                    (this.Percentage != null &&
                    this.Percentage.Equals(input.Percentage))
                ) && 
                (
                    this.ProperShippingName == input.ProperShippingName ||
                    (this.ProperShippingName != null &&
                    this.ProperShippingName.Equals(input.ProperShippingName))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    (this.Quantity != null &&
                    this.Quantity.Equals(input.Quantity))
                ) && 
                (
                    this.QuantityUOM == input.QuantityUOM ||
                    (this.QuantityUOM != null &&
                    this.QuantityUOM.Equals(input.QuantityUOM))
                ) && 
                (
                    this.RadioActivityDetail == input.RadioActivityDetail ||
                    (this.RadioActivityDetail != null &&
                    this.RadioActivityDetail.Equals(input.RadioActivityDetail))
                ) && 
                (
                    this.RadioNuclideDetail == input.RadioNuclideDetail ||
                    (this.RadioNuclideDetail != null &&
                    this.RadioNuclideDetail.Equals(input.RadioNuclideDetail))
                ) && 
                (
                    this.ReportableQuantity == input.ReportableQuantity ||
                    (this.ReportableQuantity != null &&
                    this.ReportableQuantity.Equals(input.ReportableQuantity))
                ) && 
                (
                    this.TechnicalName == input.TechnicalName ||
                    (this.TechnicalName != null &&
                    this.TechnicalName.Equals(input.TechnicalName))
                ) && 
                (
                    this.UnId == input.UnId ||
                    (this.UnId != null &&
                    this.UnId.Equals(input.UnId))
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
                if (this.CargoAirCraft != null)
                    hashCode = hashCode * 59 + this.CargoAirCraft.GetHashCode();
                if (this.HazardClass != null)
                    hashCode = hashCode * 59 + this.HazardClass.GetHashCode();
                if (this.InfectiousSubstanceContact != null)
                    hashCode = hashCode * 59 + this.InfectiousSubstanceContact.GetHashCode();
                if (this.InnerReceptaclesQuantity != null)
                    hashCode = hashCode * 59 + this.InnerReceptaclesQuantity.GetHashCode();
                if (this.InnerReceptaclesQuantityUOM != null)
                    hashCode = hashCode * 59 + this.InnerReceptaclesQuantityUOM.GetHashCode();
                if (this.PackagingGroup != null)
                    hashCode = hashCode * 59 + this.PackagingGroup.GetHashCode();
                if (this.PackagingInstructions != null)
                    hashCode = hashCode * 59 + this.PackagingInstructions.GetHashCode();
                if (this.Percentage != null)
                    hashCode = hashCode * 59 + this.Percentage.GetHashCode();
                if (this.ProperShippingName != null)
                    hashCode = hashCode * 59 + this.ProperShippingName.GetHashCode();
                if (this.Quantity != null)
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                if (this.QuantityUOM != null)
                    hashCode = hashCode * 59 + this.QuantityUOM.GetHashCode();
                if (this.RadioActivityDetail != null)
                    hashCode = hashCode * 59 + this.RadioActivityDetail.GetHashCode();
                if (this.RadioNuclideDetail != null)
                    hashCode = hashCode * 59 + this.RadioNuclideDetail.GetHashCode();
                if (this.ReportableQuantity != null)
                    hashCode = hashCode * 59 + this.ReportableQuantity.GetHashCode();
                if (this.TechnicalName != null)
                    hashCode = hashCode * 59 + this.TechnicalName.GetHashCode();
                if (this.UnId != null)
                    hashCode = hashCode * 59 + this.UnId.GetHashCode();
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
