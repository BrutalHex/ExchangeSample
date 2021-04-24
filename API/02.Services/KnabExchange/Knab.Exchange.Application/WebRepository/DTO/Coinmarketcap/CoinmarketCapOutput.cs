using System;
using System.Collections.Generic;
using System.Text;

namespace Knab.Exchange.Application.DTO.Coinmarketcap
{
    public partial class CoinmarketCapOutput
    {
        public Status Status { get; set; }
        public Data Data { get; set; }
    }

    public partial class Data
    {
        public long? Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public long? Amount { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public Quote Quote { get; set; }
    }

    public partial class Quote
    {
        public BRL BRL { get; set; }
        public BRL USD { get; set; }

        public EUR EUR { get; set; }
        public GBP GBP { get; set; }
        public AUD AUD { get; set; }



    }


    public class USD: BaseCoinmarketCapFiat
    {
    }
    public class EUR : BaseCoinmarketCapFiat
    {
    }
    public class GBP : BaseCoinmarketCapFiat
    {
    }
    public class AUD : BaseCoinmarketCapFiat
    {
    }
    public class BRL : BaseCoinmarketCapFiat
    {
    }



    public partial class BaseCoinmarketCapFiat
    {
        public double? Price { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
    }

    public partial class Status
    {
        public DateTimeOffset? Timestamp { get; set; }
        public long? ErrorCode { get; set; }
        public object ErrorMessage { get; set; }
        public long? Elapsed { get; set; }
        public long? CreditCount { get; set; }
        public object Notice { get; set; }
    }
}
