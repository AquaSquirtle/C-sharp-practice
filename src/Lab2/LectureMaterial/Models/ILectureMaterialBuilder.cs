using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;

public interface ILectureMaterialBuilder
{
    ILectureMaterials Build();

    ILectureMaterialBuilder SetName(string name);

    ILectureMaterialBuilder SetShortDescription(string shortDescription);

    ILectureMaterialBuilder SetContent(string content);

    ILectureMaterialBuilder SetAuthorId(int id);
}