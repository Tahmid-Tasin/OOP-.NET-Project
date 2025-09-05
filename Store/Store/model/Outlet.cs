using System.Collections.Generic;

namespace Store
{
    public class Outlet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();
    }
}
