
 //*Используя полученные знания и класс TrueFalse в качестве шаблона, разработать собственную утилиту хранения данных 
 //(Например: Дни рождения, Траты, Напоминалка, Английские слова и другие).
  
 //Кирсанов Николай задание 4
 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PutEnglishWords
{
    public partial class Form1 : Form
    {
        CheckWord database;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add(tboxEngText.Text, tboxRuText.Text);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database.Count == 1 || database == null) return;
            database.Remove(new Dictionary(tboxEngText.Text, tboxRuText.Text));
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }

        
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new CheckWord(sfd.FileName);
                database.Add("test", "тест");
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }

        
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new CheckWord(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        
        private void miSave_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].EnglishText = tboxEngText.Text;
                database[(int)nudNumber.Value - 1].RussianText = tboxRuText.Text;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Подробности: {ex.Message}", "Откройте или создайте файл со словами ");
            }
        }

        
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tboxEngText.Text = database[(int)nudNumber.Value - 1].EnglishText;
                tboxRuText.Text = database[(int)nudNumber.Value - 1].RussianText;
                
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Подробности: {ex.Message}", "Данное слово отсутствует");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
