namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

public interface IArgumentValidator
{
    void Validate(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments);

    IArgumentValidator? SetNext(IArgumentValidator nextValidator);
}