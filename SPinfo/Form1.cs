using System;
using System.Windows.Forms;

namespace SPinfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int spThickness = 0;  // Толщина стеклопакета.
            int glassThickness = 0;  // Толщина стекла.
            int slashes = 0;   // Количество символов '/' в артикуле.
            string[] subs = textBox1.Text.Split('/');  // Части артикула, разделенные символом '/'.

            foreach (char c in textBox1.Text)   // Считаем количество символов '/' в артикуле.
                if (c == '/') slashes++;
            
            for (int i = 0; i < subs.Length; i++)  // Оставляем только числа артикула, другие символы убираем.
            {
                int digits = 0;

                subs[i] = subs[i].Trim(); // Удаляем лишние пробелы в начале и конце.

                foreach (char c in subs[i])
                {
                    if (char.IsDigit(c))
                        digits++;
                    else
                        break;
                }

                subs[i] = subs[i].Substring(0, digits);

                if (subs[i] == "")  // Если числа нет, значит некорректный артикул. В этом случае ничего не делаем.
                {
                    label2.Text = "Некорректный артикул";
                    return;
                }
            }
            
            for (int i = 0; i < subs.Length; i++)  // Считаем толщину всего стеклопакета и толщину стекол.
            {
                spThickness += int.Parse(subs[i]);

                if (i % 2 == 0)
                    glassThickness += int.Parse(subs[i]);
            }


                // Вывод информации:

            if (slashes == 2)   // Информация о количестве камер СП.
                label2.Text = "Однокамерный";
            else if (slashes == 4)
                label2.Text = "2 камерный";
            else
            {
                label2.Text = "Некорректный артикул";
                return;
            }

            label2.Text += '\n' + "Толщина всего СП: " + spThickness.ToString();  // Информация о толщине всего стеклопакета и толщине стекол.
            label2.Text += '\n' + "Толщина стекла в данном СП: " + glassThickness.ToString();
        }
    }
}