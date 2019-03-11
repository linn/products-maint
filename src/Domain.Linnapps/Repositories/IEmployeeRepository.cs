namespace Linn.Products.Domain.Linnapps.Repositories
{
    using System.Collections.Generic;

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}
