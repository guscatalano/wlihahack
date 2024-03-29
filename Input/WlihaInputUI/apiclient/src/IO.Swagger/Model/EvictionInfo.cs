/* 
 * My API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// EvictionInfo
    /// </summary>
    [DataContract]
        public partial class EvictionInfo :  IEquatable<EvictionInfo>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EvictionInfo" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="dateOfEviction">dateOfEviction.</param>
        public EvictionInfo(int? id = default(int?), DateTime? dateOfEviction = default(DateTime?))
        {
            this.Id = id;
            this.DateOfEviction = dateOfEviction;
        }
        
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets DateOfEviction
        /// </summary>
        [DataMember(Name="dateOfEviction", EmitDefaultValue=false)]
        public DateTime? DateOfEviction { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class EvictionInfo {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DateOfEviction: ").Append(DateOfEviction).Append("\n");
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
            return this.Equals(input as EvictionInfo);
        }

        /// <summary>
        /// Returns true if EvictionInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of EvictionInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(EvictionInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.DateOfEviction == input.DateOfEviction ||
                    (this.DateOfEviction != null &&
                    this.DateOfEviction.Equals(input.DateOfEviction))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.DateOfEviction != null)
                    hashCode = hashCode * 59 + this.DateOfEviction.GetHashCode();
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
