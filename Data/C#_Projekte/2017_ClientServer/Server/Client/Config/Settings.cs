namespace Client.Properties {

    // This class allows you to handle specific events on the settings class:
    //  The SettingChanging event is raised before a setting's value is changed.
    //  The PropertyChanged event is raised after a setting's value is changed.
    //  The SettingsLoaded event is raised after the setting values are loaded.
    //  The SettingsSaving event is raised before the setting values are saved.
    internal sealed partial class Settings {
        
        public Settings() {
            // // To add event handlers for saving and changing settings, uncomment the lines below:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Add code to handle the SettingChangingEvent event here.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Add code to handle the SettingsSaving event here.
        }

        /// <summary>
        /// Eigenschaft die definiert ob Debugmode aktiviert ist.
        /// </summary>
        public static bool DEBUGENABLED
        {
            get
            {
                return Settings.Default.DebugModeEnabled;
            }
        }
        /// <summary>
        /// Eigenschaft die definiert, zu welchem Server verbunden wird.
        /// </summary>
        public static string SERVERIPADDRESS
        {
            get
            {
                return Settings.Default.ServerIPAddress;
            }
        }
        /// <summary>
        /// Eigenschaft die definiert über welchen Socket Port kommuniziert wird.
        /// </summary>
        public static int SERVERPORT
        {
            get
            {
                return Settings.Default.ServerPort;
            }
        }
        /// <summary>
        /// Config für Standardfile.
        /// </summary>
        public static string CONFIGFILEDEFAULT
        {
            get
            {
                return Settings.Default.ConfigFileDefault;
            }
        }

        /// <summary>
        /// Buchstaben für Netzlaufwerke
        /// </summary>
        public static string[] DRIVELETTERS
        {
            get
            {
                return Settings.Default.DriveLetters.Split(';');
            }
        }

        /// <summary>
        /// XML Languagefile
        /// </summary>
        public static string LANGUAGEFILE
        {
            get
            {
                return Settings.Default.LanguageFile;
            }
        }

        /// <summary>
        /// XML Alarmfile
        /// </summary>
        public static string ALARMFILE
        {
            get
            {
                return Settings.Default.AlarmFile;
            }
        }

        /// <summary>
        /// Liste für Twizard OPC Standard. Diese wird genutzt um semantic Feld zu überprüfen
        /// </summary>
        public static string[] DCANALOGSEMANTIC
        {
            get
            {
                return Settings.Default.DCAnalogSemantic.Split(';');
            }
        }

        /// <summary>
        /// OPC Standard-Variablen
        /// </summary>
        public static string[] OPCStandardVariables
        {
            get
            {
                return Settings.Default.OPCVariables.Split(';');
            }
        }

        /// <summary>
        /// BatchVarPrefix
        /// </summary>
        public static string BATCHVARPREFIX
        {
            get
            {
                return Settings.Default.BatchVarPrefix;
            }
        }
    }
}
