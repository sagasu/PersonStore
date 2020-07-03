﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonStore.Services.DTO;
using PersonStore.Services.Services;

namespace PersonStore.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPut]
        public async Task<OkObjectResult> CreatePerson(PersonDTO personDto)
        {
            var newlyCreatedId = await _personService.CreatePerson(personDto);
            return Ok(newlyCreatedId);
        }
    }
}