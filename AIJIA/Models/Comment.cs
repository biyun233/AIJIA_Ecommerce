using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Comment
    {
        [Key]
        public int IdComment { get; set; }
        public decimal NoteArticle { get; set; }
        public DateTime DateComment { get; set; }

        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
