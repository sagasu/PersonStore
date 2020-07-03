using System;
using System.Collections.Generic;
using System.Text;

namespace PersonStore.Services.Data.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
