﻿namespace Linn.Products.Persistence.Linnapps.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using Linn.Common.Persistence;
    using Linn.Products.Domain.Linnapps;

    public class EmployeeRepository : IRepository<Employee, int>
    {
        private readonly ServiceDbContext serviceDbContext;

        public EmployeeRepository(ServiceDbContext serviceDbContext)
        {
            this.serviceDbContext = serviceDbContext;
        }

        public Employee FindById(int key)
        {
            return this.serviceDbContext.Employees.Where(b => b.Id == key).ToList().FirstOrDefault();
        }

        public IQueryable<Employee> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee FindBy(Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> FilterBy(Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
