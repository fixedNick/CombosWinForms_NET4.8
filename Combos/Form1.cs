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
    public partial class Form1 : Form
    {
        // public static - чтобы могли обратиться к нашей главной форме из других файлов
        // Инициализация главной формы в конструкторе
        public static Form1 MainForm;
        public Form1()
        {
            InitializeComponent();
            // Инициализация главной формы, та, что появилась на экране при запуске и есть this.
            MainForm = this;
        }

        // Кликнули на ВВОД N & K
        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем форму для ввода
            InputForm input = new InputForm();
            // Показываем форму для ввода
            input.Show();
        }

        // public - чтобы мы могли у ОБЪЕКТА(MainForm) нашей главной формы вызвать этот метод из другого файла
        public void GetCombos()
        {
            textBox1.Clear(); // Почистим текстбокс для вывода
            Combos.Init(); // Сделаем все перестановки, они сохранятся в список Combos.AllCombos
            foreach (var combo in Combos.AllCombos) // Переберем все перестановки
                textBox1.AppendText(combo + Environment.NewLine); // Каждую перестановку выведем на отдельной строке в textbox

            var sb1 = new StringBuilder("123");
            sb1.Append("123");

            // Enviroment.NewLine - специальная переменная, для перехода на новую строку, представляет собой \r\n комбинацию
        }
    }
}
