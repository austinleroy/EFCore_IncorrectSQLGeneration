using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncorrectSQLGeneration
{
    [Table("MysteryBook")]
    public partial class MysteryBook
    {
        [Key]
        public int BookID { get; set; }
        public string Hero { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
    }
}