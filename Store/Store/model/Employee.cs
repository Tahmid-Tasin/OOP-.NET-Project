namespace Store
{
    public class Employee
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string MOBILE { get; set; }
        public string EMAIL { get; set; }   // ✅ New field
        public string PASSWORD { get; set; }
        public string ADDRESS { get; set; }

        // Foreign key
        public int? OutletId { get; set; }

        // Navigation
        public Outlet Outlet { get; set; }
    }
}
