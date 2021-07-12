using System;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 空白電文格式
    /// </summary>
    public class EmptyDto<T> where T : IConvertible
    {
        private T _value;

        /// <summary>
        /// InvalidOperationException: 無法序列化 BaphiqSaleApp.Models.EmptyDto`1[System.Int32]，因為它沒有參數建構函式。
        /// </summary>
        public EmptyDto()
        {
        }

        /// <summary>
        /// 實體化 RecordOut 傳輸結構
        /// <code>Quantity = 100,</code>
        /// </summary>
        /// <param name="value"></param>
        public EmptyDto(T value)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                    var str = Convert.ChangeType(value, typeof(string)) as string;
                    _value = (T)Convert.ChangeType(str == "null" ? string.Empty : str, typeof(T));
                    break;
                default:
                    _value = value;
                    break;
            }
        }

        /// <summary>
        /// 錯誤 CS0029: 無法將類型 'string' 隱含轉換成 'BaphiqSaleApp.Models.EmptyDto<string>'
        /// <code>Quantity = 100,</code>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator EmptyDto<T>(T value) => new EmptyDto<T>(value);

        /// <summary>
        /// 錯誤 CS0030: 無法將類型 'BaphiqSaleApp.Models.EmptyDto<string>' 轉換為 'string'
        /// </summary>
        /// <param name="str"></param>
        public static explicit operator string(EmptyDto<T> str) => str.ToString();

        public override string ToString()
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                    var str = Convert.ChangeType(_value, typeof(string)) as string;
                    return str == "null" ? string.Empty : str;
                default:
                    return _value.ToString();
            }
        }
    }
}
