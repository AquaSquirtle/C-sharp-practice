using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;

public interface ILectureMaterialBuilder
{
    public ILectureMaterials Build();

    public ILectureMaterialBuilder SetName(string name);

    public ILectureMaterialBuilder SetShortDescription(string shortDescription);

    public ILectureMaterialBuilder SetContent(string content);

    public ILectureMaterialBuilder SetAuthorId(int id);
}