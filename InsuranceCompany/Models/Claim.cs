namespace InsuranceCompany.Models
{
    public class Claim
    {
        public int Id { get; set; }

        public string ClaimReference { get; set; }

        public int CompanyId { get; set; }

        public DateTime ClaimDate { get; set; }

        public DateTime LossDate { get; set; }

        public string AssuredName { get; set; }

        public Decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }

        public ClaimType ClaimType { get; set; }
    }
}
