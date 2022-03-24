using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApi.Entities;
using JobApi.Models;
using JobApi.Persistence;


namespace JobApi.Controllers
{
    public class JobApplicationsController:ControllerBase
    {
        private readonly DevJobsContext _context;
 
            
            public JobApplicationsController(DevJobsContext context)
            {
                _context = context;
            }

            // POST api/job-vacancies/4/applications
            [HttpPost]
            public IActionResult Post(int id, AddJobApplicationInputModel model)
            {
                var jobVacancy = _context.JobVacancies
                    .SingleOrDefault(jv => jv.Id == id);

                if (jobVacancy == null)
                    return NotFound();

                var application = new JobApplication(
                    model.ApplicantName,
                    model.ApplicantEmail,
                    id
                );

                _context.JobApplications.Add(application);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
