namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public interface ILaboratoryWork
{
    string Name { get; }

    string Description { get; }

    string EvaluationCriteria { get; }

    int Points { get; }

    int AuthorId { get; }

    int Id { get; }

    int? BaseLabWorkId { get; }

    void ChangeName(string newName, int userId);

    void ChangeDescription(string newDescription, int userId);

    void ChangeEvaluationCriteria(string newCriteria, int userId);

    ILaboratoryWork Clone();
}