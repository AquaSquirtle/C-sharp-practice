using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public class EducationProgram : IEducationProgram
{
    private static int _nextId;

    public int Id { get; }

    public string Name { get; private set; } = string.Empty;

    public int AuthorId { get; private set; }

    private readonly ICollection<Semester> semesters = [];

    public int? BaseEducationalProgramId { get; private set; }

    private EducationProgram()
    {
        Id = _nextId++;
    }

    public void AddSubject(ISubject subject, int semesterId, int userId)
    {
        CheckAccessibility(userId);
        Semester? semester = semesters.FirstOrDefault(semester => semester.SemestrNumber == semesterId);
        if (semester == null)
        {
            var newSemester = new Semester(semesterId);
            newSemester.Subjects.Add(subject);
            semesters.Add(newSemester);
        }
        else
        {
            semester.Subjects.Add(subject);
        }
    }

    public IEducationProgram Clone()
    {
        var clone = new EducationProgram()
        {
            Name = this.Name,
            AuthorId = this.AuthorId,
            BaseEducationalProgramId = this.Id,
        };

        foreach (Semester semester in semesters)
        {
            foreach (ISubject subject in semester.Subjects)
            {
                clone.AddSubject(subject, semester.SemestrNumber, clone.AuthorId);
            }
        }

        return clone;
    }

    public class EducationProgramBuilder : IEducationalProgramBuilder
    {
        private readonly EducationProgram _program = new EducationProgram();

        public IEducationProgram Build()
        {
            return _program;
        }

        public IEducationalProgramBuilder SetName(string name)
        {
            _program.Name = name;
            return this;
        }

        public IEducationalProgramBuilder AddSubject(ISubject subject, int semesterId)
        {
            _program.AddSubject(subject, semesterId, _program.AuthorId);
            return this;
        }

        public IEducationalProgramBuilder SetAuthorId(int authorId)
        {
            _program.AuthorId = authorId;
            return this;
        }
    }

    public void ChangeName(string newName, int userId)
    {
        CheckAccessibility(userId);
        Name = newName;
    }

    private void CheckAccessibility(int userId)
    {
        if (userId != AuthorId)
        {
            throw new UnauthorizedAccessException("User does not have access to this entity.");
        }
    }
}