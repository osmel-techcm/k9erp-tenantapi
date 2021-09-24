using System;

namespace tenantShared.Entities
{
    public class TransactionHeader
    {
        public string Code { get; set; }

        public DateTime? Date { get; set; }

        public int EntityId { get; set; }

        public string Remarks { get; set; }

        public decimal Total { get; set; }
    }
}
