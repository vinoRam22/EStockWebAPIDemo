﻿using CompanyService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyService
{
    public interface ICompanyRepository
    {
        List<Company> Get();

        Company GetByCode(string code);

        Company Create(Company company);

        void Delete(string code);
    }
}
