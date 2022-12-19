namespace ExchangeRates.BusinessLogic.DTO
{
    public class CurrencyDTO
    {
        public string CharCode { get; set; }
        public string Scale { get; set; }
        public string Name { get; set; }
        public string Rate1 { get; set; }
        public string Rate2 { get; set; }
        public bool IsActive { get; set; }
    }
}
