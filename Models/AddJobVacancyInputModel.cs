﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public record AddJobVacancyInputModel(
            string Title,
            string Description,
            string Company,
            bool IsRemote,
            string SalaryRange)
    {

    }
}