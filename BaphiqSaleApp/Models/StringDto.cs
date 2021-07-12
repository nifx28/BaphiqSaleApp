using System;

namespace BaphiqSaleApp.Models
{
    /// <summary>
    /// 字串電文格式
    /// </summary>
    public class StringDto<T> where T : IConvertible
    {
        private T _value;

        /// <summary>
        /// InvalidOperationException: 無法序列化 BaphiqSaleApp.Models.StringDto`1[System.Int32]，因為它沒有參數建構函式。
        /// </summary>
        public StringDto()
        {
        }

        /// <summary>
        /// 實體化 RecordOut 傳輸結構
        /// <code>Quantity = 100,</code>
        /// </summary>
        /// <param name="value"></param>
        public StringDto(T value)
        {
            _value = value;
        }

        /// <summary>
        /// 錯誤 CS0029: 無法將類型 'int' 隱含轉換成 'BaphiqSaleApp.Models.StringDto<int>'
        /// <code>Quantity = 100,</code>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator StringDto<T>(T value) => new StringDto<T>(value);

        /// <summary>
        /// 錯誤 CS0029: 無法將類型 'string' 隱含轉換為 'BaphiqSaleApp.Models.StringDto<int>'
        /// <para>毋須實作</para>
        /// </summary>
        /// <param name="_">捨棄參數</param>
        public static implicit operator StringDto<T>(string _) => throw new NotImplementedException();

        /// <summary>
        /// 錯誤 CS0030: 無法將類型 'BaphiqSaleApp.Models.StringDto<int>' 轉換為 'string'
        /// </summary>
        /// <param name="str"></param>
        public static explicit operator string(StringDto<T> str) => str.ToString();

        public override string ToString()
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.Int32:
                    return ((int)Convert.ChangeType(_value, typeof(int))).ToString("D10");
                default:
                    return _value.ToString();
            }
        }
    }
}
