﻿#pragma checksum "..\..\Tagesansicht.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A2B385CFABEE1A78032DA03E184A71B48ED295AA800A21926EE2A49462DE9DEA"
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
    /// Tagesansicht
    /// </summary>
    public partial class Tagesansicht : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button neuerTerminTagesansicht;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button kategorienlisteTagesansicht;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button terminListeTagesansicht;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButtonT;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas tagkalender;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid tagkalenderGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label erste;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label zweite;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dritte;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dritte_Copy;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock wochentagText;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\Tagesansicht.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PDF_Button;
        
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
            System.Uri resourceLocater = new System.Uri("/Assistaplanner;component/tagesansicht.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Tagesansicht.xaml"
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
            
            #line 9 "..\..\Tagesansicht.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 19 "..\..\Tagesansicht.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Wochenansicht_Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.neuerTerminTagesansicht = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Tagesansicht.xaml"
            this.neuerTerminTagesansicht.Click += new System.Windows.RoutedEventHandler(this.neuerTerminTagesansicht_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.kategorienlisteTagesansicht = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Tagesansicht.xaml"
            this.kategorienlisteTagesansicht.Click += new System.Windows.RoutedEventHandler(this.kategorienlisteTagesansicht_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.terminListeTagesansicht = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Tagesansicht.xaml"
            this.terminListeTagesansicht.Click += new System.Windows.RoutedEventHandler(this.terminListeTagesansicht_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ExitButtonT = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Tagesansicht.xaml"
            this.ExitButtonT.Click += new System.Windows.RoutedEventHandler(this.ExitButtonT_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tagkalender = ((System.Windows.Controls.Canvas)(target));
            return;
            case 8:
            this.tagkalenderGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 9:
            this.erste = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.zweite = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.dritte = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.dritte_Copy = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            this.wochentagText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.PDF_Button = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\Tagesansicht.xaml"
            this.PDF_Button.Click += new System.Windows.RoutedEventHandler(this.PDFButtonT_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

