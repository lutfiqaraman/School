using System;

namespace backend.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skills { get; set; }
        public decimal Salary { get; set; }
        public DateTime AddedOn { get; set; }
    }
}