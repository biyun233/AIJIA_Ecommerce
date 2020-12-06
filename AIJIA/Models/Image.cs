using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace AIJIA.Models
{
    public class Image
    {
        [Key]
        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
        //public string SrcImage { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
