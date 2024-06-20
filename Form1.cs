using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Перевірка на заповнення всіх полів
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Отримання параметрів
            double duration = double.Parse(textBox1.Text);
            double amplitude = double.Parse(textBox2.Text);
            double frequency_oscillations = double.Parse(textBox3.Text);
            double total_duration = double.Parse(textBox4.Text);

            int presence_noises = comboBox1.SelectedIndex;

            if (presence_noises == -1)
            {
                MessageBox.Show("Не вибрано жодного елемента!");
            }

            //Аналіз даних
            string diagnosis = ""; // Змінна для зберігання діагнозу

            // Норма
            if (duration >= 0.04 && duration <= 0.12 &&
                amplitude >= 10 && amplitude <= 25 &&
                frequency_oscillations >= 70 && frequency_oscillations <= 150 &&
                total_duration == 0.15 &&
                presence_noises == 0)
            {
                diagnosis = "Норма";
            }
            // Мітральний стеноз
            else if (presence_noises == 1)
            {
                diagnosis = "Мітральний стеноз";
            }
            // Прикуспідальний порок та Аортальний порок
            else if (amplitude < 10 &&
                     presence_noises == 0)
            {
                diagnosis = "Прикуспідальний порок або Аортальний порок. Потрібні додаткові дані.";
            }
            // Дефект міжпредсердної перегородки
            else if (duration < 0.04 && amplitude > 25 &&
                     frequency_oscillations > 150 &&
                     presence_noises == 0)
            {
                diagnosis = "Дефект міжпредсердної перегородки";
            }
            // Якщо не співпадає ні з одним діагнозом
            else
            {
                diagnosis = "Діагноз не визначено";
            }

            // Відображення результату
            label10.Text = diagnosis;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label10.AutoSize = true; // Включаємо автоматичну зміну розміру Label
            label10.MaximumSize = new System.Drawing.Size(550, 0); // Вказуємо максимальну ширину для перенесення тексту
        }
    }
}
