using System;
using System.ComponentModel.DataAnnotations;


namespace WebApiDemo2.Data
{
    public class Portusers
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? Phone { get; set; }
        public long? Cost { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Endtime { get; set; }
        public string Usertype { get; set; }
    }

}
