using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public interface IEducationProgram : IAddable
{
    int Id { get; }

    string Name { get; set; }

    int AuthorId { get; }

    int? BaseEducationalProgramId { get; }

    void AddSubject(ISubject subject, int semesterId);

    IEducationProgram Clone();
}