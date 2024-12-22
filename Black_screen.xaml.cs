using System.Windows;
using System.Windows.Input;

namespace Universcal_screen_control_for_GREMM
{
    /// <summary>
    /// Логика взаимодействия для Black_screen.xaml
    /// </summary>
    public partial class Black_screen : Window
    {
        //private bool _isDragging = false;
        //private Point _clickPosition;

        //public bool Chechbox_black_screen_owner = false;

        public Black_screen()
        {
            InitializeComponent();
            PositionWindowAtBottom();
            this.Topmost = false; // Устанавливаем окно поверх всех остальных
            //this.Focus(); // Убедимся, что окно получает фокус при запуске
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Захват мыши
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove(); // Перемещение окна
            }
        }

        //private void Rectangle_MouseMove(object sender, MouseEventArgs e) // Перемещение окна в пред
        //{
        //    if (_isDragging && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        Point currentPosition = e.GetPosition(this);
        //        this.Left += currentPosition.X - _clickPosition.X;
        //        this.Top += currentPosition.Y - _clickPosition.Y;
        //    }
        //}

        //private void Rectangle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        public void Black_screen_CheckBox_Checked(object sender, RoutedEventArgs e) // Поверх всех окон ON (checkbox)
        {
            this.Topmost = true;
            //Chechbox_black_screen_owner = true;
        }

        public void Black_screen_CheckBox_Unchecked(object sender, RoutedEventArgs e) // Поверх всех окон OFF (checkbox)
        {
            this.Topmost = false;
            //Chechbox_black_screen_owner = false;
        }

        public void Black_screen_topmost_off_bt_click(object sender, RoutedEventArgs e) // Поверх всех окон OFF (Button)
        {
            this.Topmost = false;
        }

        public void Black_screen_topmost_on_bt_click(object sender, RoutedEventArgs e) // Поверх всех окон ON (Button)
        {
            this.Topmost = true;
        }

        public void Align_to_the_left_edge_and_width_bt_click(object sender, RoutedEventArgs e) // Выровнять
        {
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double screenWidth = SystemParameters.PrimaryScreenWidth;

            // Устанавливаем координаты окна
            this.Top = screenHeight - this.Height;
            this.Left = (screenWidth - this.Width);
        }

        public void Change_resolution_to_panel_bt_click(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            this.Width = 1600;
            this.Height = 25;

        }

        public void Change_resolution_to_panel_full_bt_click(object sender, RoutedEventArgs e) // Растянуть на весь экран
        {
            this.Width = 1600;
            this.Height = 840;
        }

        public void Active_navigation_drag_button_bt_click(object sender, RoutedEventArgs e) // Активация и деактивация области для взаимодействия
        {
            if (Rectangle_control.Visibility == Visibility.Visible)
            {
                Rectangle_control.Visibility = Visibility.Collapsed;
            }
            else
            {
                Rectangle_control.Visibility = Visibility.Visible;
            }
        }

        public void ChangeOpacity(double opacity) // Регулировка прозрачности
        {
            this.Opacity = opacity;
        }

    }
}
