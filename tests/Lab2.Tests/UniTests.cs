using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.User.Entities;
using Xunit;

namespace Lab2.Tests;

public class UniTests
{
    [Fact]
    public void FieldAccessTestCase()
    {
        var plaform = new EducationalPlatform();
        IPlatformUser user = new PlatformUser.UserBuilder().SetName("Name").Build();
        IPlatformUser user2 = new PlatformUser.UserBuilder().SetName("Name2").Build();
        ILaboratoryWork labWork = new LaboratoryWork.LabWorkBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPoints(100)
            .Build();
        ILectureMaterials lectureMaterials = new LectureMaterials.LectureMaterialBuilder()
            .SetName("Name")
            .SetAuthorId(user.Id)
            .Build();
        ISubject subject = new ExamSubject.ExamSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPointsForExam(0)
            .AddLabaratoryWork(labWork)
            .Build();
        ISubject subject2 = new CreditSubject.CreditSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .AddLabaratoryWork(labWork)
            .Build();
        IEducationProgram program = new EducationProgram.EducationProgramBuilder().SetAuthorId(user.Id)
            .AddSubject(subject, 1)
            .AddSubject(subject2, 2)
            .SetName("Name")
            .Build();
        plaform.Add(user);
        plaform.Add(labWork);
        plaform.Add(lectureMaterials);
        plaform.Add(subject);
        plaform.Add(subject2);
        plaform.Add(program);
        plaform.Add(user2);
        Assert.Throws<FieldAccessException>(() => plaform.TryChangeLaboratoryWork(user2.Id, labWork.Id));
        Assert.Throws<FieldAccessException>(() => plaform.TryChangeLectureMaterials(user2.Id, lectureMaterials.Id));
        Assert.Throws<FieldAccessException>(() => plaform.TryChangeSubject(user2.Id, subject.Id));
        Assert.Throws<FieldAccessException>(() => plaform.TryChangeSubject(user2.Id, subject2.Id));
        Assert.Throws<FieldAccessException>(() => plaform.TryChangeEducationProgram(user2.Id, program.Id));
    }

    [Fact]
    public void CloneTestCase()
    {
        var plaform = new EducationalPlatform();
        IPlatformUser user = new PlatformUser.UserBuilder().SetName("Name").Build();
        ILaboratoryWork labWork = new LaboratoryWork.LabWorkBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPoints(100)
            .Build();
        ILectureMaterials lectureMaterials = new LectureMaterials.LectureMaterialBuilder()
            .SetName("Name")
            .SetAuthorId(user.Id)
            .Build();
        ISubject subject = new ExamSubject.ExamSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPointsForExam(0)
            .AddLabaratoryWork(labWork)
            .Build();
        ISubject subject2 = new CreditSubject.CreditSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .AddLabaratoryWork(labWork)
            .Build();
        IEducationProgram program = new EducationProgram.EducationProgramBuilder().SetAuthorId(user.Id)
            .AddSubject(subject, 1)
            .AddSubject(subject2, 2)
            .SetName("Name")
            .Build();
        ILaboratoryWork labWorkClone = labWork.Clone();
        ILectureMaterials lectureMaterialsClone = lectureMaterials.Clone();
        ISubject subjectClone = subject.Clone();
        ISubject subjectClone2 = subject2.Clone();
        IEducationProgram programClone = program.Clone();
        Assert.Equal(labWorkClone.BaseLabWorkId, labWork.Id);
        Assert.Equal(programClone.BaseEducationalProgramId, program.Id);
        Assert.Equal(lectureMaterialsClone.BaseLectureMaterialId, lectureMaterials.Id);
        Assert.Equal(subjectClone.BaseSubjectId, subject.Id);
        Assert.Equal(subjectClone2.BaseSubjectId, subject2.Id);
    }

    [Fact]
    public void SubjectPointsTestCase()
    {
        var plaform = new EducationalPlatform();
        IPlatformUser user = new PlatformUser.UserBuilder().SetName("Name").Build();
        IPlatformUser user2 = new PlatformUser.UserBuilder().SetName("Name2").Build();
        ILaboratoryWork labWork = new LaboratoryWork.LabWorkBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPoints(100)
            .Build();
        ILaboratoryWork labWork2 = new LaboratoryWork.LabWorkBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPoints(50)
            .Build();
        ExamSubject.ExamSubjectBuilder subject = new ExamSubject.ExamSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .SetPointsForExam(30)
            .AddLabaratoryWork(labWork2);
        CreditSubject.CreditSubjectBuilder subject2 = new CreditSubject.CreditSubjectBuilder().SetName("Name")
            .SetAuthorId(user.Id)
            .AddLabaratoryWork(labWork);
        Assert.Throws<InvalidOperationException>(() => subject.Build());
    }
}