using System;
using System.Management;

namespace Client.global.readme.license
{
    static class LicenseHandler
    {
        /// <summary>
        /// Gibt eine zufällige Seriennummer zurück
        /// </summary>
        /// <returns>gibt eine Random Seriennumer zurück</returns>
        /// <created>janzen_d,2018-09-13</created>
        private static string GetSerialNumber
        {
            get
            {
                try
                {
                    return SerialNumbers.serialnumbers[(new Random()).Next(SerialNumbers.serialnumbers.Count)].ToString();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Gibt die aktuelle CPU ID von der ersten Sub-CPU zurück
        /// </summary>
        /// <created>janzen_d,2018-09-13</created>
        private static string GetHardwareCPUID
        {
            get
            {
                try
                {
                    //Get only the first CPU's ID
                    foreach (ManagementObject mo in (new ManagementClass("win32_processor")).GetInstances())
                         return mo.Properties["processorID"].Value.ToString();
                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }
        }

        /// <summary>
        /// Gibt den Aktivierungsstatus zurück.
        /// </summary>
        /// <returns></returns>
        /// <created>janzen_d,2018-09-13</created>
        public static bool ActivationKeyIsValid(string serialnumber, string computerid, string activationkey)
        {
            try
            {
                if (computerid == Crypt.DecryptString(activationkey, serialnumber))
                    return true;
            }
            catch (Exception)
            {

                throw; //TODO
            }
            return false;
        }

        public static string SOFTWARESERIAL
        {
            get
            {
                try
                {

                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }
        }
    }
}
