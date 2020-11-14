using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Mark
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
