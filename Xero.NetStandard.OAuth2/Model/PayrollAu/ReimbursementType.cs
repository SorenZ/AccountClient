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
    /// ReimbursementType
    /// </summary>
    [DataContract]
    public partial class ReimbursementType :  IEquatable<ReimbursementType>, IValidatableObject
    {
        
        /// <summary>
        /// Name of the earnings rate (max length &#x3D; 100)
        /// </summary>
        /// <value>Name of the earnings rate (max length &#x3D; 100)</value>
        [DataMember(Name="Name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// See Accounts
        /// </summary>
        /// <value>See Accounts</value>
        [DataMember(Name="AccountCode", EmitDefaultValue=false)]
        public string AccountCode { get; set; }

        /// <summary>
        /// Xero identifier
        /// </summary>
        /// <value>Xero identifier</value>
        [DataMember(Name="ReimbursementTypeID", EmitDefaultValue=false)]
        public Guid? ReimbursementTypeID { get; set; }

        /// <summary>
        /// Last modified timestamp
        /// </summary>
        /// <value>Last modified timestamp</value>
        [DataMember(Name="UpdatedDateUTC", EmitDefaultValue=false)]
        public DateTime? UpdatedDateUTC { get; private set; }

        /// <summary>
        /// Is the current record
        /// </summary>
        /// <value>Is the current record</value>
        [DataMember(Name="CurrentRecord", EmitDefaultValue=false)]
        public bool? CurrentRecord { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReimbursementType {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  AccountCode: ").Append(AccountCode).Append("\n");
            sb.Append("  ReimbursementTypeID: ").Append(ReimbursementTypeID).Append("\n");
            sb.Append("  UpdatedDateUTC: ").Append(UpdatedDateUTC).Append("\n");
            sb.Append("  CurrentRecord: ").Append(CurrentRecord).Append("\n");
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
            return this.Equals(input as ReimbursementType);
        }

        /// <summary>
        /// Returns true if ReimbursementType instances are equal
        /// </summary>
        /// <param name="input">Instance of ReimbursementType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReimbursementType input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.AccountCode == input.AccountCode ||
                    (this.AccountCode != null &&
                    this.AccountCode.Equals(input.AccountCode))
                ) && 
                (
                    this.ReimbursementTypeID == input.ReimbursementTypeID ||
                    (this.ReimbursementTypeID != null &&
                    this.ReimbursementTypeID.Equals(input.ReimbursementTypeID))
                ) && 
                (
                    this.UpdatedDateUTC == input.UpdatedDateUTC ||
                    (this.UpdatedDateUTC != null &&
                    this.UpdatedDateUTC.Equals(input.UpdatedDateUTC))
                ) && 
                (
                    this.CurrentRecord == input.CurrentRecord ||
                    this.CurrentRecord.Equals(input.CurrentRecord)
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.AccountCode != null)
                    hashCode = hashCode * 59 + this.AccountCode.GetHashCode();
                if (this.ReimbursementTypeID != null)
                    hashCode = hashCode * 59 + this.ReimbursementTypeID.GetHashCode();
                if (this.UpdatedDateUTC != null)
                    hashCode = hashCode * 59 + this.UpdatedDateUTC.GetHashCode();
                hashCode = hashCode * 59 + this.CurrentRecord.GetHashCode();
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
            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 100.", new [] { "Name" });
            }

            yield break;
        }
    }

}
