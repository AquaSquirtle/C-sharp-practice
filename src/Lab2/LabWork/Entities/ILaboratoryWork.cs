using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

public interface ILaboratoryWork : IAddable
{
    string Name { get; set; }

    string Description { get; set; }

    string EvaluationCriteria { get; set; }

    int Points { get; }

    int AuthorId { get; }

    int Id { get; }

    int? BaseLabWorkId { get; }

    ILaboratoryWork Clone();
}