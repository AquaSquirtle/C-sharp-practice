namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

public class PositionalArgumentValidator : ArgumentValidator
{
    private readonly int _requiredLength;

    public PositionalArgumentValidator(int requiredLength)
    {
        _requiredLength = requiredLength;
    }

    protected override void PerformValidation(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        if (positionalArguments.Count != _requiredLength)
        {
            throw new ArgumentException("Positional argument count mismatch");
        }
    }
}