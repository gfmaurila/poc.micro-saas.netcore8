namespace Common.External.Auth.Net8.Interface;

public interface IMessageBusService
{
    void Publish(string queue, byte[] message);
}
