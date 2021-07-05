using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp
{
    /// <summary>
    /// 業者資訊
    /// </summary>
    [Serializable]
    public class Company
    {
        [Required]
        [MaxLength(8)]
        [XmlElement("LoginID")]
        public string LoginId { get; set; }

        [Required]
        [MaxLength(20)]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(8)]
        public string DutName { get; set; }

        [Required]
        [MaxLength(32)]
        public string TrustID { get; set; }
    }
}
