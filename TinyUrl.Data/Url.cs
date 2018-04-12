using System.ComponentModel.DataAnnotations;
using TinyUrl.Interfaces;

namespace TinyUrl.Data
{
    public class Url: IUrl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string LongUrl { get; set; }

        //[Required]
        //[MaxLength(10)]
        //public string Tiny { get; set; }
    }
}
