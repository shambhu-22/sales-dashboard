namespace DashBoardAPI.Models
{
    public class SalesRankedData
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string City { get; set; }
        public decimal Week_Total { get; set; }
        public long Sales_rank { get; set; }
    }
}
