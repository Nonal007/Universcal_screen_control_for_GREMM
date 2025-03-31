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
    /// Логика взаимодействия для Switch_Screen_djacuzi.xaml
    /// </summary>
    public partial class Switch_Screen_djacuzi : Window
    {
        public Switch_Screen_djacuzi()
        {
            InitializeComponent();
            MoveToSecondScreen();
            mediaElement.MediaEnded += MediaElement_MediaEnded; // Подписка на событие

        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero; // Сбросить позицию
            mediaElement.Play(); // Воспроизведение заново
        }


        private void MoveToSecondScreen()
        {
            var screens = Screen.AllScreens;

            // Проверяем, есть ли второй экран
            if (screens.Length > 0)
            {
                // Получаем второй экран
                var secondScreen = screens[0];

                // Устанавливаем размер окна
                this.Width = 1680;
                this.Height = 1050;

                // Устанавливаем позицию окна на втором экране
                this.Left = secondScreen.WorkingArea.Left;
                this.Top = secondScreen.WorkingArea.Top;
            }
        }

        private void MessegeBoxShow_Active(object sender, EventArgs e) // Тестовая кнопка
        {
            System.Windows.Forms.MessageBox.Show("Второй экран не найден.");
        }

        public void Screen_swiming_pool_close_bt_click(object sender, EventArgs e) // Закрытие окна
        {
            this.Close();
        }
        public void PlayVideo(string path) // Включение видео-рекламы
        {
            mediaElement.Source = new Uri(path);
            mediaElement.Play();
        }

        public void TuePlayVIdeo_parnie_click(object sender, RoutedEventArgs e) // Вторник
        {
            string videoPath = @"C:\pp\Tue.mp4"; // путь к файлу
            mediaElement.Source = new Uri(videoPath);
            mediaElement.Play(); // Воспроизводим видео

        }

    }
}

