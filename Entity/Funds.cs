using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundationWebApp.Entity
{
    public class Funds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? TransactionType { get; set; }
        public double Amount { get; set; } = 0;
        public DateTime createDate { get; set; }
    }
}
