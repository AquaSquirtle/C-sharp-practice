using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public class LaboratoryWork : ILaboratoryWork
{
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public string EvaluationCriteria { get; private set; } = string.Empty;

    public int Points { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseLabWorkId { get; private set; }

    public int Id { get; }

    private LaboratoryWork()
    {
        Id = EntityCounter<ILaboratoryWork>.Next();
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
        var clone = new LaboratoryWork
        {
            Name = this.Name,
            Description = this.Description,
            EvaluationCriteria = this.EvaluationCriteria,
            Points = this.Points,
            AuthorId = this.AuthorId,
            BaseLabWorkId = this.Id,
        };
        return clone;
    }

    public void ChangeName(string newName, int userId)
    {
        CheckAccessibility(userId);
        Name = newName;
    }

    public void ChangeDescription(string newDescription, int userId)
    {
        CheckAccessibility(userId);
        Description = newDescription;
    }

    public void ChangeEvaluationCriteria(string newCriteria, int userId)
    {
        CheckAccessibility(userId);
        EvaluationCriteria = newCriteria;
    }

    private void CheckAccessibility(int userId)
    {
        if (userId != AuthorId)
        {
            throw new UnauthorizedAccessException("User does not have access to this entity.");
        }
    }
}