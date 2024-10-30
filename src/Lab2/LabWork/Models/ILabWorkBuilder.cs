using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;

public interface ILabWorkBuilder
{
    ILaboratoryWork Build();

    ILabWorkBuilder SetName(string name);

    ILabWorkBuilder SetDescription(string description);

    ILabWorkBuilder SetAuthorId(int authorId);

    ILabWorkBuilder SetPoints(int points);

    ILabWorkBuilder SetEvaluationCriteria(string evaluationCriteria);
}