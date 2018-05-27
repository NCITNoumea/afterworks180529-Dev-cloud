using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    public class Smile
    {
        [Key]
        public int Id { get; set; }

        public bool IsHappy { get; set; }

        public string Why { get; set; }

        public string IpAddress { get; set; }
    }
}
