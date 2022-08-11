using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Authing.Library.Domain.Model.V3Model.Management.Models
{
    /// <summary>
    /// GetGroupAuthorizedResourcesDto 的模型
    /// </summary>
    public partial class GetGroupAuthorizedResourcesDto
    {
        /// <summary>
        ///  分组 code
        /// </summary>
        [JsonProperty("code")]
        public object Code { get; set; }
        /// <summary>
        ///  所属权限分组的 code
        /// </summary>
        [JsonProperty("namespace")]
        public object Namespace { get; set; }
        /// <summary>
        ///  资源类型
        /// </summary>
        [JsonProperty("resourceType")]
        public object ResourceType { get; set; }
    }
}