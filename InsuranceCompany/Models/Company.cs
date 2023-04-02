namespace InsuranceCompany.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public bool Active { get; set; }
        public DateTime InsuranceEndDate { get; set; }
    }
}
