﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudDiagnosis {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class CloudDiagnosisSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static CloudDiagnosisSettings defaultInstance = ((CloudDiagnosisSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new CloudDiagnosisSettings())));
        
        public static CloudDiagnosisSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string str1 {
            get {
                return ((string)(this["str1"]));
            }
            set {
                this["str1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string str2 {
            get {
                return ((string)(this["str2"]));
            }
            set {
                this["str2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool b {
            get {
                return ((bool)(this["b"]));
            }
            set {
                this["b"] = value;
            }
        }
    }
}
