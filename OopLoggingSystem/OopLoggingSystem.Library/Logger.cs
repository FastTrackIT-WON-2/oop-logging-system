namespace OopLoggingSystem.Library
{
    public abstract class Logger
    {
        public abstract void Write(Severity severity, string message);
    }
}
