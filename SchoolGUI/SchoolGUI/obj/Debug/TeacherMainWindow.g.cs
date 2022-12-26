﻿#pragma checksum "..\..\TeacherMainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C61346F874A9177FB2BA5A1DBC20E094067416D337BD0BC5C763D2B5903D6F7"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace SchoolGUI {
    
    
    /// <summary>
    /// TeacherMainWindow
    /// </summary>
    public partial class TeacherMainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teachermainwindow_info_button;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teachermainwindow_stats_button;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teachermainwindow_list_button;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teachermainwindow_add_button;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame teachermainwindow_main_frame;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\TeacherMainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teachermainwindow_save_new_task_button;
        
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
            System.Uri resourceLocater = new System.Uri("/SchoolGUI;component/teachermainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TeacherMainWindow.xaml"
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
            this.teachermainwindow_info_button = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\TeacherMainWindow.xaml"
            this.teachermainwindow_info_button.Click += new System.Windows.RoutedEventHandler(this.ShowInfoTeacher);
            
            #line default
            #line hidden
            return;
            case 2:
            this.teachermainwindow_stats_button = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\TeacherMainWindow.xaml"
            this.teachermainwindow_stats_button.Click += new System.Windows.RoutedEventHandler(this.ShowStudentsList);
            
            #line default
            #line hidden
            return;
            case 3:
            this.teachermainwindow_list_button = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\TeacherMainWindow.xaml"
            this.teachermainwindow_list_button.Click += new System.Windows.RoutedEventHandler(this.ShowTaskList);
            
            #line default
            #line hidden
            return;
            case 4:
            this.teachermainwindow_add_button = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\TeacherMainWindow.xaml"
            this.teachermainwindow_add_button.Click += new System.Windows.RoutedEventHandler(this.ShowTaskAdding);
            
            #line default
            #line hidden
            return;
            case 5:
            this.teachermainwindow_main_frame = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.teachermainwindow_save_new_task_button = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\TeacherMainWindow.xaml"
            this.teachermainwindow_save_new_task_button.Click += new System.Windows.RoutedEventHandler(this.SaveNewTask);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
