using System.Xml.Serialization;

namespace ExchangeRates.DataAccess.Entities
{
    public class Currency
    {
        [XmlElement(ElementName = "NumCode")]
        public string NumCode { get; set; }
        [XmlElement(ElementName = "CharCode")]
        public string CharCode { get; set; }
        [XmlElement(ElementName = "Scale")]
        public string Scale { get; set; }
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Rate")]
        public string Rate { get; set; }
    }
}
