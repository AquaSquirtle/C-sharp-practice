using Itmo.ObjectOrientedProgramming.Lab2.Entity;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public interface ILectureMaterials : IEntity<ILectureMaterials>
{
    string Name { get; }

    string ShortDescription { get; }

    string Content { get; }

    int AuthorId { get; }

    int? BaseLectureMaterialId { get; }

    bool TryChangeName(string newName, int userId);

    bool TryChangeShortDescription(string newShortDescription, int userId);

    bool TryChangeContent(string newContent, int userId);

    ILectureMaterials Clone();
}