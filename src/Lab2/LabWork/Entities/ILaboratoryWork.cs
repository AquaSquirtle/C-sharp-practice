using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public interface ILaboratoryWork : IEntity<ILaboratoryWork>
{
    string Name { get; }

    string Description { get; }

    string EvaluationCriteria { get; }

    int Points { get; }

    int AuthorId { get; }

    int? BaseLabWorkId { get; }

    void ChangeName(string newName, int userId);

    void ChangeDescription(string newDescription, int userId);

    void ChangeEvaluationCriteria(string newCriteria, int userId);

    ILaboratoryWork Clone();
}