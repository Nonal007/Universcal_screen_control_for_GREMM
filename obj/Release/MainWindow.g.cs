﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "55C20F7CD783C4EDDBFD1A404439551F1903506B8426A3C34FB25956244F6EE2"
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
using Universcal_screen_control_for_GREMM;


namespace Universcal_screen_control_for_GREMM {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Window1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chechbox_activate_deactivate_panel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider OpacitySlider;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox Chechbox_activate_deactivate_panel_djacuzi;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider OpacitySlider_djacuzi;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DateTextBlock;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock WeekTextBlock;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Window2;
        
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
            System.Uri resourceLocater = new System.Uri("/Universcal_screen_control_for_GREMM;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.Window1 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.chechbox_activate_deactivate_panel = ((System.Windows.Controls.CheckBox)(target));
            
            #line 23 "..\..\MainWindow.xaml"
            this.chechbox_activate_deactivate_panel.Checked += new System.Windows.RoutedEventHandler(this.Black_screen_CheckBox_Checked_dubler);
            
            #line default
            #line hidden
            
            #line 23 "..\..\MainWindow.xaml"
            this.chechbox_activate_deactivate_panel.Unchecked += new System.Windows.RoutedEventHandler(this.Black_screen_CheckBox_UnChecked_dubler);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OpacitySlider = ((System.Windows.Controls.Slider)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.OpacitySlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.OpacitySlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 26 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Align_to_the_left_edge_and_width_bt_click_dubler);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 27 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_resolution_to_panel_bt_click_dubler);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 28 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_resolution_to_panel_full_bt_click_dubler);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 29 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_navigation_drag_button_bt_click_dubler);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Chechbox_activate_deactivate_panel_djacuzi = ((System.Windows.Controls.CheckBox)(target));
            
            #line 39 "..\..\MainWindow.xaml"
            this.Chechbox_activate_deactivate_panel_djacuzi.Checked += new System.Windows.RoutedEventHandler(this.Black_screen_djacuzi_CheckBox_Checked_dubler);
            
            #line default
            #line hidden
            
            #line 39 "..\..\MainWindow.xaml"
            this.Chechbox_activate_deactivate_panel_djacuzi.Unchecked += new System.Windows.RoutedEventHandler(this.Black_screen_djacuzi_CheckBox_UnChecked_dubler);
            
            #line default
            #line hidden
            return;
            case 9:
            this.OpacitySlider_djacuzi = ((System.Windows.Controls.Slider)(target));
            
            #line 41 "..\..\MainWindow.xaml"
            this.OpacitySlider_djacuzi.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.OpacitySlider_djacuzi_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 42 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Align_to_the_left_edge_and_width_bt_click_dubler_djacuzi);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 43 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_resolution_to_panel_bt_click_dubler_djacuzi);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 44 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Change_resolution_to_panel_full_bt_click_dubler_djacuzi);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 45 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_navigation_drag_button_bt_click_dubler_djacuzi);
            
            #line default
            #line hidden
            return;
            case 14:
            this.DateTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.WeekTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 16:
            this.TimeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 17:
            
            #line 72 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close_all_window_bt_click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.Window2 = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 19:
            
            #line 84 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Activate_new_Window2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

