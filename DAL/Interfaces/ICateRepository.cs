﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICateRepository
    {
        List<Categories> GetAll();
        bool Create(Categories model);

    }
}
