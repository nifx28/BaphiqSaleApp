using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp.Models
{
    [Serializable]
    [XmlType(TypeName = "SellStoreUpload")]
    public class SellStore<T>
    {
        [Required]
        [MaxLength(20)]
        [XmlElement("SID")]
        public string Sid { get; set; }

        [Required]
        public Company Company { get; set; }

        [Required]
        public UploadRecord<T> UploadRecord { get; set; }
    }
}
