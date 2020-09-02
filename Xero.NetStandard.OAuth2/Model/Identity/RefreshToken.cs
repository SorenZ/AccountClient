/* 
 * Xero oAuth 2 identity service
 *
 * This specifing endpoints related to managing authentication tokens and identity for Xero API
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

namespace Xero.NetStandard.OAuth2.Model.Identity
{
    /// <summary>
    /// RefreshToken
    /// </summary>
    [DataContract]
    public partial class RefreshToken :  IEquatable<RefreshToken>, IValidatableObject
    {
        
        /// <summary>
        /// Xero grant type
        /// </summary>
        /// <value>Xero grant type</value>
        [DataMember(Name="grant_type", EmitDefaultValue=false)]
        public string GrantType { get; set; }

        /// <summary>
        /// refresh token provided during authentication flow
        /// </summary>
        /// <value>refresh token provided during authentication flow</value>
        [DataMember(Name="refresh_token", EmitDefaultValue=false)]
        public string _RefreshToken { get; set; }

        /// <summary>
        /// client id for Xero app
        /// </summary>
        /// <value>client id for Xero app</value>
        [DataMember(Name="client_id", EmitDefaultValue=false)]
        public string ClientId { get; set; }

        /// <summary>
        /// client secret for Xero app 2
        /// </summary>
        /// <value>client secret for Xero app 2</value>
        [DataMember(Name="client_secret", EmitDefaultValue=false)]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RefreshToken {\n");
            sb.Append("  GrantType: ").Append(GrantType).Append("\n");
            sb.Append("  _RefreshToken: ").Append(_RefreshToken).Append("\n");
            sb.Append("  ClientId: ").Append(ClientId).Append("\n");
            sb.Append("  ClientSecret: ").Append(ClientSecret).Append("\n");
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
            return this.Equals(input as RefreshToken);
        }

        /// <summary>
        /// Returns true if RefreshToken instances are equal
        /// </summary>
        /// <param name="input">Instance of RefreshToken to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefreshToken input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.GrantType == input.GrantType ||
                    (this.GrantType != null &&
                    this.GrantType.Equals(input.GrantType))
                ) && 
                (
                    this._RefreshToken == input._RefreshToken ||
                    (this._RefreshToken != null &&
                    this._RefreshToken.Equals(input._RefreshToken))
                ) && 
                (
                    this.ClientId == input.ClientId ||
                    (this.ClientId != null &&
                    this.ClientId.Equals(input.ClientId))
                ) && 
                (
                    this.ClientSecret == input.ClientSecret ||
                    (this.ClientSecret != null &&
                    this.ClientSecret.Equals(input.ClientSecret))
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
                if (this.GrantType != null)
                    hashCode = hashCode * 59 + this.GrantType.GetHashCode();
                if (this._RefreshToken != null)
                    hashCode = hashCode * 59 + this._RefreshToken.GetHashCode();
                if (this.ClientId != null)
                    hashCode = hashCode * 59 + this.ClientId.GetHashCode();
                if (this.ClientSecret != null)
                    hashCode = hashCode * 59 + this.ClientSecret.GetHashCode();
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
