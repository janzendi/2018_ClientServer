using System;
using System.Management;

namespace Client.global.readme.license
{
    static class LicenseHandler
    {
        /// <summary>
        /// Gibt eine zufällige Seriennummer zurück
        /// Random Number from list between: 1000000, 2147483647
        /// </summary>
        /// <returns>gibt eine Random Seriennumer zurück</returns>
        /// <created>janzen_d,2018-09-13</created>
        private static string GetRandomNumber
        {
            get
            {
                try
                {
                    return (new Random()).Next(1000000, 2147483647).ToString().ToString();
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
        /// Normale Lizenz => uN2c9haz4XsHUYD3DvX565kfQ9q6j3C
        /// Admin Lizenz => 87ZvjVXxAErsrZ743647zipaE9DCZUg
        /// </summary>
        /// <returns></returns>
        /// <created>janzen_d,2018-09-13</created>
        public static bool ActivationKeyIsValid(string computerid, string activationkey)
        {
            try //TODO Activiation key logic muss noch programmiert werden.
            {
                if (computerid == GetHardwareCPUID && (activationkey == Crypt.EncryptString(computerid, nomallicenseCryptkey) || activationkey == Crypt.EncryptString(computerid, adminlicenseCryptkey)))
                    return true;
            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: LicenseHandler, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.ERROR);
                return false;
            }
            return false;
        }
        
        /// <summary>
        /// Methode um Software zu aktivieren.
        /// </summary>
        /// <param name="activationkey"></param>
        /// <returns></returns>
        public static bool ActivateSoftware(string activationkey)
        {
            try
            {
                if (activationkey == Crypt.EncryptString(config.ConfigReadWriter.LICENSESOFTWAREIDCLEAR, nomallicenseCryptkey)
                    || activationkey == Crypt.EncryptString(config.ConfigReadWriter.LICENSESOFTWAREIDCLEAR, adminlicenseCryptkey))
                {
                    config.ConfigReadWriter.LICENSEACTIVATIONKEY = activationkey;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        /// <summary>
        /// Gibt die Software ID zurück
        /// </summary>
        /// <created>janzen_d,2018-09-16</created>
        public static string SOFTWAREID
        {
            get
            {
                try
                {
                    if (!config.ConfigReadWriter.VALIDLICENSE)
                    {
                        string sn = GetRandomNumber;
                        config.ConfigReadWriter.LICENSESN = sn;
                        string id = GetHardwareCPUID;
                        config.ConfigReadWriter.LICENSESOFTWAREIDCRYPT = id;
                    }
                    return config.ConfigReadWriter.LICENSESOFTWAREIDCLEAR;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        private static string nomallicenseCryptkey = "uN2c9haz4XsHUYD3DvX565kfQ9q6j3C";
        private static string adminlicenseCryptkey = "87ZvjVXxAErsrZ743647zipaE9DCZUg";
    }
}
