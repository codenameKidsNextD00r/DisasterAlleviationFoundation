using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundationWebApp.Entity
{
    public class GoodsDonation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime GDate { get; set; }
        public int NumItems { get; set; }
        public Category? category { get; set; }
        public string? Description { get; set; }
        public string? GDonorName { get; set; }

    }
}
