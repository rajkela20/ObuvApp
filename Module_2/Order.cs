using System;

namespace ObuvApp
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ArticleNumber { get; set; }
        public string StatusName { get; set; }
        public string PickupAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? IssueDate { get; set; }
    }
}
