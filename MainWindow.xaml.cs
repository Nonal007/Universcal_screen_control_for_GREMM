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
        public Black_screen black_Screen = new Black_screen();
        public Black_screen_djacuzi black_Screen_djacuzi = new Black_screen_djacuzi();
        public Switch_Screen switch_Screen = new Switch_Screen();
        public Switch_Screen_djacuzi switch_Screen_Djacuzi = new Switch_Screen_djacuzi();
        // период и длительность
        public static readonly TimeSpan PromoPeriod = TimeSpan.FromMinutes(2);
        public static readonly TimeSpan PromoDuration = TimeSpan.FromMinutes(1);

        public DispatcherTimer _promoStartTimer;
        public DispatcherTimer _promoStopTimer;

        public bool _promoRunning; // флаг: сейчас идёт запланированный показ

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
            SetupPromoTimersAligned(); // если нужно «ровно :00, :10, :20 ...»
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
                //Activation_screen_swimming_pool_bt_click(this, EventArgs.Empty);

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

                //Smoothly_hide_the_window_swimming_pool_bt_click(this, EventArgs.Empty);
                //Deactivation_drag_button_swimming_pool_bt_click(this, EventArgs.Empty);
                //Smoothly_open_the_window_swimming_pool_bt_click(this, EventArgs.Empty);
                //black_Screen.Black_screen_CheckBox_Unchecked(null, null);
                //OpenFile("C:\\tasks_a\\StopBlackScript.bat");
            }

            if (TimeTextBlock.Text == "8:31")
            {
                //black_Screen_djacuzi.Black_screen_CheckBox_Unchecked_second(null, null);
                //OpenFile("C:\\tasks_a\\StopBlackScript.bat");

            }

            if (TimeTextBlock.Text == "22:30")
            {
                //black_Screen.Black_screen_CheckBox_Checked(null, null);
                //OpenFile("C:\\tasks_a\\StartBlackScript.bat");
                switch_Screen.Close();
                switch_Screen_Djacuzi.Close();
                try { black_Screen?.Close(); } catch { }
                try { black_Screen_djacuzi?.Close(); } catch { }
                try { switch_Screen?.Close(); } catch { }
                try { switch_Screen_Djacuzi?.Close(); } catch { }

            }

            if (TimeTextBlock.Text == "23:41")
            {
                //black_Screen_djacuzi.Black_screen_CheckBox_Checked_second(null, null);
                //OpenFile("C:\\tasks_a\\StartBlackScript.bat");

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

        // Если хотите, чтобы срабатывания были ровно в :00, :10, :20 и т.п.
        private void SetupPromoTimersAligned()
        {
            // первый старт — через дельту до ближайшего кратного 10 минут
            var now = DateTime.Now;
            var minutesToNext = 2 - (now.Minute % 2);
            if (minutesToNext == 2) minutesToNext = 0;
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
                _promoStartTimer.Tick += (s1, e1) => StartScheduledPromo();
                _promoStartTimer.Start();
            };
            first.Start();
        }

        // Базовый вариант без выравнивания:
        // private void SetupPromoTimersSimple()
        // {
        //     _promoStartTimer = new DispatcherTimer { Interval = PromoPeriod };
        //     _promoStartTimer.Tick += (s, e) => StartScheduledPromo();
        //     _promoStartTimer.Start();
        // }

        //private async void StartScheduledPromo() // тестовая функция
        //{
        //    if (_promoRunning) return;
        //    _promoRunning = true;

        //    if (switch_Screen == null || !switch_Screen.IsLoaded)
        //    {
        //        switch_Screen = new Switch_Screen();
        //        switch_Screen.Closed += (_, __) => switch_Screen = null;
        //        switch_Screen.Show();

        //        // дождаться первой отрисовки окна
        //        var tcs = new TaskCompletionSource<bool>();
        //        EventHandler handler = null;
        //        handler = (s, e) => { switch_Screen.ContentRendered -= handler; tcs.TrySetResult(true); };
        //        switch_Screen.ContentRendered += handler;
        //        await tcs.Task; // <--- здесь окно уже «видимое»
        //    }
        //    else
        //    {
        //        // если окно уже показывалось раньше, просто пропустим ожидание
        //        await switch_Screen.Dispatcher.InvokeAsync(() => { }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        //    }

        //    Smoothly_open_the_window_swimming_pool_active();

        //    // обновляем день/дату и запускаем расписание
        //    DisplayCurrentDateAndDay();
        //    WeekCycles_click(); // внутри него у тебя switch_Screen.PlayVideo(...)

        //    // стоп через 2 минуты
        //    _promoStopTimer?.Stop();
        //    _promoStopTimer = new DispatcherTimer { Interval = PromoDuration };
        //    _promoStopTimer.Tick += (s, e) => StopScheduledPromo();
        //    _promoStopTimer.Start();
        //}


        private void StartScheduledPromo()
        {
            if (_promoRunning) return; // уже идёт — не дублируем

            // гарантируем, что окно-плеер существует и показано
            if (switch_Screen == null || !switch_Screen.IsLoaded)
            {
                switch_Screen = new Switch_Screen();
                switch_Screen.Closed += (_, __) => switch_Screen = null;
                switch_Screen.Show();
            }

            Smoothly_open_the_window_swimming_pool_active();
            TimerSheduler_Tick(this, EventArgs.Empty);
            // ОБНОВИТЬ дату/время и вызвать расписание по дням
            //DisplayCurrentDateAndDay();
            //WeekCycles_click();
            // запустить нужный ролик/сценарий
            // это ваш существующий обработчик: Active_screen_switch_test_promt1(...)
            // Можно вызвать напрямую:
            //Active_screen_switch_test_promt1Active_screen_switch_test_promt1(this, EventArgs.Empty);

            _promoRunning = true;

            // запланировать остановку через 2 минуты (одноразово)
            _promoStopTimer?.Stop();
            _promoStopTimer = new DispatcherTimer { Interval = PromoDuration };
            _promoStopTimer.Tick += (s, e) => StopScheduledPromo();
            _promoStopTimer.Start();
        }

        private void StopScheduledPromo()
        {
            _promoStopTimer?.Stop();

            // Вызвать вашу функцию отключения полотна
            // Если это метод MainWindow:
            // switch_screen_polotno_off();
            Smoothly_hide_the_window_swimming_pool_active();
          

            // Если это метод окна-плеера:
            // switch_Screen?.switch_screen_polotno_off();

            // Если её нет — примерный «аналог»:
            // switch_Screen?.StopVideoAndHideOverlay(); // замените на ваш метод
            // либо, если видео играет через MediaElement внутри switch_Screen — внутри того окна остановите MediaElement.

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

        //public void Active_Switch_screen(object sender, RoutedEventArgs e)
        //{
        //    switch_Screen.Show();
        //}

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
        /// 

        /// Бассейн
        
        public void Activation_screen_swimming_pool_bt_click (object sender, EventArgs e) // Активировать экран у бассейна
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

        public void Deactivation_screen_swimming_pool_bt_click(object sender, EventArgs e) // Деактивировать экран у бассейна
        {
            //if (switch_Screen != null)
            //{
            //    switch_Screen.Screen_swiming_pool_close_bt_click(null, null);
            //    switch_Screen = null; // Устанавливаем switch_Screen в null после закрытия
            //}
            switch_Screen.Close();
            switch_Screen_Djacuzi.Close();
            try { black_Screen?.Close(); } catch { }
            try { black_Screen_djacuzi?.Close(); } catch { }
            try { switch_Screen?.Close(); } catch { }
            try { switch_Screen_Djacuzi?.Close(); } catch { }

        }

        // Активация рекламных роликов
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



        /// Джакузи
        public void Activation_screen_djacuzi_bt_click (Object sender, EventArgs e) // Активация экрана у джакузи
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
