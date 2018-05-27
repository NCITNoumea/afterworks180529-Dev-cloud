using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MS.Afterworks.HappyFace.Core.Models
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
