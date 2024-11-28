namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.ArgumentValidators;

public class ModeArgumentValidator : ArgumentValidator
{
    private readonly string _requiredMode;

    public ModeArgumentValidator(string requiredMode)
    {
        _requiredMode = requiredMode;
    }

    protected override void PerformValidation(
        SortedDictionary<string, string> flagArguments,
        ICollection<string> positionalArguments)
    {
        if (!flagArguments.ContainsKey(_requiredMode))
        {
            throw new ArgumentException($"flag named {_requiredMode} not found.");
        }
    }
}