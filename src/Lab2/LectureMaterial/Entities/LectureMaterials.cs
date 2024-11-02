using Itmo.ObjectOrientedProgramming.Lab2.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public class LectureMaterials : ILectureMaterials
{
    public int Id { get; }

    public string Name { get; private set; }

    public string ShortDescription { get; private set; }

    public string Content { get; private set; }

    public int AuthorId { get; private set; }

    public int? BaseLectureMaterialId { get; private set; }

    public LectureMaterials(string name, string shortDescription, string content, int authorId, int? baseLectureMaterialId = null)
    {
        Id = EntityCounter<ILectureMaterials>.Next();
        Name = name;
        ShortDescription = shortDescription;
        Content = content;
        AuthorId = authorId;
        BaseLectureMaterialId = baseLectureMaterialId;
    }

    public class LectureMaterialBuilder : ILectureMaterialBuilder
    {
        private string _name = string.Empty;
        private string _shortDescription = string.Empty;
        private string _content = string.Empty;
        private int _authorId;

        public ILectureMaterials Build()
        {
            return new LectureMaterials(_name, _shortDescription, _content, _authorId);
        }

        public ILectureMaterialBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ILectureMaterialBuilder SetShortDescription(string shortDescription)
        {
            _shortDescription = shortDescription;
            return this;
        }

        public ILectureMaterialBuilder SetContent(string content)
        {
            _content = content;
            return this;
        }

        public ILectureMaterialBuilder SetAuthorId(int id)
        {
            _authorId = id;
            return this;
        }
    }

    public ILectureMaterials Clone()
    {
        return new LectureMaterials(Name, ShortDescription, Content, AuthorId, Id);
    }

    public bool TryChangeName(string newName, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        Name = newName;
        return true;
    }

    public bool TryChangeShortDescription(string newShortDescription, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        ShortDescription = newShortDescription;
        return true;
    }

    public bool TryChangeContent(string newContent, int userId)
    {
        if (!CheckAccessibility(userId)) return false;
        Content = newContent;
        return true;
    }

    private bool CheckAccessibility(int userId)
    {
        return userId == AuthorId;
    }
}
