using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Universcal_screen_control_for_GREMM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Black_screen black_Screen = new Black_screen(); // Заглушка//
        public Black_screen_djacuzi black_Screen_djacuzi = new Black_screen_djacuzi(); // Заглушка//
        public Switch_Screen switch_Screen = new Switch_Screen(); // Экран бассейн как switch_Screen
        public Switch_Screen_djacuzi switch_Screen_Djacuzi = new Switch_Screen_djacuzi();// Экран джакузи как switch_Screen_Djacuzi

        // период и длительность
        public static readonly TimeSpan PromoPeriod = TimeSpan.FromMinutes(59); // Таймер задержки перед воспроизведением промо
        public static readonly TimeSpan PromoDuration = TimeSpan.FromMinutes(3); // Таймер воспроизведения промо

        public DispatcherTimer _promoStartTimer; // Таймер промо СТАРТ
        public DispatcherTimer _promoStopTimer; // Таймер промо СТОП

        public bool _promoRunning; // флаг: сейчас идёт запланированный показ (пока идет показ, таймер стоит)

        private const int maxGarbage = 99999; // Очистка буфера

        // РАСПИСАНИЕ, начальная логика
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
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose; //Корректное завершение всего приложения
            InitializeComponent(); // Обычная отризовка компонентов
            OpenBlackScreen(); // Скрытие всех окон перед открытием (заглушка)
            OpenBlackScreen_djacuzi(); // Скрытие всех окон перед открытием (заглушка)
            DisplayCurrentDateAndDay(); // Проверка корректности даты
            InitializeTimers(); // Инициализация таймером (двух)
        }

        private void InitializeTimers() // Запуск двух таймеров
        {
            TimerSheduler.Interval = TimeSpan.FromSeconds(8); // Проверка расписание
            TimerSheduler.Tick += TimerSheduler_Tick;
            TimerSheduler.Start();

            TimerCheckTime.Interval = TimeSpan.FromSeconds(1); // Проверка времени
            TimerCheckTime.Tick += TimerCheckTime_Tick;
            TimerCheckTime.Start();
            SetupPromoTimersAligned(); // Запуск промо
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


        //
        // //////////Кастомные часы
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

        private void WeekCycles_click() // Цикл расписания (сулжебная операция)
        {
            if (WeekTextBlock.Text == "Mon" && isActive_Mon)
            {
                isActive_Mon = false;
                isActive_Sun = true;
                switch_Screen.PlayVideo(@"C:\pp\Mon.mp4");
                // OpenFile("C:\\tasks\\Mon.bat");
                //MessageBox.Show("Понедельник");

            }

            if (WeekTextBlock.Text == "Tue" && isActive_Tue)
            {
                isActive_Tue = false;
                isActive_Mon = true;
                switch_Screen.PlayVideo(@"C:\pp\Tue.mp4");
                // OpenFile("C:\\tasks\\Tue.bat");
                //MessageBox.Show("Вторник");

            }

            if (WeekTextBlock.Text == "Wed" && isActive_Wed)
            {
                isActive_Wed = false;
                isActive_Tue = true;
                switch_Screen.PlayVideo(@"C:\pp\Wed.mp4");
                //OpenFile("C:\\tasks\\Wed.bat");
                //MessageBox.Show("Среда");

            }

            if (WeekTextBlock.Text == "Thu" && isActive_Thu)
            {
                isActive_Thu = false;
                isActive_Wed = true;
                switch_Screen.PlayVideo(@"C:\pp\Thu.mp4");
                //OpenFile("C:\\tasks\\Thu.bat");
                //MessageBox.Show("Четверг");

            }

            if (WeekTextBlock.Text == "Fri" && isActive_Fri)
            {
                isActive_Fri = false;
                isActive_Thu = true;
                switch_Screen.PlayVideo(@"C:\pp\Fri.mp4");
                // OpenFile("C:\\tasks\\Fri.bat");
                //MessageBox.Show("Пятница");

            }

            if (WeekTextBlock.Text == "Sat" && isActive_Sat)
            {
                isActive_Sat = false;
                isActive_Fri = true;
                switch_Screen.PlayVideo(@"C:\pp\Sat.mp4");
                //OpenFile("C:\\tasks\\Sat.bat");
                //MessageBox.Show("Суббота");

            }

            if (WeekTextBlock.Text == "Sun" && isActive_Sun)
            {
                isActive_Sun = false;
                isActive_Sat = true;
                switch_Screen.PlayVideo(@"C:\pp\Sun.mp4");
                //OpenFile("C:\\tasks\\Sun.bat");
                //MessageBox.Show("Воскресенье");

            }
        }

        public void Activate_Deactivate_black_screen() // Цикл активации, деактивации полотна
        {
            if (TimeTextBlock.Text == "10:30")
            {
                ActiveFocus_switchScreen();
                //OpenFile("C:\\tasks_a\\StopBlackScript.bat"); (null, null)
            }


            if (TimeTextBlock.Text == "22:30")
            {
                UnFocusScreens();
            }

        }


        public void ActiveFocus_switchScreen() // Фокус окна switch_screen
        {
            switch_Screen.Topmost = true;  // окно поверх всех
            switch_Screen.Activate();      // активация окна
            switch_Screen.Focus();         // фокус окна
          //OpenFile("C:\\tasks_a\\StopBlackScript.bat"); (null, null)
        }

        public void UnFocusScreens() // Фокус на главное окно
        {
            switch_Screen.Topmost = false;
            this.Activate();
            this.Focus();
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

        // Если хотите, чтобы срабатывания были ровно в :00, :10, :20 и т.п.
        private void SetupPromoTimersAligned()
        {
            // первый старт — через дельту до ближайшего кратного 10 минут
            var now = DateTime.Now;
            var minutesToNext = 59 - (now.Minute % 59);
            if (minutesToNext == 59) minutesToNext = 0;
            var initialDelay = new TimeSpan(0, minutesToNext, 0) - TimeSpan.FromSeconds(now.Second);
            if (initialDelay < TimeSpan.Zero) initialDelay = TimeSpan.Zero;

            // одноразовый таймер на первый запуск
            var first = new DispatcherTimer { Interval = initialDelay };
            first.Tick += (s, e) =>
            {
                (s as DispatcherTimer).Stop();
                StartScheduledPromo();

                // затем регулярный каждые 10 минут
                _promoStartTimer = new DispatcherTimer { Interval = PromoPeriod };
                _promoStartTimer.Tick += (s3, e3) => StartScheduledPromo();
                _promoStartTimer.Start();
            };
            first.Start();
        }


        public void Show_today_schedule_bt_click(object sender, RoutedEventArgs e) // Активировать расписание по времени (заглушка рабочая)
        {

            // Берём день строго из UI, как у тебя принято
            string day = WeekTextBlock.Text;
            string path = null;

            if (day == "Mon") path = @"C:\pp\Mon.mp4";
            else if (day == "Tue") path = @"C:\pp\Tue.mp4";
            else if (day == "Wed") path = @"C:\pp\Wed.mp4";
            else if (day == "Thu") path = @"C:\pp\Thu.mp4";
            else if (day == "Fri") path = @"C:\pp\Fri.mp4";
            else if (day == "Sat") path = @"C:\pp\Sat.mp4";
            else if (day == "Sun") path = @"C:\pp\Sun.mp4";


            switch_Screen.PlayVideo(path);
        }

        private void StartScheduledPromo()
        {
            if (_promoRunning) return; // уже идёт — не дублирет

            // Проверка плеера
            if (switch_Screen == null || !switch_Screen.IsLoaded)
            {
                switch_Screen = new Switch_Screen();
                switch_Screen.Closed += (_, __) => switch_Screen = null;
                switch_Screen.Show();
            }

            // Выполнение событий
            Smoothly_open_the_window_swimming_pool_active();
            TimerSheduler_Tick(this, EventArgs.Empty);
            //

            _promoRunning = true;

            // запланировать остановку через 2 минуты (одноразово)
            _promoStopTimer?.Stop();
            _promoStopTimer = new DispatcherTimer { Interval = PromoDuration };
            _promoStopTimer.Tick += (s, e) => StopScheduledPromo();
            _promoStopTimer.Start();
        }

        private void StopScheduledPromo()
        {
            _promoStopTimer?.Stop(); //Таймер отключается

            Smoothly_hide_the_window_swimming_pool_active(); // Полотно активируется
            Show_today_schedule_bt_click(null, null); // Расписание восстанавливается
            _promoRunning = false; 
        }


        ///////////////////// Открытие окон
        public void OpenBlackScreen() // Открытие полотна для экрана бассейна
        {
            // black_Screen.Show();
        }

        public void OpenBlackScreen_djacuzi() // открытие полотна для экрана джакузи
        {
            // black_Screen_djacuzi.Show();
        }


        ///////////////////// Анимация элементов


        private void Animation_Opacity_Element(UIElement element) // Включение анимации затемнения
        {
            if (element == null) return;
            if (element.Opacity == 0) return;

            element.BeginAnimation(UIElement.OpacityProperty, null); // сброс
            element.Opacity = 1.0;

            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };
            animation.Completed += (_, __) =>
            {
                element.Opacity = 0.0;
                if (element is FrameworkElement fe) fe.Visibility = Visibility.Hidden;
            };
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void Undo_Animation_Opacity_Element(UIElement element) // Выключение анимации затемления
        {
            if (element == null) return;
            if (element.Opacity == 1) return;

            element.BeginAnimation(UIElement.OpacityProperty, null); // сброс
            if (element is FrameworkElement fe) fe.Visibility = Visibility.Visible;
            element.Opacity = 0.0;

            var animation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(1),
                FillBehavior = FillBehavior.Stop
            };
            animation.Completed += (_, __) => element.Opacity = 1.0;
            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        ///////////////////// Дополнительные функции /////////

        private void Active_Marketing_Window(object sender, EventArgs e) // Активация окна маркетинга
        {
            Undo_Animation_Opacity_Element(The_Marketing_Window);
            Animation_Opacity_Element(Universal_Main_Window);
        }

        private void Avtive_Universal_Screen_Contol(object sender, EventArgs e) // Активация главного окна
        {
            Undo_Animation_Opacity_Element(Universal_Main_Window);
            Animation_Opacity_Element(The_Marketing_Window);
        }


        ///////////////////// Раздел поля маркетинга ///////////
      //  ///\\\
      //  \\\///

        /// Бассейн

        public void Activation_screen_swimming_pool_bt_click(object sender, EventArgs e) // Активировать экран у бассейна
        {
            //switch_Screen = new Switch_Screen(); // Создаем новый экземпляр окна
            //switch_Screen.Show();
            if (switch_Screen == null || !switch_Screen.IsLoaded)
            {
                switch_Screen = new Switch_Screen();
                switch_Screen.Closed += (_, __) => switch_Screen = null;
                switch_Screen.Show();
            }
            else
            {
                switch_Screen.Activate();
            }

            Deactivation_drag_button_swimming_pool_bt_click(null, null); // Деактивировать кнопку навигации у экрана бассейна
            ActiveFocus_switchScreen();

        }

        public void Smoothly_hide_the_window_swimming_pool_bt_click(object sender, EventArgs e) // Скрытие окна бассейн
        {
            Animation_Opacity_Element(switch_Screen);

        }

        public void Smoothly_hide_the_window_swimming_pool_active()
        {
            Animation_Opacity_Element(switch_Screen);
        }

        public void Smoothly_open_the_window_swimming_pool_bt_click(Object sender, EventArgs e) // Раскрытие окна бассейн
        {
            Undo_Animation_Opacity_Element(switch_Screen);

        }

        public void Smoothly_open_the_window_swimming_pool_active()
        {
            Undo_Animation_Opacity_Element(switch_Screen);
        }

        public void Activation_drag_button_swimming_pool_bt_click(object sender, EventArgs e) // Вернуть кнеопку навигации
        {
            switch_Screen.DragMove_bt.Opacity = 1;
        }
        public void Deactivation_drag_button_swimming_pool_bt_click(Object sender, EventArgs e) // Убрать кнопку навигации
        {
            switch_Screen.DragMove_bt.Opacity = 0;
        }

        public void ActiveFocus_switchScreen_bt_click(object sender, EventArgs e) // Кнопка активации фокуса окна бассейна
        {
            ActiveFocus_switchScreen();
        }

        public void UnFocusScreens_bt_click(Object sender, EventArgs e) // кнопка деактивации фокуса окна бассейна
        {
            UnFocusScreens();
        }


        public void Deactivation_screen_swimming_pool_bt_click(object sender, EventArgs e) // Деактивировать экран у бассейна
        {
            switch_Screen.Close();
            try { black_Screen?.Close(); } catch { }
            try { switch_Screen?.Close(); } catch { }

        }

        // ////////Активация рекламных роликов
        public void Active_screen_switch_test_promt1(object sender, EventArgs e) // Тестовый
        {
            switch_Screen.PlayVideo(@"C:\pp\Tue.mp4");
        }

        public void Active_screen_switch_test_promt2(object sender, EventArgs e) // Тестовый
        {
            switch_Screen.PlayVideo(@"C:\pp\Mon.mp4");
        }

        public void Active_screen_switch_Zel1(object sender, EventArgs e) // Зелинский 1
        {
            switch_Screen.PlayVideo(@"C:\promt\Zel1.mp4");
        }

        public void Active_screen_switch_Zel2(object sender, EventArgs e) // Зелинский 2
        {
            switch_Screen.PlayVideo(@"C:\promt\Zel2.mp4");
        }

        public void Active_screen_switch_Zel3(object sender, EventArgs e) // Зелинский 2
        {
            switch_Screen.PlayVideo(@"C:\promt\Zel3.mp4");
        }

        public void Active_scree_switch_Chestnaya_r(object sender, EventArgs e) // Честная рыба
        {
            switch_Screen.PlayVideo(@"C:\promt\Chestnaya_r.mp4");
        }



        /// ////////Джакузи
        public void Activation_screen_djacuzi_bt_click(Object sender, EventArgs e) // Активация экрана у джакузи
        {
            switch_Screen_Djacuzi = new Switch_Screen_djacuzi();
            switch_Screen_Djacuzi.Show();
        }

        public void Deactivation_screen_djacuzi_bt_click(Object sender, EventArgs e) // Деактивация экрана у джакузи
        {
            switch_Screen_Djacuzi.Close();
        }

        // Активация рекламных роликов экрана у дажкузи

        public void Active_screen_switch_djacuzi_test_promt1(object sender, EventArgs e) // Тестовый
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\pp\Mon.mp4");
        }

        public void Active_screen_switch_djacuzi_test_promt2(object sender, EventArgs e) // Тестовый
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\pp\Fri.mp4");
        }

        public void Active_screen_switch_djacuzi_Zel1(object sender, EventArgs e) // Зелинский 1
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\promt\Zel1.mp4");
        }

        public void Active_screen_switch_djacuzi_Zel2(object sender, EventArgs e) // Зелинский 2
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\promt\Zel2.mp4");
        }

        public void Active_screen_switch_djacuzi_Zel3(object sender, EventArgs e) // Зелинский 2
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\promt\Zel3.mp4");
        }

        public void Active_scree_switch_djacuzi_Chestnaya_r(object sender, EventArgs e) // Честная рыба
        {
            switch_Screen_Djacuzi.PlayVideo(@"C:\promt\Chestnaya_r.mp4");
        }


        ///////////////////// Параллельное взаимодействие для экрана бассейн ////////////

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

        /////////////////////////////// Технические события
        /// ///\\\
        /// \\\///

        public void Close_all_window_bt_click(object sender, EventArgs e) // Закрытие всех приложений
        {
            base.OnClosed(e);

            // 1) Отписаться и остановить оба таймера
            TimerSheduler.Tick -= TimerSheduler_Tick;
            TimerSheduler.Stop();

            TimerCheckTime.Tick -= TimerCheckTime_Tick;
            TimerCheckTime.Stop();
            black_Screen.Close();
            black_Screen_djacuzi.Close();
            switch_Screen.Close();
            switch_Screen_Djacuzi.Close();
            this.Close();

            base.OnClosed(e);

            // Таймеры
            TimerSheduler.Tick -= TimerSheduler_Tick;
            TimerSheduler.Stop();

            TimerCheckTime.Tick -= TimerCheckTime_Tick;
            TimerCheckTime.Stop();

            // расписание роликов:
            if (_promoStartTimer != null) { _promoStartTimer.Stop(); _promoStartTimer = null; }
            if (_promoStopTimer != null) { _promoStopTimer.Stop(); _promoStopTimer = null; }

            // Окна-полотна и плееры
            try { black_Screen?.Close(); } catch { }
            try { black_Screen_djacuzi?.Close(); } catch { }
            try { switch_Screen?.Close(); } catch { }
            try { switch_Screen_Djacuzi?.Close(); } catch { }

            // На всякий случай полностью гасим приложение
            Application.Current.Shutdown();
        }


        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // 1) Отписаться и остановить оба таймера
            TimerSheduler.Tick -= TimerSheduler_Tick;
            TimerSheduler.Stop();

            TimerCheckTime.Tick -= TimerCheckTime_Tick;
            TimerCheckTime.Stop();
            black_Screen.Close();
            black_Screen_djacuzi.Close();
            switch_Screen.Close();
            switch_Screen_Djacuzi.Close();
            this.Close();

            base.OnClosed(e);

            // Таймеры
            TimerSheduler.Tick -= TimerSheduler_Tick;
            TimerSheduler.Stop();

            TimerCheckTime.Tick -= TimerCheckTime_Tick;
            TimerCheckTime.Stop();

            // расписание роликов:
            if (_promoStartTimer != null) { _promoStartTimer.Stop(); _promoStartTimer = null; }
            if (_promoStopTimer != null) { _promoStopTimer.Stop(); _promoStopTimer = null; }

            // Окна-полотна и плееры
            try { black_Screen?.Close(); } catch { }
            try { black_Screen_djacuzi?.Close(); } catch { }
            try { switch_Screen?.Close(); } catch { }
            try { switch_Screen_Djacuzi?.Close(); } catch { }

            // На всякий случай полностью гасим приложение
            Application.Current.Shutdown();
        }

    }
}
