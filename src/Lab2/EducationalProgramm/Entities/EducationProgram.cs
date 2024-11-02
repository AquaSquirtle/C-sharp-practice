using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;

public class EducationProgram : IEducationProgram
{
    public int Id { get; }

    public string Name { get; private set;  } = string.Empty;

    public int AuthorId { get; private set;  }

    private readonly ICollection<Semester> _semesters = [];

    public int? BaseEducationalProgramId { get; private set; }

    public EducationProgram(string name, int authorId, int? baseEducationalProgramId = null)
    {
        Name = name;
        AuthorId = authorId;
        Id = EntityCounter<IEducationProgram>.Next();
        BaseEducationalProgramId = baseEducationalProgramId;
    }

    public void AddSubject(ISubject subject, int semesterId, int userId)
    {
        CheckAccessibility(userId);
        Semester? semester = _semesters.FirstOrDefault(semester => semester.SemestrNumber == semesterId);
        if (semester == null)
        {
            var newSemester = new Semester(semesterId);
            newSemester.Subjects.Add(subject);
            _semesters.Add(newSemester);
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

        foreach (Semester semester in _semesters)
        {
            foreach (ISubject subject in semester.Subjects)
            {
                clone.AddSubject(subject.Clone(), semester.SemestrNumber, clone.AuthorId);
            }
        }

        return clone;
    }

    public class EducationProgramBuilder : IEducationalProgramBuilder
    {
        private readonly List<Semester> _semesters = new List<Semester>();
        private string _name = string.Empty;
        private int _authorId;

        public IEducationProgram Build()
        {
            var program = new EducationProgram(_name, _authorId);

            foreach (Semester semester in _semesters)
            {
                foreach (ISubject subject in semester.Subjects)
                {
                    program.AddSubject(subject, semester.SemestrNumber, program.AuthorId);
                }
            }

            return program;
        }

        public IEducationalProgramBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public IEducationalProgramBuilder AddSubject(ISubject subject, int semesterId)
        {
            Semester? semester = _semesters.FirstOrDefault(semester => semester.SemestrNumber == semesterId);
            if (semester == null)
            {
                var newSemester = new Semester(semesterId);
                newSemester.Subjects.Add(subject);
                _semesters.Add(newSemester);
            }
            else
            {
                semester.Subjects.Add(subject);
            }

            return this;
        }

        public IEducationalProgramBuilder SetAuthorId(int authorId)
        {
            _authorId = authorId;
            return this;
        }
    }

    public bool TryChangeName(string newName, int userId)
    {
        if (!CheckAccessibility(userId))
        {
            return false;
        }

        Name = newName;
        return true;
    }

    private bool CheckAccessibility(int userId)
    {
        return userId == AuthorId;
    }

    private EducationProgram() { }
}