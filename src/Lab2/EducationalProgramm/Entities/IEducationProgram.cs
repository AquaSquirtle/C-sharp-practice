using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public interface IEducationProgram
{
    int Id { get; }

    string Name { get; }

    int AuthorId { get; }

    int? BaseEducationalProgramId { get; }

    void AddSubject(ISubject subject, int semesterId, int userId);

    IEducationProgram Clone();

    void ChangeName(string newName, int userId);
}