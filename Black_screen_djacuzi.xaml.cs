using System.Windows;
using System.Windows.Input;


namespace Universcal_screen_control_for_GREMM
{
    /// <summary>
    /// Логика взаимодействия для Black_screen_djacuzi.xaml
    /// </summary>
    public partial class Black_screen_djacuzi : Window
    {
        //private bool _isDragging = false;
        //private Point _clickPosition;

        public Black_screen_djacuzi()
        {
            InitializeComponent();
            PositionWindowAtBottom();
            this.Topmost = false; // Устанавливаем окно поверх всех остальных
            //this.Focus(); // Убедимся, что окно получает фокус при запуске
        }

        private void Rectangle_MouseLeftButtonDown_second(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Перемещение окна
            }
        }

        //private void Rectangle_MouseMove_second(object sender, MouseEventArgs e) // Перемещение окна в пред
        //{
        //    if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Point currentPosition = e.GetPosition(this);
        //        this.Left += currentPosition.X - _clickPosition.X;
        //        this.Top += currentPosition.Y - _clickPosition.Y;
        //    }
        //}

        //private void Rectangle_MouseLeftButtonUp_second(object sender, MouseButtonEventArgs e)
        //{
        //    _isDragging = false;
        //}

        private void PositionWindowAtBottom() // притягивает окно к низу экрана по левому краю выравнивает
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            // Устанавливаем координаты окна
            this.Top = screenHeight - this.Height;
            this.Left = (screenWidth - this.Width) / 2; // Центрируем окно по горизонтали
        }

        ///Выполнение команд кнопок
        ///

        public void Black_screen_CheckBox_Checked_second(object sender, RoutedEventArgs e) // Поверх всех окон ON (checkbox)
        {
            this.Topmost = true;
        }

        public void Black_screen_CheckBox_Unchecked_second(object sender, RoutedEventArgs e) // Поверх всех окон OFF (checkbox)
        {
            this.Topmost = false;
        }

        public void Black_screen_topmost_off_bt_click_second(object sender, RoutedEventArgs e) // Поверх всех окон OFF (Button)
        {
            this.Topmost = false;
        }

        public void Black_screen_topmost_on_bt_click_second(object sender, RoutedEventArgs e) // Поверх всех окон ON (Button)
        {
            this.Topmost = true;
        }

        public void Align_to_the_left_edge_and_width_bt_click_second(object sender, RoutedEventArgs e) // Выровнять
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            // Устанавливаем координаты окна
            this.Top = screenHeight - this.Height;
            this.Left = (screenWidth - this.Width);
        }

        public void Change_resolution_to_panel_bt_click_second(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            this.Width = 2560;
            this.Height = 25;
        }

        public void Change_resolution_to_panel_full_bt_click_second(object sender, RoutedEventArgs e) // Растянуть на весь экран
        {
            this.Width = 2560;
            this.Height = 1536;
        }

        public void Active_navigation_drag_button_bt_click_second(object sender, RoutedEventArgs e) // Активация и деактивация области для взаимодействия
        {
            if (Rectangle_control_second.Visibility == Visibility.Visible)
            {
                Rectangle_control_second.Visibility = Visibility.Collapsed;
            }
            else
            {
                Rectangle_control_second.Visibility = Visibility.Visible;
            }
        }

        public void ChangeOpacity_second(double opacity) // Регулировка прозрачности
        {
            this.Opacity = opacity;
        }
    }
}
