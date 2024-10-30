using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

public class SubjectFactory
{
    public static ISubjectBuilder CreateSubject(SubjectType subjectType)
    {
        return subjectType switch
        {
            SubjectType.Credit => new CreditSubject.CreditSubjectBuilder(),
            SubjectType.Exam => new ExamSubject.ExamSubjectBuilder(),
            _ => throw new ArgumentException("Unknown subject type"),
        };
    }
}