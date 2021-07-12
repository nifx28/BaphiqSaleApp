using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 單筆記錄內容（傳輸結構）
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "Record")]
    public class RecordOut
    {
        [Required]
        public int RecordID { get; set; }

        [MaxLength(20)]
        public string UserID { get; set; }

        [MaxLength(32)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(9)]
        public string SellDate { get; set; }

        [Required]
        [MaxLength(13)]
        public string BarCode { get; set; }

        /// <summary>
        /// 指定型別 typeof(string)，以便轉換回 RecordIn 當中的 int Quantity。
        /// <see cref="RecordIn.Quantity"/>
        /// <code>[XmlElement(Type = typeof(string))]</code>
        /// </summary>
        [Required]
        [MaxLength(10)]
        [XmlElement(Type = typeof(string))]
        public StringDto<int> Quantity { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }
    }
}
