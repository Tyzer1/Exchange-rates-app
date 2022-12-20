using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ExchangeRates.DataAccess.Interfaces;
using ExchangeRates.DataAccess.Entities;
using System.Net;
using System;
using Xamarin.Essentials;

namespace ExchangeRates.DataAccess.XML
{
    public class XMLProvider : IDataProvider<Currency>
    {
        public async Task<IEnumerable<Currency>> GetByDateAsync(DateTime date)
        {
            string dateRequest = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            //string url = $"https://www.nbrb.by/services/xmlexrates.aspx?ondate={dateRequest}";
            var url = Preferences.Get("GetRatesUrl", "") + dateRequest;

            //Use HTTPWebRequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            try
            {
                //Get Response
                var response = await request.GetResponseAsync();

                //Call GetResponseStream() to return Stream
                Stream responseStream = response.GetResponseStream();

                //Convert from XML to C# model:
                XmlSerializer serializer = new XmlSerializer(typeof(DailyExRates));
                DailyExRates dailyExRates = (DailyExRates)serializer.Deserialize(responseStream);
                return dailyExRates.Currencies;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
