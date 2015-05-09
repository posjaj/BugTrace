using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Management;


namespace IPProvider
{
    class WMIForIPSet
    {
        public WMIForIPSet()
        {

        }
        /// <summary>
        /// 设置IP地址信息
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="gatway"></param>
        /// <param name="dns"></param>
        public static void SetIPAddress(string[] ip, string[] submask, string[] gatway, string[] dns)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过
                if (!(bool)mo["IPEnabled"])
                {
                    continue;
                }
                //设置IP地址和掩码

                if (ip != null && submask != null)
                {
                    inPar = mo.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = ip;
                    inPar["SubnetMask"] = submask;
                    outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                }

                //设置网关地址

                if (gatway != null)
                {
                    inPar = mo.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = gatway;
                    outPar = mo.InvokeMethod("SetGateways", inPar, null);
                }

                //设置DNS地址

                if (dns != null)
                {
                    inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    inPar["DNSServerSearchOrder"] = dns;
                    outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
            }
        }
        /// <summary>
        /// 开启DHCP
        /// </summary>
        public static void EnableDHCP()
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //如果没有启用IP设置的网络设备则跳过

                if (!(bool)mo["IPEnabled"])
                    continue;

                //重置DNS为空

                mo.InvokeMethod("SetDNSServerSearchOrder", null);
                //开启DHCP

                mo.InvokeMethod("EnableDHCP", null);
            }
        }
        /// <summary>
        /// 判断IP地址的合法性
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIPAddress(string ip)
        {
            string[] arr = ip.Split('.');
            if (arr.Length != 4)
                return false;

            string pattern = @"\d{1,3}";
            for (int i = 0; i < arr.Length; i++)
            {
                string d = arr[i];
                if (i == 0 && d == "0")
                    return false;
                if (!Regex.IsMatch(d, pattern))
                    return false;

                if (d != "0")
                {
                    d = d.TrimStart('0');
                    if (d == "")
                        return false;

                    if (int.Parse(d) > 255)
                        return false;
                }
            }

            return true;
        }
        /// <summary>

        /// 设置DNS

        /// </summary>

        /// <param name="dns"></param>

        public static void SetDNS(string[] dns)
        {
            SetIPAddress(null, null, null, dns);
        }
        /// <summary>

        /// 设置网关

        /// </summary>

        /// <param name="getway"></param>

        public static void SetGetWay(string getway)
        {
            SetIPAddress(null, null, new string[] { getway }, null);
        }
        /// <summary>

        /// 设置网关

        /// </summary>

        /// <param name="getway"></param>

        public static void SetGetWay(string[] getway)
        {
            SetIPAddress(null, null, getway, null);
        }
        /// <summary>

        /// 设置IP地址和掩码

        /// </summary>

        /// <param name="ip"></param>

        /// <param name="submask"></param>

        public static void SetIPAddress(string ip, string submask)
        {
            SetIPAddress(new string[] { ip }, new string[] { submask }, null, null);
        }
        /// <summary>

        /// 设置IP地址，掩码和网关

        /// </summary>

        /// <param name="ip"></param>

        /// <param name="submask"></param>

        /// <param name="getway"></param>

        public static void SetIPAddress(string ip, string submask, string getway)
        {
            SetIPAddress(new string[] { ip }, new string[] { submask }, new string[] { getway }, null);
        }
    }
}
