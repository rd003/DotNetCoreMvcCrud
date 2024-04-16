using DotNetCoreMvcCrud.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMvcCrud.Data.Repositories;

public interface IPersonRepository
{
    Task AddPerson(Person person);
    Task UpdatePerson(Person person);
    Task<Person?> FindPersonById(int id);
    Task<IEnumerable<Person>> GetPeople();
    Task DeletePerson(Person person);
}

public class PersonRepository(ApplicationDbContext _context) : IPersonRepository
{
    //private readonly ApplicationDbContext _context;
    //public PersonRepository(ApplicationDbContext context)
    //{
    //    _context = context;
    //}

    public async Task AddPerson(Person person)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePerson(Person person)
    {
        _context.People.Remove(person);
        await _context.SaveChangesAsync();
    }

    public async Task<Person?> FindPersonById(int id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        return await _context.People.ToListAsync();
    }

    public async Task UpdatePerson(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
    }
}
