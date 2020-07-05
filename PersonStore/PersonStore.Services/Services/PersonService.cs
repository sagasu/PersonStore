using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PersonStore.Services.Data;
using PersonStore.Services.Data.Model;
using PersonStore.Services.DTO;

namespace PersonStore.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;

        public PersonService(StoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreatePerson(PersonDTO personDto)
        {
            // I like to think that responsibility of Setting Creation Time is a responsibility of a back end, but...
            // In my life I came across so many situations where the application wanted to control it (for example we wanted to pretend that the record was created in a future)
            // Also if CreateTime is exposed it is much easier to test application (QA team)/and troubleshoot it/do large data inserts thru API and so on...
            // That is why I tend to follow approach of having nullable DateTime and only set it if it is null.
            // I like to keep all my date time as UTC.
            if (!personDto.CreateTime.HasValue)
                personDto.CreateTime = DateTime.UtcNow; // Normally I like to create a separate data time service (Date Time Pattern), so I am able to control it from one place.

            var person = _mapper.Map<Person>(personDto);
            var created = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return created.Entity.Id;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPeople()
        {
            var allPeople = await _context.Persons.ToListAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(allPeople);
        }

        public async Task<PersonDTO> GetById(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            return person == null ? null : _mapper.Map<PersonDTO>(person);
        }
    }
}
