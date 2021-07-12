using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 單筆記錄內容
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "Record")]
    public class RecordIn
    {
        [Required]
        public int RecordID { get; set; }

        [MaxLength(20)]
        //[XmlElement(IsNullable = true)]
        public EmptyDto<string> UserID { get; set; } = new EmptyDto<string>("null");

        [MaxLength(32)]
        //[XmlElement(IsNullable = true)]
        public EmptyDto<string> UserName { get; set; } = new EmptyDto<string>("null");

        [Required]
        [MaxLength(9)]
        public string SellDate { get; set; }

        [Required]
        [MaxLength(13)]
        public string BarCode { get; set; }

        [Required]
        [MaxLength(10)]
        public int Quantity { get; set; }

        [MaxLength(500)]
        //[XmlElement(IsNullable = true)]
        [XmlElement(Type = typeof(string))]
        public EmptyDto<string> Note { get; set; } = new EmptyDto<string>("null");
    }
}
