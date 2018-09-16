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
        public static bool ActivationKeyIsValid(string computerid, string encryptcomputerid, string activationkey)
        {
            if (isAdmin || isNormal)
                return true;
            else
            {

            }
            //
            // Übersetzung per normalen Lizenz
            //
            string strnormallicense = null;
            try
            {
                strnormallicense = Crypt.DecryptString(activationkey, nomallicenseCryptkey);

            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: LicenseHandler, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.WARNING);
            }

            //
            // Übersetzung per Admin Lizenz
            //
            string stradminlicense = null;
            try
            {
                stradminlicense = Crypt.DecryptString(activationkey, adminlicenseCryptkey);
            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: LicenseHandler, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.WARNING);
            }

            //
            // Logik
            //
            try
            {
                if (computerid == GetHardwareCPUID)
                {
                    if (encryptcomputerid == strnormallicense)
                    {
                        isNormal = true;
                        return true;
                    }
                    else if (encryptcomputerid == stradminlicense)
                    {
                        isAdmin = true;
                        return true;
                    }
                }
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

            //
            // Übersetzung per normalen Lizenz
            //
            string strnormallicense = null;
            try
            {
                strnormallicense = Crypt.DecryptString(activationkey, nomallicenseCryptkey);

            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: LicenseHandler, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.WARNING);
            }

            //
            // Übersetzung per Admin Lizenz
            //
            string stradminlicense = null;
            try
            {
                stradminlicense = Crypt.DecryptString(activationkey, adminlicenseCryptkey);
            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.DebugWriteLine("ERROR: Exception thrown in class: LicenseHandler, METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.WARNING);
            }

            //
            // Logik
            //
            if (config.ConfigReadWriter.LICENSESOFTWAREIDCLEAR == strnormallicense
                || config.ConfigReadWriter.LICENSESOFTWAREIDCLEAR == stradminlicense)
            {
                config.ConfigReadWriter.LICENSEACTIVATIONKEY = activationkey;
                return true;
            }
            try
            {
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

        /// <summary>
        /// 
        /// </summary>
        /// <created>janzen_d,2018-09-16</created>
        public static bool ISADMIN
        {
            get
            {
                try
                {
                    if (isAdmin && isNormal == false)
                        return true;
                    return false;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialnumber"></param>
        /// <param name="isadmin"></param>
        /// <returns>Gibt den Aktivierungsschlüsselzurück</returns>
        public static string GenerateActivationKey(string serialnumber, bool isadmin)
        {
            try
            {
                if (isadmin)
                    return Crypt.EncryptString(serialnumber, adminlicenseCryptkey);
                return Crypt.EncryptString(serialnumber, nomallicenseCryptkey);
            }
            catch (Exception ex)
            {
                global.log.MetroLog.INSTANCE.WriteLine("Exception thrown in class: " + "LicenseHandler" + ", METHOD: " + System.Reflection.MethodBase.GetCurrentMethod() + ", EXCEPTION INFORMATION: " + ex.ToString(), global.log.MetroLog.LogType.ERROR);
            }
            return null;
        }

        private static string nomallicenseCryptkey = "uN2c9haz4XsHUYD3DvX565kfQ9q6j3C";
        private static string adminlicenseCryptkey = "87ZvjVXxAErsrZ743647zipaE9DCZUg";
        private static bool isNormal = false;
        private static bool isAdmin = false;
    }
}
