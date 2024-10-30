using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public class LaboratoryWork : ILaboratoryWork
{
    private static int _nextId;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string EvaluationCriteria { get; set; } = string.Empty;

    public int Points { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseLabWorkId { get; private set; }

    public int Id { get; private set; }

    private LaboratoryWork()
    {
        Id = _nextId++;
    }

    public class LabWorkBuilder : ILabWorkBuilder
    {
        private readonly LaboratoryWork _laboratoryWork = new LaboratoryWork();

        public ILabWorkBuilder SetName(string name)
        {
            _laboratoryWork.Name = name;
            return this;
        }

        public ILabWorkBuilder SetDescription(string description)
        {
            _laboratoryWork.Description = description;
            return this;
        }

        public ILabWorkBuilder SetEvaluationCriteria(string evaluationCriteria)
        {
            _laboratoryWork.EvaluationCriteria = evaluationCriteria;
            return this;
        }

        public ILabWorkBuilder SetAuthorId(int authorId)
        {
            _laboratoryWork.AuthorId = authorId;
            return this;
        }

        public ILabWorkBuilder SetPoints(int points)
        {
            _laboratoryWork.Points = points;
            return this;
        }

        public ILaboratoryWork Build()
        {
            return _laboratoryWork;
        }
    }

    public ILaboratoryWork Clone()
    {
        var clone = (LaboratoryWork)MemberwiseClone();
        clone.Id = _nextId++;
        clone.BaseLabWorkId = Id;
        return clone;
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<ILaboratoryWork>(this);
    }
}