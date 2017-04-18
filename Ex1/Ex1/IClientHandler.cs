using System.Net.Sockets;

namespace Ex1
{
    public interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}