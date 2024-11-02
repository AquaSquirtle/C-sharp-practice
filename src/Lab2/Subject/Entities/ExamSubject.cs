using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public class ExamSubject : ISubject
{
    public int Id { get; }

    public string Name { get; private set; }

    public int PointsForExam { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseSubjectId { get; private set; }

    private readonly List<ILaboratoryWork> _labWorks = new();

    private readonly List<ILectureMaterials> _lectureMaterials = new();

    public ExamSubject(string name, int pointsForExam, int authorId, int? baseSubjectId = null)
    {
        Id = EntityCounter<ISubject>.Next();
        Name = name;
        PointsForExam = pointsForExam;
        AuthorId = authorId;
        BaseSubjectId = baseSubjectId;
    }

    public class ExamSubjectBuilder : ISubjectBuilder
    {
        private readonly List<ILaboratoryWork> _labWorks = new();
        private readonly List<ILectureMaterials> _lectureMaterials = new();
        private string _name = string.Empty;
        private int _pointsForExam;
        private int _authorId;

        public ExamSubjectBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ExamSubjectBuilder SetPointsForExam(int pointsForExam)
        {
            _pointsForExam = pointsForExam;
            return this;
        }

        public ExamSubjectBuilder SetAuthorId(int id)
        {
            _authorId = id;
            return this;
        }

        public ExamSubjectBuilder AddLaboratoryWork(ILaboratoryWork laboratoryWork)
        {
            _labWorks.Add(laboratoryWork);
            return this;
        }

        public ExamSubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
        {
            _lectureMaterials.Add(lectureMaterials);
            return this;
        }

        public ISubject Build()
        {
            var subject = new ExamSubject(_name, _pointsForExam, _authorId);

            foreach (ILaboratoryWork lab in _labWorks)
            {
                subject._labWorks.Add(lab);
            }

            foreach (ILectureMaterials lectureMaterial in _lectureMaterials)
            {
                subject._lectureMaterials.Add(lectureMaterial);
            }

            if (!subject.CheckAmountOfPoints())
            {
                throw new InvalidOperationException("The exam subject must have 100 points.");
            }

            return subject;
        }
    }

    public bool CheckAmountOfPoints()
    {
        int points = PointsForExam + _labWorks.Sum(lab => lab.Points);
        return points == 100;
    }

    public bool TryAddLabWork(ILaboratoryWork laboratoryWork, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        _labWorks.Add(laboratoryWork);
        return true;
    }

    public bool TryAddLectureMaterial(ILectureMaterials lectureMaterials, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        _lectureMaterials.Add(lectureMaterials);
        return true;
    }

    public ISubject Clone()
    {
        var clone = new ExamSubject(Name, PointsForExam, AuthorId, Id);
        foreach (ILaboratoryWork lab in _labWorks)
        {
            clone._labWorks.Add(lab);
        }

        foreach (ILectureMaterials lectureMaterial in _lectureMaterials)
        {
            clone._lectureMaterials.Add(lectureMaterial);
        }

        return clone;
    }

    public bool TryChangeName(string newName, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        Name = newName;
        return true;
    }

    private bool CheckAccessibility(int userId)
    {
        return userId == AuthorId;
    }
}
