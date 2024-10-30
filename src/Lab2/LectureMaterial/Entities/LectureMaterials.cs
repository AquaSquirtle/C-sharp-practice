using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public class LectureMaterials : ILectureMaterials
{
    private static int _nextId;

    public int Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public string ShortDescription { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public int AuthorId { get; private set; }

    public int? BaseLectureMaterialId { get; private set; }

    private LectureMaterials()
    {
        Id = _nextId++;
    }

    public class LectureMaterialBuilder : ILectureMaterialBuilder
    {
        private readonly LectureMaterials _lectureMaterials = new LectureMaterials();

        public ILectureMaterials Build()
        {
            return _lectureMaterials;
        }

        public ILectureMaterialBuilder SetName(string name)
        {
            _lectureMaterials.Name = name;
            return this;
        }

        public ILectureMaterialBuilder SetShortDescription(string shortDescription)
        {
            _lectureMaterials.ShortDescription = shortDescription;
            return this;
        }

        public ILectureMaterialBuilder SetContent(string content)
        {
            _lectureMaterials.Content = content;
            return this;
        }

        public ILectureMaterialBuilder SetAuthorId(int id)
        {
            _lectureMaterials.AuthorId = id;
            return this;
        }
    }

    public ILectureMaterials Clone()
    {
        var clone = (LectureMaterials)MemberwiseClone();
        clone.Id = _nextId++;
        clone.BaseLectureMaterialId = Id;
        return clone;
    }

    public void Add()
    {
        DataRepository.Instance.AddEntity<ILectureMaterials>(this);
    }
}