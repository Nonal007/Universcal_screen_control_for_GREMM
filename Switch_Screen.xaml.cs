using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Drawing; // Добавлено для использования Rectangle

namespace Universcal_screen_control_for_GREMM
{
    /// <summary>
    /// Логика взаимодействия для Switch_Screen.xaml
    /// </summary>
    public partial class Switch_Screen : Window
    {
        public Switch_Screen()
        {
            InitializeComponent();
            MoveWindowToFirstScreen();
            mediaElement.MediaEnded += MediaElement_MediaEnded; // Подписка на событие
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero; // Сбросить позицию
            mediaElement.Play(); // Воспроизведение заново
        }

        private void MoveWindowToFirstScreen()  // Перемещение экрана
        {
            // Получаем все доступные экраны
            var screens = Screen.AllScreens;

            // Проверяем, есть ли хотя бы один экран
            if (screens.Length > 1)
            {
                // Получаем первый экран
                var firstScreen = screens[1];

                // Устанавливаем размер окна
                this.Width = 640;
                this.Height = 600;

                // Устанавливаем позицию окна на первом экране
                this.Left = firstScreen.WorkingArea.Left;
                this.Top = firstScreen.WorkingArea.Top;
            }
        }

        public void PlayVideo(string path) // Включение видео-рекламы
        {
            mediaElement.Source = new Uri(path);
            mediaElement.Play();
        }

        private void MessegeBoxShow_Active(object sender, EventArgs e) // Тестовая кнопка
        {
            System.Windows.Forms.MessageBox.Show("Второй экран не найден.");
        }

        public void Screen_swiming_pool_close_bt_click(object sender, EventArgs e) // Закрытие окна
        {
            this.Close();
        }

        /// Расписание промтов
        public void TuePlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Вторник
        {
            string videoPath = @"C:\pp\Tue.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                mediaElement.Stop();
                mediaElement.Source = null;
            }
            catch { /* ignore */ }

            base.OnClosing(e);
        }


    }
}
