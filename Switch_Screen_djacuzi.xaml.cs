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
    /// Логика взаимодействия для Switch_Screen_djacuzi.xaml
    /// </summary>
    public partial class Switch_Screen_djacuzi : Window
    {
        public Switch_Screen_djacuzi()
        {
            InitializeComponent();
            MoveToThirdscreen();
        }

        private void MoveToThirdscreen()
        {
            var screens = Screen.AllScreens;

            // Проверяем, есть ли второй экран
            if (screens.Length > 1)
            {
                // Получаем второй экран
                var thirdScreen = screens[2];

                // Устанавливаем размер окна
                this.Width = 1024;
                this.Height = 768;

                // Устанавливаем позицию окна на втором экране
                this.Left = thirdScreen.WorkingArea.Left;
                this.Top = thirdScreen.WorkingArea.Top;

            }

        }
    }
}
