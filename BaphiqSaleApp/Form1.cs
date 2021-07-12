using BaphiqSaleApp.BaphiqSale;
using BaphiqSaleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;

namespace BaphiqSaleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ActiveControl = textBox1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var label = sender as LinkLabel;
            e.Link.Visited = true;
            Process.Start(label.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            var culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();
            var sellDate = now.ToString("yyy/MM/dd", culture);

            var model = new SellStore<RecordOut>
            {
                Sid = "文件識別碼",
                Company = new Company
                {
                    LoginId = "登入帳號",
                    StoreName = "商業名稱",
                    DutName = "負責人姓名",
                    TrustID = "交易信任碼"
                },
                UploadRecord = new UploadRecord<RecordOut>
                {
                    RTotal = 1,
                    Records = new List<RecordOut>
                        {
                            new RecordOut
                            {
                                RecordID = 1,
                                UserID = "購買人身分證字號",
                                UserName = "購買人姓名",
                                SellDate = sellDate,
                                BarCode = "農藥EAN13條碼",
                                Quantity = 100,
                                Note = "備註"
                            }
                        }
                }
            };

            var modelXml = string.Empty;

            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, new XmlWriterSettings
            {
                Indent = true
            }))
            {
                var mySerializer = new XmlSerializer(typeof(SellStore<RecordOut>));

                mySerializer.Serialize(writer, model, new XmlSerializerNamespaces(new XmlQualifiedName[]
                {
                    new XmlQualifiedName(string.Empty, string.Empty)
                }));

                modelXml = Encoding.UTF8.GetString(ms.ToArray());
            }

            textBox1.Text = modelXml;
            /*SellStore<RecordIn> modelObj = null;

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(modelXml)))
            using (var reader = XmlReader.Create(ms))
            {
                var mySerializer = new XmlSerializer(typeof(SellStore<RecordIn>));
                modelObj = mySerializer.Deserialize(reader) as SellStore<RecordIn>;
            }

            MessageBox.Show(JsonConvert.SerializeObject(modelObj, Formatting.Indented));
            return;*/

            var responseXml = string.Empty;

            using (var client = new BaphiqSaleClient())
            {
                responseXml = client.SellStoreUpload("LoginId", modelXml);
            }

            Response response = null;

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseXml)))
            using (var reader = XmlReader.Create(ms))
            {
                var mySerializer = new XmlSerializer(typeof(Response));
                response = mySerializer.Deserialize(reader) as Response;
            }

            MessageBox.Show(responseXml + Environment.NewLine +
                JsonConvert.SerializeObject(response, Formatting.Indented));
        }
    }
}
