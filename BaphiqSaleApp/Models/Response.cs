using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 交易回覆
    /// </summary>
    [Serializable]
    public class Response
    {
        /// <summary>
        /// 文件識別碼
        /// </summary>
        [Required]
        [MaxLength(20)]
        [XmlElement("SID")]
        public string Sid { get; set; }

        /// <summary>
        /// 交易信任碼
        /// </summary>
        [Required]
        [MaxLength(32)]
        [XmlElement("RID")]
        public string Rid { get; set; }

        [Required]
        [MaxLength(1)]
        public bool Status { get; set; }

        [MaxLength(100)]
        public string ErrorCode { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }
    }
}
