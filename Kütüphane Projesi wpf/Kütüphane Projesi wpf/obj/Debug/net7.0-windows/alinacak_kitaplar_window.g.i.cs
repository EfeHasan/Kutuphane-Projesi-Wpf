﻿#pragma checksum "..\..\..\alinacak_kitaplar_window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7E5899CA069296E2B3801692D5D7F57851BCB615"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using Kütüphane_Projesi_wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Kütüphane_Projesi_wpf {
    
    
    /// <summary>
    /// alinacak_kitaplar_window
    /// </summary>
    public partial class alinacak_kitaplar_window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        /// <summary>
        /// listview Name Field
        /// </summary>
        
        #line 10 "..\..\..\alinacak_kitaplar_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.ListView listview;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\alinacak_kitaplar_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ana_Menu;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\alinacak_kitaplar_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Goruntule;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kütüphane Projesi wpf;component/alinacak_kitaplar_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\alinacak_kitaplar_window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\alinacak_kitaplar_window.xaml"
            ((Kütüphane_Projesi_wpf.alinacak_kitaplar_window)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listview = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.Ana_Menu = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\alinacak_kitaplar_window.xaml"
            this.Ana_Menu.Click += new System.Windows.RoutedEventHandler(this.Ana_Menu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Goruntule = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\alinacak_kitaplar_window.xaml"
            this.Goruntule.Click += new System.Windows.RoutedEventHandler(this.Goruntule_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

