using System.Net.Sockets;
using System.Text;

public class PPMAC
{
 TcpClient client;
 NetworkStream stream;

 public void Connect(string ip)
 {
 client = new TcpClient(ip, 23);
 stream = client.GetStream();
 }

 public void Write(string cmd)
 {
 byte[] data = Encoding.ASCII.GetBytes(cmd + "
");
 stream.Write(data, 0, data.Length);
 }

 public string Read()
 {
 byte[] buf = new byte[1024];
 int len = stream.Read(buf, 0, buf.Length);
 return Encoding.ASCII.GetString(buf, 0, len);
 }
}
