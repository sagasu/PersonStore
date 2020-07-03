using System;

namespace PersonStore.Services.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
