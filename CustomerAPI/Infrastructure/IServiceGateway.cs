namespace CustomerAPI.Infrastructure
{
    public interface IServiceGateway<T>
    {
        T Get(int id);
    }
}
