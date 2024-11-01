using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public class CreditSubject : ISubject
{
    public int Id { get; }

    public string Name { get; private set; } = string.Empty;

    public int MinPoints { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseSubjectId { get; private set; }

    private readonly List<ILaboratoryWork> _labWorks = [];

    private readonly List<ILectureMaterials> _lectureMaterials = [];

    private CreditSubject()
    {
        Id = EntityCounter<ISubject>.Next();
    }

    public class CreditSubjectBuilder : ISubjectBuilder
    {
        private readonly CreditSubject _subject = new CreditSubject();

        public CreditSubjectBuilder SetName(string name)
        {
            _subject.Name = name;
            return this;
        }

        public CreditSubjectBuilder SetMinPoints(int minPoints)
        {
            _subject.MinPoints = minPoints;
            return this;
        }

        public CreditSubjectBuilder SetAuthorId(int id)
        {
            _subject.AuthorId = id;
            return this;
        }

        public CreditSubjectBuilder AddLabaratoryWork(ILaboratoryWork laboratoryWork)
        {
            _subject.AddLabWork(laboratoryWork, _subject.AuthorId);
            return this;
        }

        public CreditSubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
        {
            _subject.AddLectureMaterial(lectureMaterials, _subject.AuthorId);
            return this;
        }

        public ISubject Build()
        {
            if (!_subject.CheckAmountOfPoints())
            {
                throw new InvalidOperationException("The exam subject must have 100 points.");
            }

            return _subject;
        }
    }

    public bool CheckAmountOfPoints()
    {
        int points = 0;

        foreach (ILaboratoryWork lab in _labWorks)
        {
            points += lab.Points;
        }

        return points == 100;
    }

    public void AddLabWork(ILaboratoryWork laboratoryWork, int userId)
    {
        CheckAccessibility(userId);
        _labWorks.Add(laboratoryWork);
    }

    public void AddLectureMaterial(ILectureMaterials lectureMaterials, int userId)
    {
        CheckAccessibility(userId);
        _lectureMaterials.Add(lectureMaterials);
    }

    public ISubject Clone()
    {
        var clone = new CreditSubject
        {
            Name = this.Name,
            MinPoints = this.MinPoints,
            AuthorId = this.AuthorId,
            BaseSubjectId = this.Id,
        };
        foreach (ILaboratoryWork lab in _labWorks)
        {
            clone.AddLabWork(lab, clone.AuthorId);
        }

        foreach (ILectureMaterials lectureMaterial in _lectureMaterials)
        {
            clone.AddLectureMaterial(lectureMaterial, clone.AuthorId);
        }

        return clone;
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