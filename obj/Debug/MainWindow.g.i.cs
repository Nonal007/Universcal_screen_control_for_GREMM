﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4108FAE83B843104D400C091954426FD8265532F3E41E5F7BA701E70F28D14E8"
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
        internal System.Windows.Controls.DockPanel Universal_Main_Window;
        
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
        internal System.Windows.Controls.DockPanel The_Marketing_Window;
        
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
            this.Universal_Main_Window = ((System.Windows.Controls.DockPanel)(target));
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
            this.The_Marketing_Window = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 19:
            
            #line 82 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Activation_screen_swimming_pool_bt_click);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 83 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Deactivation_screen_swimming_pool_bt_click);
            
            #line default
            #line hidden
            return;
            case 21:
            
            #line 84 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_test_promt1);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 85 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_test_promt2);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 86 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_Zel1);
            
            #line default
            #line hidden
            return;
            case 24:
            
            #line 87 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_Zel2);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 88 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_Zel3);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 89 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_scree_switch_Chestnaya_r);
            
            #line default
            #line hidden
            return;
            case 27:
            
            #line 95 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Activation_screen_djacuzi_bt_click);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 96 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Deactivation_screen_djacuzi_bt_click);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 97 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_djacuzi_test_promt1);
            
            #line default
            #line hidden
            return;
            case 30:
            
            #line 98 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_djacuzi_test_promt2);
            
            #line default
            #line hidden
            return;
            case 31:
            
            #line 99 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_djacuzi_Zel1);
            
            #line default
            #line hidden
            return;
            case 32:
            
            #line 100 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_djacuzi_Zel2);
            
            #line default
            #line hidden
            return;
            case 33:
            
            #line 101 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_screen_switch_djacuzi_Zel3);
            
            #line default
            #line hidden
            return;
            case 34:
            
            #line 102 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_scree_switch_djacuzi_Chestnaya_r);
            
            #line default
            #line hidden
            return;
            case 35:
            
            #line 120 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Active_Marketing_Window);
            
            #line default
            #line hidden
            return;
            case 36:
            
            #line 121 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Avtive_Universal_Screen_Contol);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

