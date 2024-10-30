using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;

public class LectureMaterials : ILectureMaterials
{
    private static int _nextId;

    public int Id { get; }

    public string Name { get; private set; } = string.Empty;

    public string ShortDescription { get; private set; } = string.Empty;

    public string Content { get; private set; } = string.Empty;

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
        var clone = new LectureMaterials
        {
            Name = this.Name,
            ShortDescription = this.ShortDescription,
            Content = this.Content,
            AuthorId = this.AuthorId,
            BaseLectureMaterialId = this.Id,
        };

        return clone;
    }

    public void ChangeName(string newName, int userId)
    {
        CheckAccessibility(userId);
        Name = newName;
    }

    public void ChangeShortDescription(string newShortDescription, int userId)
    {
        CheckAccessibility(userId);
        ShortDescription = newShortDescription;
    }

    public void ChangeContent(string newContent, int userId)
    {
        CheckAccessibility(userId);
        Content = newContent;
    }

    private void CheckAccessibility(int userId)
    {
        if (userId != AuthorId)
        {
            throw new UnauthorizedAccessException("User does not have access to this entity.");
        }
    }
}