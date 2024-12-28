using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Animation;

namespace Universcal_screen_control_for_GREMM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Black_screen black_Screen = new Black_screen();
        public Black_screen_djacuzi black_Screen_djacuzi = new Black_screen_djacuzi();

        private const int maxGarbage = 99999;

        public bool isActive_Mon = true;
        public bool isActive_Tue = true;
        public bool isActive_Wed = true;
        public bool isActive_Thu = true;
        public bool isActive_Fri = true;
        public bool isActive_Sun = true;
        public bool isActive_Sat = true;

        private DispatcherTimer TimerSheduler = new DispatcherTimer(); // Таймер активации расписания
        private DispatcherTimer TimerCheckTime = new DispatcherTimer(); // Таймер проверки времени

        public MainWindow()
        {
            InitializeComponent();
            OpenBlackScreen();
            OpenBlackScreen_djacuzi();
            DisplayCurrentDateAndDay();
            //WeekCycles_click();
            InitializeTimers();
            Avtive_Universal_Screen_Contol(null, null);
        }

        private void InitializeTimers() // Запуск двух таймеров
        {
            TimerSheduler.Interval = TimeSpan.FromSeconds(8);
            TimerSheduler.Tick += TimerSheduler_Tick;
            TimerSheduler.Start();

            TimerCheckTime.Interval = TimeSpan.FromSeconds(1);
            TimerCheckTime.Tick += TimerCheckTime_Tick;
            TimerCheckTime.Start();
        }

        private void TimerSheduler_Tick(object sender, EventArgs e) // Тик на расписание
        {
            DisplayCurrentDateAndDay();
            WeekCycles_click();
        }

        private void TimerCheckTime_Tick(object sender, EventArgs e) // Тик на проверку активации полотна
        {
            Activate_Deactivate_black_screen();
            updatecheckboxstate();
        }

        private void updatecheckboxstate() // Проверка активации полотна
        {
            chechbox_activate_deactivate_panel.IsChecked = black_Screen.Topmost;
            Chechbox_activate_deactivate_panel_djacuzi.IsChecked = black_Screen_djacuzi.Topmost;
        }

        public void Close_all_window_bt_click(object sender, EventArgs e) // Закрытие всех приложений
        {
            black_Screen.Close();
            black_Screen_djacuzi.Close();
            this.Close();
        }

        //
        // Кастомные часы
        //

        private Dictionary<DayOfWeek, string> _customDayNames = new Dictionary<DayOfWeek, string>() // Форматирование дней
        {
            { DayOfWeek.Monday, "Mon" },
            { DayOfWeek.Tuesday, "Tue" },
            { DayOfWeek.Wednesday, "Wed" },
            { DayOfWeek.Thursday, "Thu" },
            { DayOfWeek.Friday, "Fri" },
            { DayOfWeek.Saturday, "Sat" },
            { DayOfWeek.Sunday, "Sun" }
        };

        private void DisplayCurrentDateAndDay() // Отображение даты
        {
            DateTime currentDate = DateTime.Now;
            DayOfWeek currentDay = currentDate.DayOfWeek;

            string formattedDate = $"{currentDate:MMMM dd, yyyy} ({_customDayNames[currentDay]})";
            string formattedTime = $"{currentDate:HH:mm}";

            DateTextBlock.Text = formattedDate;
            WeekTextBlock.Text = _customDayNames[currentDay];
            TimeTextBlock.Text = formattedTime;
        }

        private void WeekCycles_click() // Цикл расписания
        {
            if (WeekTextBlock.Text == "Mon" && isActive_Mon)
            {
                isActive_Mon = false;
                isActive_Sun = true;
                OpenFile("C:\\tasks\\Mon.bat");
                //MessageBox.Show("Понедельник");

            }

            if (WeekTextBlock.Text == "Tue" && isActive_Tue)
            {
                isActive_Tue = false;
                isActive_Mon = true;
                OpenFile("C:\\tasks\\Tue.bat");
                //MessageBox.Show("Вторник");

            }

            if (WeekTextBlock.Text == "Wed" && isActive_Wed)
            {
                isActive_Wed = false;
                isActive_Tue = true;
                OpenFile("C:\\tasks\\Wed.bat");
                //MessageBox.Show("Среда");

            }

            if (WeekTextBlock.Text == "Thu" && isActive_Thu)
            {
                isActive_Thu = false;
                isActive_Wed = true;
                OpenFile("C:\\tasks\\Thu.bat");
                //MessageBox.Show("Четверг");

            }

            if (WeekTextBlock.Text == "Fri" && isActive_Fri)
            {
                isActive_Fri = false;
                isActive_Thu = true;
                OpenFile("C:\\tasks\\Fri.bat");
                //MessageBox.Show("Пятница");

            }

            if (WeekTextBlock.Text == "Sat" && isActive_Sat)
            {
                isActive_Sat = false;
                isActive_Fri = true;
                OpenFile("C:\\tasks\\Sat.bat");
                //MessageBox.Show("Суббота");

            }

            if (WeekTextBlock.Text == "Sun" && isActive_Sun)
            {
                isActive_Sun = false;
                isActive_Sat = true;
                OpenFile("C:\\tasks\\Sun.bat");
                //MessageBox.Show("Воскресенье");

            }
        }

        public void Activate_Deactivate_black_screen() // Цикл активации, деактивации полотна
        {
            if (TimeTextBlock.Text == "8:30")
            {
                black_Screen.Black_screen_CheckBox_Unchecked(null, null);
                OpenFile("C:\\tasks_a\\StopBlackScript.bat");
            }

            if (TimeTextBlock.Text == "8:31")
            {
                black_Screen_djacuzi.Black_screen_CheckBox_Unchecked_second(null, null);
                OpenFile("C:\\tasks_a\\StopBlackScript.bat");

            }

            if (TimeTextBlock.Text == "23:40")
            {
                black_Screen.Black_screen_CheckBox_Checked(null, null);
                OpenFile("C:\\tasks_a\\StartBlackScript.bat");

            }

            if (TimeTextBlock.Text == "23:41")
            {
                black_Screen_djacuzi.Black_screen_CheckBox_Checked_second(null, null);
                OpenFile("C:\\tasks_a\\StartBlackScript.bat");

            }
        }

        private void OpenFile(string filePath) // открытие файла
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}");
            }
        }




        ///////////////////// Открытие окон
        public void OpenBlackScreen() // Открытие полотна для экрана бассейна
        {
            black_Screen.Show();
        }

        public void OpenBlackScreen_djacuzi() // открытие полотна для экрана джакузи
        {
            black_Screen_djacuzi.Show();
        }

        ///////////////////// Анимация элементов

        private void Animation_Visibility_Element()
        {
            DispatcherTimer Visibility_Element_Timer = new DispatcherTimer();
            Visibility_Element_Timer.Interval = TimeSpan.FromSeconds(2);
            Universal_Main_Window.BeginAnimation(UIElement.VisibilityProperty, null);
        }

        private void Animation_Opacity_Element(UIElement element) // Скрытие окна
        {
            if (element.Opacity == 0) // Проверка
            {
                return;
            }



            DoubleAnimation animation = new DoubleAnimation // Анимация изменения opacity
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(1)) // Длительность анимации
            };

            animation.Completed += (s, args) =>
            {
                // Устанавливаем Visibility в Hidden после завершения анимации
                if (element is FrameworkElement frameworkElement)
                {
                    frameworkElement.Visibility = Visibility.Hidden;
                }
            };

            // Применяем анимацию к элементу
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void Undo_Animation_Opacity_Element(UIElement element) // Возвращение окна в исходное состояние
        {

            if (element.Opacity == 1) // Проверка
            {
                return;
            }

            element.Visibility = Visibility.Visible; // Вывод скрытых элементов

            DoubleAnimation animation = new DoubleAnimation // Анимация
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(1)) // Таймер анимации
            };
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        ///////////////////// Дополнительные функции

        private void Active_Marketing_Window(object sender, EventArgs e) // Активация окна маркетинга
        {
            Animation_Opacity_Element(Universal_Main_Window);
            Undo_Animation_Opacity_Element(The_Marketing_Window);
        }

        private void Avtive_Universal_Screen_Contol(object sender, EventArgs e) // Активация главного окна
        {
            Animation_Opacity_Element(The_Marketing_Window);
            Undo_Animation_Opacity_Element(Universal_Main_Window);

        }




        ///////////////////// Параллельное взаимодействие для экрана бассейн

        private void Open_black_screen_click(object sender, RoutedEventArgs e) // Активация полотна поверх всех окон
        {
            if (black_Screen != null)
            {
                black_Screen.Black_screen_topmost_on_bt_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Close_black_screen_click(object sender, RoutedEventArgs e) // Активация полотна поверх всех окон
        {
            if (black_Screen != null)
            {
                black_Screen.Black_screen_topmost_off_bt_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Align_to_the_left_edge_and_width_bt_click_dubler(object sender, RoutedEventArgs e) // Выровнять по левому краю
        {
            if (black_Screen != null)
            {
                black_Screen.Align_to_the_left_edge_and_width_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Change_resolution_to_panel_bt_click_dubler(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            if (black_Screen != null)
            {
                black_Screen.Change_resolution_to_panel_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Change_resolution_to_panel_full_bt_click_dubler(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            if (black_Screen != null)
            {
                black_Screen.Change_resolution_to_panel_full_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Active_navigation_drag_button_bt_click_dubler(object sender, RoutedEventArgs e) // Активация и деактивация области для взаимодействия
        {
            if (black_Screen != null)
            {
                black_Screen.Active_navigation_drag_button_owner.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // Регулировка прозрачности
        {
            if (black_Screen != null)
            {
                black_Screen.ChangeOpacity(OpacitySlider.Value);
            }
        }

        public void Black_screen_CheckBox_Checked_dubler(object sender, RoutedEventArgs e) // Активировать поверх экрана полотно экрана у бассейна
        {
            if (black_Screen != null)
            {
                black_Screen.Black_screen_CheckBox_Checked(sender, e);
            }
        }

        public void Black_screen_CheckBox_UnChecked_dubler(object sender, RoutedEventArgs e) // Деактивировать поверх экрана полотно экрана у бассейна
        {
            if (black_Screen != null)
            {
                black_Screen.Black_screen_CheckBox_Unchecked(sender, e);
            }
        }

        /////////////////////////////// Параллельное взаимодействие для экрана джакузи

        private void Align_to_the_left_edge_and_width_bt_click_dubler_djacuzi(object sender, RoutedEventArgs e) // Выровнять по левому краю
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Align_to_the_left_edge_and_width_owner_second.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Change_resolution_to_panel_bt_click_dubler_djacuzi(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Change_resolution_to_panel_owner_second.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Change_resolution_to_panel_full_bt_click_dubler_djacuzi(object sender, RoutedEventArgs e) // Ужать полотно до панели
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Change_resolution_to_panel_full_owner_second.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void Active_navigation_drag_button_bt_click_dubler_djacuzi(object sender, RoutedEventArgs e) // Активация и деактивация области для взаимодействия
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Active_navigation_drag_button_owner_second.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void OpacitySlider_djacuzi_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) // Регулировка прозрачности
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.ChangeOpacity_second(OpacitySlider_djacuzi.Value);
            }
        }

        public void Black_screen_djacuzi_CheckBox_Checked_dubler(object sender, RoutedEventArgs e) // Checkbox активация функции поверх экрана
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Black_screen_CheckBox_Checked_second(sender, e);
            }
        }

        public void Black_screen_djacuzi_CheckBox_UnChecked_dubler(object sender, RoutedEventArgs e) // Checkbox деактивация функции поверх экрана
        {
            if (black_Screen_djacuzi != null)
            {
                black_Screen_djacuzi.Black_screen_CheckBox_Unchecked_second(sender, e);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
