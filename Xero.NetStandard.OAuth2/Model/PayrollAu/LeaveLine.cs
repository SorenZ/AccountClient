/* 
 * Xero Payroll AU
 *
 * This is the Xero Payroll API for orgs in Australia region.
 *
 * The version of the OpenAPI document: 2.2.14
 * Contact: api@xero.com
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
using OpenAPIDateConverter = Xero.NetStandard.OAuth2.Client.OpenAPIDateConverter;

namespace Xero.NetStandard.OAuth2.Model.PayrollAu
{
    /// <summary>
    /// LeaveLine
    /// </summary>
    [DataContract]
    public partial class LeaveLine :  IEquatable<LeaveLine>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets CalculationType
        /// </summary>
        [DataMember(Name="CalculationType", EmitDefaultValue=false)]
        public LeaveLineCalculationType CalculationType { get; set; }
        /// <summary>
        /// Gets or Sets EntitlementFinalPayPayoutType
        /// </summary>
        [DataMember(Name="EntitlementFinalPayPayoutType", EmitDefaultValue=false)]
        public EntitlementFinalPayPayoutType EntitlementFinalPayPayoutType { get; set; }
        /// <summary>
        /// Gets or Sets EmploymentTerminationPaymentType
        /// </summary>
        [DataMember(Name="EmploymentTerminationPaymentType", EmitDefaultValue=false)]
        public EmploymentTerminationPaymentType EmploymentTerminationPaymentType { get; set; }
        
        /// <summary>
        /// Xero leave type identifier
        /// </summary>
        /// <value>Xero leave type identifier</value>
        [DataMember(Name="LeaveTypeID", EmitDefaultValue=false)]
        public Guid? LeaveTypeID { get; set; }

        /// <summary>
        /// amount of leave line
        /// </summary>
        /// <value>amount of leave line</value>
        [DataMember(Name="IncludeSuperannuationGuaranteeContribution", EmitDefaultValue=false)]
        public bool? IncludeSuperannuationGuaranteeContribution { get; set; }

        /// <summary>
        /// Leave number of units
        /// </summary>
        /// <value>Leave number of units</value>
        [DataMember(Name="NumberOfUnits", EmitDefaultValue=false)]
        public decimal? NumberOfUnits { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class LeaveLine {\n");
            sb.Append("  LeaveTypeID: ").Append(LeaveTypeID).Append("\n");
            sb.Append("  CalculationType: ").Append(CalculationType).Append("\n");
            sb.Append("  EntitlementFinalPayPayoutType: ").Append(EntitlementFinalPayPayoutType).Append("\n");
            sb.Append("  EmploymentTerminationPaymentType: ").Append(EmploymentTerminationPaymentType).Append("\n");
            sb.Append("  IncludeSuperannuationGuaranteeContribution: ").Append(IncludeSuperannuationGuaranteeContribution).Append("\n");
            sb.Append("  NumberOfUnits: ").Append(NumberOfUnits).Append("\n");
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
            return this.Equals(input as LeaveLine);
        }

        /// <summary>
        /// Returns true if LeaveLine instances are equal
        /// </summary>
        /// <param name="input">Instance of LeaveLine to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(LeaveLine input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.LeaveTypeID == input.LeaveTypeID ||
                    (this.LeaveTypeID != null &&
                    this.LeaveTypeID.Equals(input.LeaveTypeID))
                ) && 
                (
                    this.CalculationType == input.CalculationType ||
                    this.CalculationType.Equals(input.CalculationType)
                ) && 
                (
                    this.EntitlementFinalPayPayoutType == input.EntitlementFinalPayPayoutType ||
                    this.EntitlementFinalPayPayoutType.Equals(input.EntitlementFinalPayPayoutType)
                ) && 
                (
                    this.EmploymentTerminationPaymentType == input.EmploymentTerminationPaymentType ||
                    this.EmploymentTerminationPaymentType.Equals(input.EmploymentTerminationPaymentType)
                ) && 
                (
                    this.IncludeSuperannuationGuaranteeContribution == input.IncludeSuperannuationGuaranteeContribution ||
                    this.IncludeSuperannuationGuaranteeContribution.Equals(input.IncludeSuperannuationGuaranteeContribution)
                ) && 
                (
                    this.NumberOfUnits == input.NumberOfUnits ||
                    this.NumberOfUnits.Equals(input.NumberOfUnits)
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
                if (this.LeaveTypeID != null)
                    hashCode = hashCode * 59 + this.LeaveTypeID.GetHashCode();
                hashCode = hashCode * 59 + this.CalculationType.GetHashCode();
                hashCode = hashCode * 59 + this.EntitlementFinalPayPayoutType.GetHashCode();
                hashCode = hashCode * 59 + this.EmploymentTerminationPaymentType.GetHashCode();
                hashCode = hashCode * 59 + this.IncludeSuperannuationGuaranteeContribution.GetHashCode();
                hashCode = hashCode * 59 + this.NumberOfUnits.GetHashCode();
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
