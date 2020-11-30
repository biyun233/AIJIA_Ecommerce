using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class ModelDelivery
    {
        [Key]
        public int ID { get; set; }
        public string Model { get; set; }
        public string DescriptionModel { get; set; }
    }
}
