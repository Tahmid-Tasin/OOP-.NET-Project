namespace Store
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public bool IsActive { get; set; }

        public System.DateTime CreatedAt { get; set; }

        public System.DateTime UpdatedAt { get; set; }
    }
}
