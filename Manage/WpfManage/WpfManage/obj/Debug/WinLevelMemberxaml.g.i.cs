﻿#pragma checksum "..\..\WinLevelMemberxaml.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B8A801E6CB07D2C813628E3DA0C507E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfManage;


namespace WpfManage {
    
    
    /// <summary>
    /// WinLevelMemberxaml
    /// </summary>
    public partial class WinLevelMemberxaml : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxUserName;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPassword;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSubMite;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonAdmin;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadioButtonUser;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGridLogin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuEdit;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\WinLevelMemberxaml.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuCostomerDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfManage;component/winlevelmemberxaml.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WinLevelMemberxaml.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\WinLevelMemberxaml.xaml"
            ((WpfManage.WinLevelMemberxaml)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ButtonSubMite = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\WinLevelMemberxaml.xaml"
            this.ButtonSubMite.Click += new System.Windows.RoutedEventHandler(this.ButtonSubMite_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RadioButtonAdmin = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\WinLevelMemberxaml.xaml"
            this.RadioButtonAdmin.Checked += new System.Windows.RoutedEventHandler(this.RadioButtonAdmin_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RadioButtonUser = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.DataGridLogin = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 8:
            this.MenuEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 28 "..\..\WinLevelMemberxaml.xaml"
            this.MenuEdit.Click += new System.Windows.RoutedEventHandler(this.MenuEdit_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MenuCostomerDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 29 "..\..\WinLevelMemberxaml.xaml"
            this.MenuCostomerDelete.Click += new System.Windows.RoutedEventHandler(this.MenuCostomerDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
