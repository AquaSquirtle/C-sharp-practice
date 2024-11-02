using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public interface ISubject : IEntity<ISubject>
{
    string Name { get; }

    int AuthorId { get; }

    int? BaseSubjectId { get; }

    bool CheckAmountOfPoints();

    bool TryAddLabWork(ILaboratoryWork laboratoryWork, int userId);

    bool TryAddLectureMaterial(ILectureMaterials lectureMaterials, int userId);

    bool TryChangeName(string newName, int userId);

    ISubject Clone();
}