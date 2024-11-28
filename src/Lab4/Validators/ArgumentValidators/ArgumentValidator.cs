namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

public abstract class ArgumentValidator : IArgumentValidator
{
    private IArgumentValidator? _next;

    public IArgumentValidator SetNext(IArgumentValidator nextValidator)
    {
        _next = nextValidator;
        return nextValidator;
    }

    public virtual void Validate(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        PerformValidation(flagArguments, positionalArguments);
        _next?.Validate(flagArguments, positionalArguments);
    }

    protected abstract void PerformValidation(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments);
}