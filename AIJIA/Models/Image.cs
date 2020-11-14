using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Image
    {
        [Key]
        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public string SrcImage { get; set; }
    }
}
