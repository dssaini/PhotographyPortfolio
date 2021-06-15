using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class BaseService
    {
        protected readonly PhotographyDbContext dbContext;
        public BaseService(PhotographyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
