using DTOs.Response;

namespace Business.Interfaces;

public interface IGetCommand
{
    Task<GetStudentResponse?> ExecuteAsync(Guid id);
}
