/* 
 * Accounting API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
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

namespace Xero.NetStandard.OAuth2.Model.Accounting
{
    /// <summary>
    /// Receipt
    /// </summary>
    [DataContract]
    public partial class Receipt :  IEquatable<Receipt>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets LineAmountTypes
        /// </summary>
        [DataMember(Name="LineAmountTypes", EmitDefaultValue=false)]
        public LineAmountTypes LineAmountTypes { get; set; }
        /// <summary>
        /// Current status of receipt – see status types
        /// </summary>
        /// <value>Current status of receipt – see status types</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum DRAFT for value: DRAFT
            /// </summary>
            [EnumMember(Value = "DRAFT")]
            DRAFT = 1,

            /// <summary>
            /// Enum SUBMITTED for value: SUBMITTED
            /// </summary>
            [EnumMember(Value = "SUBMITTED")]
            SUBMITTED = 2,

            /// <summary>
            /// Enum AUTHORISED for value: AUTHORISED
            /// </summary>
            [EnumMember(Value = "AUTHORISED")]
            AUTHORISED = 3,

            /// <summary>
            /// Enum DECLINED for value: DECLINED
            /// </summary>
            [EnumMember(Value = "DECLINED")]
            DECLINED = 4,

            /// <summary>
            /// Enum VOIDED for value: VOIDED
            /// </summary>
            [EnumMember(Value = "VOIDED")]
            VOIDED = 5

        }

        /// <summary>
        /// Current status of receipt – see status types
        /// </summary>
        /// <value>Current status of receipt – see status types</value>
        [DataMember(Name="Status", EmitDefaultValue=false)]
        public StatusEnum Status { get; set; }
        
        /// <summary>
        /// Date of receipt – YYYY-MM-DD
        /// </summary>
        /// <value>Date of receipt – YYYY-MM-DD</value>
        [DataMember(Name="Date", EmitDefaultValue=false)]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or Sets Contact
        /// </summary>
        [DataMember(Name="Contact", EmitDefaultValue=false)]
        public Contact Contact { get; set; }

        /// <summary>
        /// Gets or Sets LineItems
        /// </summary>
        [DataMember(Name="LineItems", EmitDefaultValue=false)]
        public List<LineItem> LineItems { get; set; }

        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [DataMember(Name="User", EmitDefaultValue=false)]
        public User User { get; set; }

        /// <summary>
        /// Additional reference number
        /// </summary>
        /// <value>Additional reference number</value>
        [DataMember(Name="Reference", EmitDefaultValue=false)]
        public string Reference { get; set; }

        /// <summary>
        /// Total of receipt excluding taxes
        /// </summary>
        /// <value>Total of receipt excluding taxes</value>
        [DataMember(Name="SubTotal", EmitDefaultValue=false)]
        public decimal? SubTotal { get; set; }

        /// <summary>
        /// Total tax on receipt
        /// </summary>
        /// <value>Total tax on receipt</value>
        [DataMember(Name="TotalTax", EmitDefaultValue=false)]
        public decimal? TotalTax { get; set; }

        /// <summary>
        /// Total of receipt tax inclusive (i.e. SubTotal + TotalTax)
        /// </summary>
        /// <value>Total of receipt tax inclusive (i.e. SubTotal + TotalTax)</value>
        [DataMember(Name="Total", EmitDefaultValue=false)]
        public decimal? Total { get; set; }

        /// <summary>
        /// Xero generated unique identifier for receipt
        /// </summary>
        /// <value>Xero generated unique identifier for receipt</value>
        [DataMember(Name="ReceiptID", EmitDefaultValue=false)]
        public Guid? ReceiptID { get; set; }

        /// <summary>
        /// Xero generated sequence number for receipt in current claim for a given user
        /// </summary>
        /// <value>Xero generated sequence number for receipt in current claim for a given user</value>
        [DataMember(Name="ReceiptNumber", EmitDefaultValue=false)]
        public string ReceiptNumber { get; private set; }

        /// <summary>
        /// Last modified date UTC format
        /// </summary>
        /// <value>Last modified date UTC format</value>
        [DataMember(Name="UpdatedDateUTC", EmitDefaultValue=false)]
        public DateTime? UpdatedDateUTC { get; private set; }

        /// <summary>
        /// boolean to indicate if a receipt has an attachment
        /// </summary>
        /// <value>boolean to indicate if a receipt has an attachment</value>
        [DataMember(Name="HasAttachments", EmitDefaultValue=false)]
        public bool? HasAttachments { get; private set; }

        /// <summary>
        /// URL link to a source document – shown as “Go to [appName]” in the Xero app
        /// </summary>
        /// <value>URL link to a source document – shown as “Go to [appName]” in the Xero app</value>
        [DataMember(Name="Url", EmitDefaultValue=false)]
        public string Url { get; private set; }

        /// <summary>
        /// Displays array of validation error messages from the API
        /// </summary>
        /// <value>Displays array of validation error messages from the API</value>
        [DataMember(Name="ValidationErrors", EmitDefaultValue=false)]
        public List<ValidationError> ValidationErrors { get; set; }

        /// <summary>
        /// Displays array of warning messages from the API
        /// </summary>
        /// <value>Displays array of warning messages from the API</value>
        [DataMember(Name="Warnings", EmitDefaultValue=false)]
        public List<ValidationError> Warnings { get; set; }

        /// <summary>
        /// Displays array of attachments from the API
        /// </summary>
        /// <value>Displays array of attachments from the API</value>
        [DataMember(Name="Attachments", EmitDefaultValue=false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Receipt {\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  LineItems: ").Append(LineItems).Append("\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Reference: ").Append(Reference).Append("\n");
            sb.Append("  LineAmountTypes: ").Append(LineAmountTypes).Append("\n");
            sb.Append("  SubTotal: ").Append(SubTotal).Append("\n");
            sb.Append("  TotalTax: ").Append(TotalTax).Append("\n");
            sb.Append("  Total: ").Append(Total).Append("\n");
            sb.Append("  ReceiptID: ").Append(ReceiptID).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  ReceiptNumber: ").Append(ReceiptNumber).Append("\n");
            sb.Append("  UpdatedDateUTC: ").Append(UpdatedDateUTC).Append("\n");
            sb.Append("  HasAttachments: ").Append(HasAttachments).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  ValidationErrors: ").Append(ValidationErrors).Append("\n");
            sb.Append("  Warnings: ").Append(Warnings).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
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
            return this.Equals(input as Receipt);
        }

        /// <summary>
        /// Returns true if Receipt instances are equal
        /// </summary>
        /// <param name="input">Instance of Receipt to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Receipt input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Date == input.Date ||
                    (this.Date != null &&
                    this.Date.Equals(input.Date))
                ) && 
                (
                    this.Contact == input.Contact ||
                    (this.Contact != null &&
                    this.Contact.Equals(input.Contact))
                ) && 
                (
                    this.LineItems == input.LineItems ||
                    this.LineItems != null &&
                    input.LineItems != null &&
                    this.LineItems.SequenceEqual(input.LineItems)
                ) && 
                (
                    this.User == input.User ||
                    (this.User != null &&
                    this.User.Equals(input.User))
                ) && 
                (
                    this.Reference == input.Reference ||
                    (this.Reference != null &&
                    this.Reference.Equals(input.Reference))
                ) && 
                (
                    this.LineAmountTypes == input.LineAmountTypes ||
                    this.LineAmountTypes.Equals(input.LineAmountTypes)
                ) && 
                (
                    this.SubTotal == input.SubTotal ||
                    this.SubTotal.Equals(input.SubTotal)
                ) && 
                (
                    this.TotalTax == input.TotalTax ||
                    this.TotalTax.Equals(input.TotalTax)
                ) && 
                (
                    this.Total == input.Total ||
                    this.Total.Equals(input.Total)
                ) && 
                (
                    this.ReceiptID == input.ReceiptID ||
                    (this.ReceiptID != null &&
                    this.ReceiptID.Equals(input.ReceiptID))
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.ReceiptNumber == input.ReceiptNumber ||
                    (this.ReceiptNumber != null &&
                    this.ReceiptNumber.Equals(input.ReceiptNumber))
                ) && 
                (
                    this.UpdatedDateUTC == input.UpdatedDateUTC ||
                    (this.UpdatedDateUTC != null &&
                    this.UpdatedDateUTC.Equals(input.UpdatedDateUTC))
                ) && 
                (
                    this.HasAttachments == input.HasAttachments ||
                    this.HasAttachments.Equals(input.HasAttachments)
                ) && 
                (
                    this.Url == input.Url ||
                    (this.Url != null &&
                    this.Url.Equals(input.Url))
                ) && 
                (
                    this.ValidationErrors == input.ValidationErrors ||
                    this.ValidationErrors != null &&
                    input.ValidationErrors != null &&
                    this.ValidationErrors.SequenceEqual(input.ValidationErrors)
                ) && 
                (
                    this.Warnings == input.Warnings ||
                    this.Warnings != null &&
                    input.Warnings != null &&
                    this.Warnings.SequenceEqual(input.Warnings)
                ) && 
                (
                    this.Attachments == input.Attachments ||
                    this.Attachments != null &&
                    input.Attachments != null &&
                    this.Attachments.SequenceEqual(input.Attachments)
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
                if (this.Date != null)
                    hashCode = hashCode * 59 + this.Date.GetHashCode();
                if (this.Contact != null)
                    hashCode = hashCode * 59 + this.Contact.GetHashCode();
                if (this.LineItems != null)
                    hashCode = hashCode * 59 + this.LineItems.GetHashCode();
                if (this.User != null)
                    hashCode = hashCode * 59 + this.User.GetHashCode();
                if (this.Reference != null)
                    hashCode = hashCode * 59 + this.Reference.GetHashCode();
                hashCode = hashCode * 59 + this.LineAmountTypes.GetHashCode();
                hashCode = hashCode * 59 + this.SubTotal.GetHashCode();
                hashCode = hashCode * 59 + this.TotalTax.GetHashCode();
                hashCode = hashCode * 59 + this.Total.GetHashCode();
                if (this.ReceiptID != null)
                    hashCode = hashCode * 59 + this.ReceiptID.GetHashCode();
                hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.ReceiptNumber != null)
                    hashCode = hashCode * 59 + this.ReceiptNumber.GetHashCode();
                if (this.UpdatedDateUTC != null)
                    hashCode = hashCode * 59 + this.UpdatedDateUTC.GetHashCode();
                hashCode = hashCode * 59 + this.HasAttachments.GetHashCode();
                if (this.Url != null)
                    hashCode = hashCode * 59 + this.Url.GetHashCode();
                if (this.ValidationErrors != null)
                    hashCode = hashCode * 59 + this.ValidationErrors.GetHashCode();
                if (this.Warnings != null)
                    hashCode = hashCode * 59 + this.Warnings.GetHashCode();
                if (this.Attachments != null)
                    hashCode = hashCode * 59 + this.Attachments.GetHashCode();
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
