using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public interface ILectureMaterials : IAddable
{
    int Id { get; }

    string Name { get; set; }

    string ShortDescription { get; set; }

    string Content { get; set; }

    int AuthorId { get; }

    int? BaseLectureMaterialId { get; }

    ILectureMaterials Clone();
}