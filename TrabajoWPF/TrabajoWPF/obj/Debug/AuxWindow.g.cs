﻿#pragma checksum "..\..\AuxWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "507BA339ABC9525C3F837FC3FD1BBA75DD1CD6FE139E5AA6ABE89F0C95ED1C5B"
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
using TrabajoWPF;


namespace TrabajoWPF {
    
    
    /// <summary>
    /// AuxWindow
    /// </summary>
    public partial class AuxWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AuxGrid;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid G_auxWindow;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox C_Show;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label L_Diff;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider S_Diff;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox T_Save;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button B_Save;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\AuxWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox C_Save;
        
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
            System.Uri resourceLocater = new System.Uri("/TrabajoWPF;component/auxwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AuxWindow.xaml"
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
            this.AuxGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.G_auxWindow = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.C_Show = ((System.Windows.Controls.CheckBox)(target));
            
            #line 61 "..\..\AuxWindow.xaml"
            this.C_Show.Click += new System.Windows.RoutedEventHandler(this.C_Show_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.L_Diff = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.S_Diff = ((System.Windows.Controls.Slider)(target));
            
            #line 63 "..\..\AuxWindow.xaml"
            this.S_Diff.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.S_Diff_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.T_Save = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.B_Save = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\AuxWindow.xaml"
            this.B_Save.Click += new System.Windows.RoutedEventHandler(this.B_Save_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.C_Save = ((System.Windows.Controls.ComboBox)(target));
            
            #line 66 "..\..\AuxWindow.xaml"
            this.C_Save.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.C_Save_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

