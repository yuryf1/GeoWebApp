using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace Laboratory
{
    public partial class _Default : Page
    {
        static string connectionString = "DefaultEndpointsProtocol=https;AccountName=movetome;AccountKey=l97jSV/ZQ8ATTrDgDGvAANDYrseXXZqxV7KJdf0qNDRQT6l8NCyC8w/MgQN1/u2DoUr9qlEpaefQJOW4wYPExg==;EndpointSuffix=core.windows.net";
        static CloudStorageAccount storageAccount { get; set; }
        static CloudTableClient t_client { get; set; }
        public static CloudTable table;



        protected void Page_Load(object sender, EventArgs e)
        {
           
            storageAccount = CloudStorageAccount.Parse(connectionString); // Получение строки подключения из строки конфигурации.
            t_client = storageAccount.CreateCloudTableClient();           // Создание клиента службы таблиц
            table = t_client.GetTableReference("LocationRecord");         // Получение ссылки на таблицу.
            table.CreateIfNotExists();                                    // Создание таблицы

            WebClient wc = new WebClient();

            TableOperation retrieveOperation = TableOperation.Retrieve<LocationRecord>("Server №1", "Location");
            TableResult retrievedResult = table.Execute(retrieveOperation);
            string valueFromStorage;
            string url1 = "https://static-maps.yandex.ru/1.x/?ll=";       // Yandex API
            string url2 = "&size=450,450&l=map&pt=";                      // https://tech.yandex.ru/maps/
			string urlEndMap1 = ",comma&z=9";
            string urlEndMap2 = ",comma&z=15";
            string urlMap;

            if (retrievedResult.Result != null)
            {
                valueFromStorage = ((LocationRecord)retrievedResult.Result).input;
                urlMap = url1 + valueFromStorage + url2 + valueFromStorage;
                Image1.ImageUrl = urlMap + urlEndMap1;
                Image2.ImageUrl = urlMap + urlEndMap2;

                var geocoder = wc.DownloadString("https://geocode-maps.yandex.ru/1.x/?format=json&lang=en_US&geocode=" + valueFromStorage);
                dynamic adress = Newtonsoft.Json.JsonConvert.DeserializeObject(geocoder);
                TextBox2.Text = (adress.response.GeoObjectCollection.featureMember[0].GeoObject.metaDataProperty.GeocoderMetaData.text).ToString();
            }
            else
                valueFromStorage = "no data";
            TextBox1.Text = valueFromStorage;


        }




        public class LocationRecord : TableEntity                         // Класс, который определяет свойства сущности.
        {
            public LocationRecord(string input)
            {
                this.input = input;
                PartitionKey = "Server №1";                               // Ключ раздела
                RowKey = "Location";                                      // Ключ строки
            }
            public LocationRecord() { }
            public string input { get; set; }
        }




        public static async Task<bool> RecordAsync(string i)
        {
            try
            {
                var rd = new LocationRecord(i);
                await table.ExecuteAsync(TableOperation.InsertOrMerge(rd));
                return true;
            }
            catch { return false; }
        }



        public static bool Record(string i)
        {
            try
            {
                var rd = new LocationRecord( i);
                table.Execute(TableOperation.Insert(rd));            
                return true;
            }
            catch { return false; }
        }



    }
}
