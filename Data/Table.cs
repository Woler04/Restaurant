namespace Restaurant.Data
{
    public class Table
    {
        [Id]
        public int Id { get; set; }
        public int Seats { get; set; }
        public bool isSmoking { get; set; }
    }
}
