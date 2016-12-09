using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncorrectSQLGeneration
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual MysteryBook MysteryBook { get; set; }
    }
}