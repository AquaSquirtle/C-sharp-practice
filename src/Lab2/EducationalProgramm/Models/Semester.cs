using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;

public class Semester(int semesterNumber)
{
    public int SemestrNumber { get; } = semesterNumber;

    public ICollection<ISubject> Subjects { get; } = [];
}