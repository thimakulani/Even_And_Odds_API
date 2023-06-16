using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Even_And_Odds_API.Models
{
    public class Car
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string RegNo { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}
