﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace abcde.Portal.Shared.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("abcde.Portal.Shared.Resources.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Home.
        /// </summary>
        public static string Home {
            get {
                return ResourceManager.GetString("Home", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Email or Password.
        /// </summary>
        public static string InvalidEmailorPassword {
            get {
                return ResourceManager.GetString("InvalidEmailorPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log In.
        /// </summary>
        public static string LogIn {
            get {
                return ResourceManager.GetString("LogIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log Out.
        /// </summary>
        public static string Logout {
            get {
                return ResourceManager.GetString("Logout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Task Management Portal.
        /// </summary>
        public static string TaskManagementPortal {
            get {
                return ResourceManager.GetString("TaskManagementPortal", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to Change Password.
        /// </summary>
        public static string UnableToChangePassword {
            get {
                return ResourceManager.GetString("UnableToChangePassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable To Verify.
        /// </summary>
        public static string UnableToVerify {
            get {
                return ResourceManager.GetString("UnableToVerify", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to Verify Without Organization Code.
        /// </summary>
        public static string UnableToVerifyWithoutOrganisationCode {
            get {
                return ResourceManager.GetString("UnableToVerifyWithoutOrganisationCode", resourceCulture);
            }
        }
    }
}
