using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combos
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // То, что ввели в текстбокс
            string N_fromTextBox = textBox1.Text;
            string K_fromTextBox = textBox2.Text;

            // Проверяем, что в текстбоксы ввели именно числа

            if (int.TryParse(N_fromTextBox, out int N_INT) == false)
            {       
                MessageBox.Show("bad N value");
                return;
            }

            if (int.TryParse(K_fromTextBox, out int K_INT) == false)
            {
                MessageBox.Show("bad K value");
                return;
            }

            // Все, хорошо, назначаем N и K для класса Combos

            Combos.N = N_INT;
            Combos.K = K_INT;
            Form1.MainForm.GetCombos(); // Вызываем метод у главной формы
            this.Close(); // Закрываем данную форму
        }
    }
}
