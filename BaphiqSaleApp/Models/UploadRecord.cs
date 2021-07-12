using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 詳細銷售紀錄
    /// </summary>
    [Serializable]
    [XmlType(TypeName = "UploadRecord")]
    public class UploadRecord<T>
    {
        /// <summary>
        /// 共有幾筆銷售紀錄
        /// </summary>
        [Required]
        public int RTotal { get; set; }

        [Required]
        [XmlElement("Record")]
        public List<T> Records { get; set; }
    }
}
