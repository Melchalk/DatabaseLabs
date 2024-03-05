using DTOs;
using DTOs.Response;

namespace Repository.Interfaces;

public interface IStudentsRepository
{
    Task SaveAsync();

    void Delete(Guid id);

    void Add(StudentDto student);

    Task<GetStudentResponse?> Get(Guid id);
}