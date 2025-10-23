namespace ProductCatalogManagment.Domain.Models
{
    public class AuditLog
    {
        public long Id { get; set; }
        public string TableName { get; set; } = string.Empty;
        public long RecordId { get; set; }
        public string Operation { get; set; } = string.Empty;
        public string OldValues { get; set; } = string.Empty;
        public string NewValues { get; set; } = string.Empty;
        public string ModifiedBy { get; set; }= string.Empty;
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
