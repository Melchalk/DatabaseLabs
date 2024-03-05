using Business.Interfaces;
using DTOs.Response;
using Repository.Interfaces;

namespace Business;

public class GetCommand : IGetCommand
{
    private IStudentsRepository _repository;

    public GetCommand(IStudentsRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetStudentResponse?> ExecuteAsync(Guid id)
    {
        return await _repository.Get(id); ;
    }
}
