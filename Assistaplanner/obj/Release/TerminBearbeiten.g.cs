﻿#pragma checksum "..\..\TerminBearbeiten.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "401A61BB7F36727EE268013C199B1ED65323765B47D6B6BC2FB1225E54388200"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assistaplanner;
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


namespace Assistaplanner {
    
    
    /// <summary>
    /// TerminBearbeiten
    /// </summary>
    public partial class TerminBearbeiten : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitelText;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox KategoriePicker;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UntertitelText;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BeschreibungText;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox wochentagBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vonStunde;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox vonMinute;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bisStunde;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TerminBearbeiten.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bisMinute;
        
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
            System.Uri resourceLocater = new System.Uri("/Assistaplanner;component/terminbearbeiten.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TerminBearbeiten.xaml"
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
            this.TitelText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.KategoriePicker = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.UntertitelText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            
            #line 20 "..\..\TerminBearbeiten.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BeschreibungText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.wochentagBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.vonStunde = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.vonMinute = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.bisStunde = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.bisMinute = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

