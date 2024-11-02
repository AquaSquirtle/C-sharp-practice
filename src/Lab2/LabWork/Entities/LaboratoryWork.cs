using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public class LaboratoryWork : ILaboratoryWork
{
    public string Name { get; private set; }

    public string Description { get; private set; }

    public string EvaluationCriteria { get; private set; }

    public int Points { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseLabWorkId { get; private set; }

    public int Id { get; }

    public LaboratoryWork(string name, string description, string evaluationCriteria, int points, int authorId, int? baseLabWorkId = null)
    {
        Id = EntityCounter<ILaboratoryWork>.Next();
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        Points = points;
        AuthorId = authorId;
        BaseLabWorkId = baseLabWorkId;
    }

    public class LabWorkBuilder : ILabWorkBuilder
    {
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _evaluationCriteria = string.Empty;
        private int _points;
        private int _authorId;

        public ILabWorkBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ILabWorkBuilder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public ILabWorkBuilder SetEvaluationCriteria(string evaluationCriteria)
        {
            _evaluationCriteria = evaluationCriteria;
            return this;
        }

        public ILabWorkBuilder SetAuthorId(int authorId)
        {
            _authorId = authorId;
            return this;
        }

        public ILabWorkBuilder SetPoints(int points)
        {
            _points = points;
            return this;
        }

        public ILaboratoryWork Build()
        {
            return new LaboratoryWork(_name, _description, _evaluationCriteria, _points, _authorId);
        }
    }

    public ILaboratoryWork Clone()
    {
        return new LaboratoryWork(Name, Description, EvaluationCriteria, Points, AuthorId, Id);
    }

    public bool TryChangeName(string newName, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        Name = newName;
        return true;
    }

    public bool TryChangeDescription(string newDescription, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        Description = newDescription;
        return true;
    }

    public bool TryChangeEvaluationCriteria(string newCriteria, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        EvaluationCriteria = newCriteria;
        return true;
    }

    private bool CheckAccessibility(int userId)
    {
        return userId == AuthorId;
    }
}
