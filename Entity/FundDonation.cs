using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundationWebApp.Entity
{
    public class FundDonation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime FDate { get; set; }
        public double Amount { get; set; }
        public string? FDonorName { get; set; }
   

    }
}
