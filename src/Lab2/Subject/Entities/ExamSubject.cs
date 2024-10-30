using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public class ExamSubject : ISubject
{
    private static int _nextId;

    public int Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public int PointsForExam { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseSubjectId { get; private set; }

    private readonly List<ILaboratoryWork> _labWorks = [];

    private readonly List<ILectureMaterials> _lectureMaterials = [];

    private ExamSubject()
    {
        Id = _nextId++;
    }

    public class ExamSubjectBuilder : ISubjectBuilder
    {
        private readonly ExamSubject _subject = new ExamSubject();

        public ExamSubjectBuilder SetName(string name)
        {
            _subject.Name = name;
            return this;
        }

        public ExamSubjectBuilder SetPointsForExam(int minPoints)
        {
            _subject.PointsForExam = minPoints;
            return this;
        }

        public ExamSubjectBuilder SetAuthorId(int id)
        {
            _subject.AuthorId = id;
            return this;
        }

        public ExamSubjectBuilder AddLabaratoryWork(ILaboratoryWork laboratoryWork)
        {
            _subject.AddLabWork(laboratoryWork);
            return this;
        }

        public ExamSubjectBuilder AddLectureMaterial(ILectureMaterials lectureMaterials)
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
        int points = PointsForExam;

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
        var clone = (ExamSubject)MemberwiseClone();
        clone.Id = _nextId++;
        clone.BaseSubjectId = Id;
        return clone;
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<ISubject>(this);
    }
}