namespace DepencyInjectionLifeTTime.Models
{
    public interface IGuidGenerator
    {
        Guid Guid { get; }
    }

    public interface ISingleton : IGuidGenerator { }
    public interface ITransient : IGuidGenerator { }
    public interface IScoped : IGuidGenerator { }

    public class Singleton : ISingleton
    {
        public Singleton()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }
    public class Transient : ITransient
    {
        public Transient()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }
    public class Scoped : IScoped
    {
        public Scoped()
        {
            Guid = Guid.NewGuid();
        }
        public Guid Guid { get; }
    }


    public class GuidService
    {
        public ISingleton Singleton { get; set; }
        public ITransient Transient { get; set; }

        public IScoped Scoped { get; set; }

        public GuidService(ISingleton singleton, ITransient transient, IScoped scoped)
        {
            Singleton = singleton;
            Transient = transient;
            Scoped = scoped;
        }
    }


}

