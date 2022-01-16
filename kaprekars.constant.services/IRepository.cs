using kaprekars.constant.data;
namespace kaprekars.constant.services;

public interface IRepository
{
    IEnumerable<Routine> GetRoutines(Request request);
    Routine GetRoutine(int number);
}
