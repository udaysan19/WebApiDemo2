using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo2.Data
{
    public class Portslots
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
