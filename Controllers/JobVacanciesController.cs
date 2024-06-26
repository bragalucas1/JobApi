﻿using JobApi.Entities;
using JobApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Controllers
{
    public class JobVacanciesController : ControllerBase
    {

        private readonly IJobVacancyRepository _repository;
        public JobVacanciesController(IJobVacancyRepository repository)
        {
            _repository = repository;
        }

        // GET api/job-vacancies
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _repository.GetAll();

            return Ok(jobVacancies);
        }

        // GET api/job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }

        // POST api/job-vacancies
        /// <summary>
        /// Cadastrar uma vaga de emprego.
        /// </summary>
        /// <remarks>
        ///   {
        ///   "title": "Vaga .NET Jr",
        ///   "description": "Vaga para uma grande empresa.",
        ///   "company": "LuisDev",
        ///   "isRemote": true,
        ///   "salaryRange": "3000-5000"
        ///   }
        /// </remarks>
        /// <param name="model">Dados de Vaga</param>
        /// <returns>Objeto recém criado.</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            Log.Information("Post executado.");

            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );

            _repository.Add(jobVacancy);

            return CreatedAtAction(
                "GetById",
                new { id = jobVacancy.Id },
                jobVacancy);
        }

        // PUT api/job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
            var jobVacancy = _repository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(model.Title, model.Description);

            _repository.Update(jobVacancy);

            return NoContent();
        }
    }
}
