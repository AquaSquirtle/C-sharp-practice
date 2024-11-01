using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.User.Entities;
using Xunit;

namespace Lab2.Tests;

public class UniTests
{
    [Fact]
    public void FieldAccessTestCase()
    {
        var userRepo = new DataRepository<IPlatformUser>();
        var laboratoryRepo = new DataRepository<ILaboratoryWork>();
        var lectureMaterialRepo = new DataRepository<ILectureMaterials>();
        var subjectRepo = new DataRepository<ISubject>();
        var educationProgramRepo = new DataRepository<IEducationProgram>();

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
        userRepo.Add(user);
        laboratoryRepo.Add(labWork);
        lectureMaterialRepo.Add(lectureMaterials);
        subjectRepo.Add(subject);
        subjectRepo.Add(subject2);
        educationProgramRepo.Add(program);
        userRepo.Add(user2);
        Assert.Throws<UnauthorizedAccessException>(() => labWork.ChangeName("New name", user2.Id));
        Assert.Throws<UnauthorizedAccessException>(() => lectureMaterials.ChangeName("New name", user2.Id));
        Assert.Throws<UnauthorizedAccessException>(() => subject2.ChangeName("New name", user2.Id));
        Assert.Throws<UnauthorizedAccessException>(() => subject.ChangeName("New name", user2.Id));
        Assert.Throws<UnauthorizedAccessException>(() => program.ChangeName("New name", user2.Id));
    }

    [Fact]
    public void CloneTestCase()
    {
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