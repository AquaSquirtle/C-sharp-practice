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

    bool TryChangeName(string newName, int userId);

    bool TryChangeDescription(string newDescription, int userId);

    bool TryChangeEvaluationCriteria(string newCriteria, int userId);

    ILaboratoryWork Clone();
}