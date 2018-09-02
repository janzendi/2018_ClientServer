using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace Client.Network
{
    class InterfaceNetUse
    {
        #region Driver letters
        private static InterfaceNetUse instance;
        private static Dictionary<string, bool> driveLetters;
        private static int countFreeLetters;
        private static bool listChanged = true;             // nicht wirklich in Benutzung
        private static string[] listTemporaryDriveLetters;  // nicht wirklich in Benutzung

        private InterfaceNetUse()
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            try
            {
                DriveInfo[] driveInfo = DriveInfo.GetDrives();
                driveLetters = new Dictionary<string, bool>();

                foreach (string item in Client.Properties.Settings.DRIVELETTERS)
                    driveLetters.Add(item, true);
                countFreeLetters = driveLetters.Count;

                foreach (DriveInfo item in driveInfo)
                {
                    Log.LogFile.INSTANCE.DebugWriteLine("Local used drive letter: " + item.Name.ToString());
                    if (driveLetters.ContainsKey(item.Name.ToString()))
                    {
                        driveLetters[item.Name.ToString()] = false; //nicht verbunden
                        countFreeLetters--;
                    }
                }
            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
        }

        ~InterfaceNetUse() { }

        public static InterfaceNetUse INSTANCE
        {
            get
            {
                if (instance == null)
                    instance = new InterfaceNetUse();
                return instance;
            }
        }

        public string[] DRIVELETTERS
        {
            get
            {
                if (listChanged)
                {
                    listTemporaryDriveLetters = new string[countFreeLetters];
                    int i_listTemporaryDriveLetters = 0;
                    for (int i = 0; i < driveLetters.Count; i++)
                    {
                        if (driveLetters.ElementAt(i).Value)
                            listTemporaryDriveLetters[i_listTemporaryDriveLetters++] = driveLetters.ElementAt(i).Key;
                    }

                    listChanged = false;
                }
                return listTemporaryDriveLetters;
            }
        }
        //TODO
        public int ConnectDrive(string description, string letter, string user, string password, string networkpath)
        {
            if (driveLetters.Keys.Contains(letter))
            {
                if (driveLetters[letter]) // true = Netzwerk ist verbunden
                {
                    return 1000; // Netzwerk schon verbunden
                }
                else // false = Netzwerk nicht verbunden
                {

                    driveLetters[letter] = true;    //Verbindung hergestellt
                }
            }
            return 1002; //Methode wurde nicht ausgeführt
        }
        //TODO
        public int DisconnectDrive(string letter, string networkpath_optional = null)
        {
            if (driveLetters.Keys.Contains(letter))
            {
                if (driveLetters[letter]) // true = Netzwerk ist verbunden
                {

                    driveLetters[letter] = false;   //Verbindung getrennt
                }
                else // false = Netzwerk nicht verbunden
                {
                    return 1001; //Keine Verbindung vorhanden
                }
            }
            return 1003; //Methode wurde nicht ausgeführt
        }

        #endregion

        #region API
        [DllImport("mpr.dll")] private static extern int WNetAddConnection2A(ref structNetResource pstNetRes, string psPassword, string psUsername, int piFlags);
        [DllImport("mpr.dll")] private static extern int WNetCancelConnection2A(string psName, int piFlags, int pfForce);
        [DllImport("mpr.dll")] private static extern int WNetConnectionDialog(int phWnd, int piType);
        [DllImport("mpr.dll")] private static extern int WNetDisconnectDialog(int phWnd, int piType);
        [DllImport("mpr.dll")] private static extern int WNetRestoreConnectionW(int phWnd, string psLocalDrive);

        private const int RESOURCETYPE_DISK = 0x1;
        //Standard	
        private const int CONNECT_INTERACTIVE = 0x00000008;
        private const int CONNECT_PROMPT = 0x00000010;
        private const int CONNECT_UPDATE_PROFILE = 0x00000001;
        //IE4+
        private const int CONNECT_REDIRECT = 0x00000080;
        //NT5 only
        private const int CONNECT_COMMANDLINE = 0x00000800;
        private const int CONNECT_CMD_SAVECRED = 0x00001000;

        [StructLayout(LayoutKind.Sequential)]
        private struct structNetResource
        {
            public int iScope;
            public int iType;
            public int iDisplayType;
            public int iUsage;
            public string sLocalName;
            public string sRemoteName;
            public string sComment;
            public string sProvider;
        }

        // it's required for reading/writing into the registry:
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)] static extern bool SetVolumeLabel(string lpRootPathName, string lpVolumeName);

        public int MapDrive(string driveLetter, string user, string password, string networkpath, bool promptForCredentials, bool saveCredentials, bool persistent, bool forceConnection, string description_optional = null)
        {
            Log.LogFile.INSTANCE.DebugWriteLine("Call -> " + System.Reflection.MethodBase.GetCurrentMethod());
            int i = 1;
            try
            {
                //create struct data
                structNetResource stNetRes = new structNetResource();
                stNetRes.iScope = 2;
                stNetRes.iType = RESOURCETYPE_DISK;
                stNetRes.iDisplayType = 3;
                stNetRes.iUsage = 1;
                stNetRes.sRemoteName = networkpath;
                driveLetter = driveLetter.Trim(new char[] { '\\' });
                stNetRes.sLocalName = driveLetter;
                //prepare params
                int iFlags = 0;
                if (saveCredentials) { iFlags += CONNECT_CMD_SAVECRED; } //save credentials:no
                if (persistent) { iFlags += CONNECT_UPDATE_PROFILE; } //persistent:no
                if (promptForCredentials) { iFlags += CONNECT_INTERACTIVE + CONNECT_PROMPT; }
                if (user == "") { user = null; }
                if (password == "") { password = null; }
                //if force, unmap ready for new connection
                if (forceConnection) { try { } catch { } } // zUnMapDrive(true);
                //call and return
                i = WNetAddConnection2A(ref stNetRes, password, user, iFlags);
                if (i > 0) { Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + new System.ComponentModel.Win32Exception(i).ToString()); }
                
                if (i == 0 && description_optional != null)
                {
                    // Registry Setting
                    RegistryKey rk = Registry.CurrentUser;
                    string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MountPoints2\\" + networkpath.Replace("\\", "#");
                    // I have to use CreateSubKey 
                    // (create or open it if already exits), 
                    // 'cause OpenSubKey open a subKey as read-only
                    RegistryKey sk1 = rk.CreateSubKey(subKey);
                    sk1.SetValue("_LabelFromDesktopINI", description_optional);
                }
            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
            return i;
        }

        // Unmap network drive
        public void UnMapDrive(string driveLetter, bool forceCommand, bool persistent, string networkpath_optional = null)
        {
            try
            {
                //call unmap and return
                driveLetter = driveLetter.Trim(new char[] { '\\' });
                int iFlags = 0;
                if (persistent) { iFlags += CONNECT_UPDATE_PROFILE; }
                int i = WNetCancelConnection2A(driveLetter, iFlags, Convert.ToInt32(forceCommand));
                if (i > 0) { Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + new System.ComponentModel.Win32Exception(i).ToString()); }

                if (i == 0 && networkpath_optional != null)
                {
                    // Registry Setting
                    RegistryKey rk = Registry.CurrentUser;
                    string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\MountPoints2\\" + networkpath_optional.Replace("\\", "#");
                    // I have to use CreateSubKey 
                    // (create or open it if already exits), 
                    // 'cause OpenSubKey open a subKey as read-only
                    RegistryKey sk1 = rk.CreateSubKey(subKey);
                    sk1.SetValue("_LabelFromDesktopINI", "");
                }
            }
            catch (Exception e)
            {
                Log.LogFile.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: " + this.ToString() + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + e.ToString());
            }
        }

        public bool SendPing(string ipAddress)
        {
            PingReply reply = new Ping().Send(ipAddress);
            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }

        #endregion
    }
}