using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

public interface ISubject : IAddable
{
    int Id { get; }

    string Name { get; set; }

    int AuthorId { get; }

    int? BaseSubjectId { get; }

    bool CheckAmountOfPoints();

    public void AddLabWork(ILaboratoryWork laboratoryWork);

    public void AddLectureMaterial(ILectureMaterials lectureMaterials);

    public ISubject Clone();
}