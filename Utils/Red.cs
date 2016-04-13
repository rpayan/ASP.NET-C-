using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Ine.SihPublico.UI.Web.Utils
{
    public class Red
    {
        public static IPAddress ObtenerMascaraRed(IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
        }

        public static IPAddress ObtenerIPRed(IPAddress address, IPAddress subnetMask)
        {
            byte[] ipAdressBytes = address.GetAddressBytes();
            byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            byte[] broadcastAddress = new byte[ipAdressBytes.Length];
            for (int i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }

        public static IPAddress ObtenerIP()
        {
            var pc = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            String nombreCliente = pc.HostName;
            return pc.AddressList.Where(al => al.AddressFamily.ToString() == "InterNetwork").FirstOrDefault();
        }

        public static String ObtenerNombreEquipo()
        {
            var pc = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            return pc.HostName;
        }

    }
}