    using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Entities;

    namespace Itmo.ObjectOrientedProgramming.Lab4.Validators.CommandValidators;

    public abstract class CommandValidator : ICommandValidator
    {
        private ICommandValidator? _next;

        public ICommandValidator SetNext(ICommandValidator nextValidator)
        {
            _next = nextValidator;
            return nextValidator;
        }

        public virtual void Validate(FileSystemContext fileSystem)
        {
            PerformValidation(fileSystem);
            _next?.Validate(fileSystem);
        }

        protected abstract void PerformValidation(FileSystemContext fileSystem);
    }
