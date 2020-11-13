using System;
namespace AIJIA.Models
{
    public class Comment
    {
        public int IdComment { get; set; }
        public decimal NoteArticle { get; set; }
        public DateTime DateComment { get; set; }
        public int IdArticle { get; set; }
        public int IdUser { get; set; }
    }
}
