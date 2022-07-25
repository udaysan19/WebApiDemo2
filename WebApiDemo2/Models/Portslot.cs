using System;
using System.ComponentModel.DataAnnotations;


namespace WebApiDemo2.Models
{
    public class Portslot
    {
        [Key]
        public int SlotId { get; set; }
        public int? Ruid { get; set; }
        public int? SluserId { get; set; }
        public string Status { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public long? Cost { get; set; }
    }
}
