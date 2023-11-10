using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterAlleviationFoundationWebApp.Entity
{
    public class Goods
    {
        public class funds
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string? GoodType { get; set; }

            public string? GoodName { get; set; }
            public DateTime createDate { get; set; }
        }
    }
}
