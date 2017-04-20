using System.Net.Sockets;

namespace ServerProgram
{
    public interface IClientHandler
    {
        void HandleClient(TcpClient client);
    }
}