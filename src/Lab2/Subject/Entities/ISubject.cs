using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public interface ISubject
{
    int Id { get; }

    string Name { get; }

    int AuthorId { get; }

    int? BaseSubjectId { get; }

    bool CheckAmountOfPoints();

    void AddLabWork(ILaboratoryWork laboratoryWork, int userId);

    void AddLectureMaterial(ILectureMaterials lectureMaterials, int userId);

    void ChangeName(string newName, int userId);

    ISubject Clone();
}