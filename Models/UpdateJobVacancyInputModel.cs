﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobApi.Models
{
    public record UpdateJobVacancyInputModel(string Title, string Description)
    {
    }
}
