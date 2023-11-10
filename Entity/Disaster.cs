using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundationWebApp.Entity

{
    public class Disaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public string? GoodsDescription { get; set; }
        public string? AidType { get; set; }

        public double Amount { get; set; }

        public int NumItems { get; set; }
    }
}
