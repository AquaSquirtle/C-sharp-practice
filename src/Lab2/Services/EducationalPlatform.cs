using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;
using Itmo.ObjectOrientedProgramming.Lab2.User.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class EducationalPlatform
{
    public ILabWorkBuilder CreateLaboratoryWork()
    {
        return new LaboratoryWork.LabWorkBuilder();
    }

    public ILectureMaterialBuilder CreateLectureMaterials()
    {
        return new LectureMaterials.LectureMaterialBuilder();
    }

    public ISubjectBuilder CreateCreditSubject()
    {
        return SubjectFactory.CreateSubject(SubjectType.Credit);
    }

    public ISubjectBuilder CreateExamSubject()
    {
        return SubjectFactory.CreateSubject(SubjectType.Exam);
    }

    public IEducationalProgramBuilder CreateEducationalProgram()
    {
        return new EducationProgram.EducationProgramBuilder();
    }

    public void AddLaboratoryWork(ILaboratoryWork labWork)
    {
        DataRepository.Instance.AddEntity(labWork);
    }

    public void AddLectureMaterials(ILectureMaterials lectureMaterials)
    {
        DataRepository.Instance.AddEntity(lectureMaterials);
    }

    public void AddSubject(ISubject subject)
    {
        DataRepository.Instance.AddEntity(subject);
    }

    public void AddEducationProgram(IEducationProgram educationProgram)
    {
        DataRepository.Instance.AddEntity(educationProgram);
    }

    public void AddUser(IPlatformUser user)
    {
        DataRepository.Instance.AddEntity(user);
    }

    public ILaboratoryWork GetLaboratoryWork(int id)
    {
        ILaboratoryWork? laboratoryWork = DataRepository.Instance
            .GetEntities<ILaboratoryWork>()
            .FirstOrDefault(x => x.Id == id);
        return laboratoryWork is null
            ? throw new KeyNotFoundException($"The laboratory work {id} does not exist")
            : laboratoryWork;
    }

    public ILectureMaterials GetLectureMaterials(int id)
    {
        ILectureMaterials? lectureMaterials = DataRepository.Instance
            .GetEntities<ILectureMaterials>()
            .FirstOrDefault(x => x.Id == id);
        return lectureMaterials is null
            ? throw new KeyNotFoundException($"The lecture materials {id} does not exist")
            : lectureMaterials;
    }

    public ISubject GetSubject(int id)
    {
        ISubject? subject = DataRepository.Instance
            .GetEntities<ISubject>()
            .FirstOrDefault(x => x.Id == id);
        return subject is null
            ? throw new KeyNotFoundException($"The lecture materials {id} does not exist")
            : subject;
    }

    public IEducationProgram GetEducationProgram(int id)
    {
        IEducationProgram? program = DataRepository.Instance
            .GetEntities<IEducationProgram>()
            .FirstOrDefault(x => x.Id == id);
        return program is null
            ? throw new KeyNotFoundException($"The lecture materials {id} does not exist")
            : program;
    }
}