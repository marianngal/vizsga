using Company.Context;
using Company.Models;

namespace Company.Services;

/// <summary>
/// A gyakori CRUD műveleteket előíró interface
/// </summary>
interface IEmployeeService
{
    void Create(Employee employee);
    Employee GetById(int id);
    List<Employee> GetAll();
    void Update(Employee employee);
    void Delete(Employee employee);
    void Delete(int id);
}

// interface implementálása osztalynev : interface
// majd quick actions:  Ctrl + .  vagy Alt + Enter 
// "implement interface"
class EmployeeService : IEmployeeService
{
    public void Create(Employee employee)
    {
        throw new NotImplementedException();
    }

    public void Delete(Employee employee)
    {
        using CompanyContext context = new();
        context.Remove(employee);
        context.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Employee> GetAll()
    {
        using CompanyContext context = new();
        return context.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
        throw new NotImplementedException();
    }
}
