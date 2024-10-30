using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramm.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabWork.Models;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterial.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Subject.Models;

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

    public void Add(IAddable addable)
    {
        addable.Add();
    }

    public ILaboratoryWork TryChangeLaboratoryWork(int userId, int id)
    {
        ILaboratoryWork? labWork = DataRepository.Instance.GetEntities<ILaboratoryWork>()
            .FirstOrDefault(x => x.Id == id);
        if (labWork is null)
        {
            throw new KeyNotFoundException($"The lab {id} does not exist");
        }

        return labWork.AuthorId == userId ?
            labWork : throw new FieldAccessException("You cannot change the laboratory work");
    }

    public ILectureMaterials TryChangeLectureMaterials(int userId, int id)
    {
        ILectureMaterials? lectureMaterials = DataRepository.Instance.GetEntities<ILectureMaterials>()
            .FirstOrDefault(x => x.Id == id);
        if (lectureMaterials is null)
        {
            throw new KeyNotFoundException($"The lecture materials {id} does not exist");
        }

        return lectureMaterials.AuthorId == userId ?
            lectureMaterials : throw new FieldAccessException("You cannot change the lecture materials");
    }

    public ISubject TryChangeSubject(int userId, int id)
    {
        ISubject? subject = DataRepository.Instance.GetEntities<ISubject>()
            .FirstOrDefault(x => x.Id == id);
        if (subject is null)
        {
            throw new KeyNotFoundException($"The subject {id} does not exist");
        }

        return subject.AuthorId == userId ?
            subject : throw new FieldAccessException("You cannot change the subject");
    }

    public IEducationProgram TryChangeEducationProgram(int userId, int id)
    {
        IEducationProgram? program = DataRepository.Instance.GetEntities<IEducationProgram>()
            .FirstOrDefault(x => x.Id == id);
        if (program is null)
        {
            throw new KeyNotFoundException($"The education program {id} does not exist");
        }

        return program.AuthorId == userId ?
            program : throw new FieldAccessException("You cannot change the education program");
    }
}