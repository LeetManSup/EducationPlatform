﻿#pragma checksum "..\..\StudentMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "17D8FB3900FCB4025AA3A665B24F645DACBE391241AF00B9037B3A925D6D0D7A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SchoolGUI;
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


namespace SchoolGUI {
    
    
    /// <summary>
    /// StudentMainWindow
    /// </summary>
    public partial class StudentMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_info_button;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_stats_button;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_tasks_button;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_mistakes_button;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame studentmainwindow_main_frame;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_check_button;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\StudentMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button studentmainwindow_check_mistake_button;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolGUI;component/studentmainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StudentMainWindow.xaml"
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
            this.studentmainwindow_info_button = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_info_button.Click += new System.Windows.RoutedEventHandler(this.ShowInfoStudent);
            
            #line default
            #line hidden
            return;
            case 2:
            this.studentmainwindow_stats_button = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_stats_button.Click += new System.Windows.RoutedEventHandler(this.ShowStatsStudent);
            
            #line default
            #line hidden
            return;
            case 3:
            this.studentmainwindow_tasks_button = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_tasks_button.Click += new System.Windows.RoutedEventHandler(this.ShowTasksStudent);
            
            #line default
            #line hidden
            return;
            case 4:
            this.studentmainwindow_mistakes_button = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_mistakes_button.Click += new System.Windows.RoutedEventHandler(this.ShowMistakesStudent);
            
            #line default
            #line hidden
            return;
            case 5:
            this.studentmainwindow_main_frame = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.studentmainwindow_check_button = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_check_button.Click += new System.Windows.RoutedEventHandler(this.CheckCurrentTask);
            
            #line default
            #line hidden
            return;
            case 7:
            this.studentmainwindow_check_mistake_button = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\StudentMainWindow.xaml"
            this.studentmainwindow_check_mistake_button.Click += new System.Windows.RoutedEventHandler(this.CheckCurrentMistake);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
