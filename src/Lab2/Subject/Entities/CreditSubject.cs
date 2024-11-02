using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public class CreditSubject : ISubject
{
    public int Id { get; }

    public string Name { get; private set; }

    public int MinPoints { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseSubjectId { get; private set; }

    private readonly List<ILaboratoryWork> _labWorks = new();

    private readonly List<ILectureMaterials> _lectureMaterials = new();

    public CreditSubject(string name, int minPoints, int authorId, int? baseSubjectId = null)
    {
        Id = EntityCounter<ISubject>.Next();
        Name = name;
        MinPoints = minPoints;
        AuthorId = authorId;
        BaseSubjectId = baseSubjectId;
    }

    public class CreditSubjectBuilder : ISubjectBuilder
    {
        private readonly List<ILaboratoryWork> _labWorks = new();
        private readonly List<ILectureMaterials> _lectureMaterials = new();
        private string _name = string.Empty;
        private int _minPoints;
        private int _authorId;

        public CreditSubjectBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public CreditSubjectBuilder SetMinPoints(int minPoints)
        {
            _minPoints = minPoints;
            return this;
        }

        public CreditSubjectBuilder SetAuthorId(int id)
        {
            _authorId = id;
            return this;
        }

        public CreditSubjectBuilder AddLaboratoryWork(ILaboratoryWork laboratoryWork)
        {
            _labWorks.Add(laboratoryWork);
            return this;
        }

        public CreditSubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
        {
            _lectureMaterials.Add(lectureMaterials);
            return this;
        }

        public ISubject Build()
        {
            var subject = new CreditSubject(_name, _minPoints, _authorId);

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
        int points = _labWorks.Sum(lab => lab.Points);
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
        var clone = new CreditSubject(Name, MinPoints, AuthorId, Id);
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
