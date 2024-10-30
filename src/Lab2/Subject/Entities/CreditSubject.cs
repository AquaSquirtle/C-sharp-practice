using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public class CreditSubject : ISubject
{
    private static int _nextId;

    public int Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public int MinPoints { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseSubjectId { get; private set; }

    private readonly List<ILaboratoryWork> _labWorks = [];

    private readonly List<ILectureMaterials> _lectureMaterials = [];

    private CreditSubject()
    {
        Id = _nextId++;
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
            _subject.AddLabWork(laboratoryWork);
            return this;
        }

        public CreditSubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
        {
            _subject.AddLectureMaterial(lectureMaterials);
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

    public void AddLabWork(ILaboratoryWork laboratoryWork)
    {
        _labWorks.Add(laboratoryWork);
    }

    public void AddLectureMaterial(ILectureMaterials lectureMaterials)
    {
        _lectureMaterials.Add(lectureMaterials);
    }

    public ISubject Clone()
    {
        var clone = (CreditSubject)MemberwiseClone();
        clone.Id = _nextId++;
        clone.BaseSubjectId = Id;
        return clone;
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<ISubject>(this);
    }
}