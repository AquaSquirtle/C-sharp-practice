using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public interface ILectureMaterials : IEntity<ILectureMaterials>
{
    string Name { get; }

    string ShortDescription { get; }

    string Content { get; }

    int AuthorId { get; }

    int? BaseLectureMaterialId { get; }

    void ChangeName(string newName, int userId);

    void ChangeShortDescription(string newShortDescription, int userId);

    void ChangeContent(string newContent, int userId);

    ILectureMaterials Clone();
}