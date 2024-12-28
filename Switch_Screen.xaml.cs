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
            MoveWindowToSecondScreen();
        }

        private void MoveWindowToSecondScreen()
        {
            // Получаем все доступные экраны
            var screens = Screen.AllScreens;

            // Проверяем, есть ли второй экран
            if (screens.Length > 1)
            {
                // Получаем второй экран
                var secondScreen = screens[1];

                // Устанавливаем размер окна
                this.Width = 1600;
                this.Height = 900;

                // Устанавливаем позицию окна на втором экране
                this.Left = secondScreen.WorkingArea.Left;
                this.Top = secondScreen.WorkingArea.Top;
            }
            //else
            //{
            //    MessageBox.Show("Второй экран не найден.");
            //}
        }

        private void MessegeBoxShow_Active(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Второй экран не найден.");
        }

    }
}
