using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncorrectSQLGeneration
{
    [Table("Quote")]
    public partial class Quote
    {
        [Key]
        public int ID { get; set; }

        public int AuthorID { get; set; }

        public int? BookID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
    }
}