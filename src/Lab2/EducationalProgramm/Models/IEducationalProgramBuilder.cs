using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;

public interface IEducationalProgramBuilder
{
    IEducationProgram Build();

    IEducationalProgramBuilder SetName(string name);

    IEducationalProgramBuilder SetAuthorId(int authorId);

    IEducationalProgramBuilder AddSubject(ISubject subject, int semesterId);
}