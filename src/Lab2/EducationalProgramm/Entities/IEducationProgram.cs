using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public interface IEducationProgram : IEntity<IEducationProgram>
{
    string Name { get; }

    int AuthorId { get; }

    int? BaseEducationalProgramId { get; }

    void AddSubject(ISubject subject, int semesterId, int userId);

    IEducationProgram Clone();

    bool TryChangeName(string newName, int userId);
}