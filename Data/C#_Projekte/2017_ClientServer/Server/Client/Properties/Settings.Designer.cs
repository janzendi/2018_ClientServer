﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DebugModeEnabled {
            get {
                return ((bool)(this["DebugModeEnabled"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("127.0.0.1")]
        public string ServerIPAddress {
            get {
                return ((string)(this["ServerIPAddress"]));
            }
            set {
                this["ServerIPAddress"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8910")]
        public int ServerPort {
            get {
                return ((int)(this["ServerPort"]));
            }
            set {
                this["ServerPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("de")]
        public string Language {
            get {
                return ((string)(this["Language"]));
            }
            set {
                this["Language"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Config/default.xml")]
        public string ConfigFileDefault {
            get {
                return ((string)(this["ConfigFileDefault"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OpenFolder;A:\\;B:\\;C:\\;D:\\;E:\\;F:\\;G:\\;H:\\;I:\\;J:\\;K:\\;L:\\;M:\\;N:\\;O:\\;P:\\;Q:\\;R:" +
            "\\;S:\\;T:\\;U:\\;V:\\;W:\\;X:\\;Y:\\;Z:\\")]
        public string DriveLetters {
            get {
                return ((string)(this["DriveLetters"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Config/language.xml")]
        public string LanguageFile {
            get {
                return ((string)(this["LanguageFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Config/alarm.xml")]
        public string AlarmFile {
            get {
                return ((string)(this["AlarmFile"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("analogDataPoints;analog;Analog")]
        public string DCAnalogSemantic {
            get {
                return ((string)(this["DCAnalogSemantic"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"BMT_ErrorInfo;BMT_BatchStop;BMT_BatchStart;BMT_BatchCtrlState;BMT_Connection_OK;BMT_TokenBit_UP;BMT_BatchCtrlState;EM_FirstFault;EM_FirstFaultText;EM_FirstFaultClass;EM_MachineStopError;EM_MachineStopErrorText;EM_MachineStopErrorClass;EM_OpcErrorNumberList;EM_OpcErrorClassList;EM_OpcErrorDeviceList;EM_OpcErrorTextList;EM_OpcWarningNumberList;EM_OpcWarningClassList;EM_OpcWarningDeviceList;EM_OpcWarningTextList;")]
        public string OPCVariables {
            get {
                return ((string)(this["OPCVariables"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BMT_")]
        public string BatchVarPrefix {
            get {
                return ((string)(this["BatchVarPrefix"]));
            }
        }
    }
}