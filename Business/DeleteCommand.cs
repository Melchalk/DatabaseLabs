using Business.Interfaces;
using Repository.Interfaces;

namespace Business;

public class DeleteCommand : IDeleteCommand
{
    private IStudentsRepository _repository;

    public DeleteCommand(IStudentsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        _repository.Delete(id);
    }
}