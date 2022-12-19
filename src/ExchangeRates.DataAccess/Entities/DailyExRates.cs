using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeRates.DataAccess.Entities
{
    [XmlRoot(ElementName = "DailyExRates")]
    public class DailyExRates
    {
        [XmlElement(ElementName = "Currency")]
        public List<Currency> Currencies { get; set; }
    }
}
