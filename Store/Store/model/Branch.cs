namespace Store
{
    public class Branch
    {
        public int Id
        {
            get; set;
        }

        public int CompanyId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string AddressLine1
        {
            get; set;
        }

        public string AddressLine2
        {
            get; set;
        }

        public string City
        {
            get; set;
        }

        public string State
        {
            get; set;
        }

        public string PostalCode
        {
            get; set;
        }

        public string Country
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public System.DateTime CreatedAt
        {
            get; set;
        }

        public System.DateTime UpdatedAt
        {
            get; set;
        }

        // Navigation property → Company
        public Company Company
        {
            get; set;
        }
    }
}
