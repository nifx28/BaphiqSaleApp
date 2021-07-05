using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp
{
    [Serializable]
    [XmlType(TypeName = "SellStoreUpload")]
    public class SellStore
    {
        [Required]
        [MaxLength(20)]
        [XmlElement("SID")]
        public string Sid { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required]
        public UploadRecord UploadRecord { get; set; }
    }
}
