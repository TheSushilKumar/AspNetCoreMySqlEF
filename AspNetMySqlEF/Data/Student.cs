using System;
using System.Collections.Generic;

namespace AspNetMySqlEF.Data
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RollNumber { get; set; }
        public string City { get; set; }
    }
}
