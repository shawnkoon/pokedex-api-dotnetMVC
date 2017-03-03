using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokedexApi.Models
{
    /// <summary>
    /// Class that defines pokemon object.
    /// </summary>
    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsCaught { get; set; }
    }
}
