using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public class EducationProgram : IEducationProgram
{
    private static int _nextId;

    public int Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public int AuthorId { get; private set; }

    private readonly ICollection<Semester> semesters = [];

    public int? BaseEducationalProgramId { get; private set; }

    private EducationProgram()
    {
        Id = _nextId++;
    }

    public void AddSubject(ISubject subject, int semesterId)
    {
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
        var clone = (EducationProgram)MemberwiseClone();
        clone.Id = _nextId++;
        clone.BaseEducationalProgramId = Id;
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
            _program.AddSubject(subject, semesterId);
            return this;
        }

        public IEducationalProgramBuilder SetAuthorId(int authorId)
        {
            _program.AuthorId = authorId;
            return this;
        }
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<IEducationProgram>(this);
    }
}