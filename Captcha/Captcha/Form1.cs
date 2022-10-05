using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Captcha
{
    public partial class Form1 : Form
    {
        private string password1,password2, text;
        private bool result = true;
        
        public Form1()
        {
            InitializeComponent();
            captcha();
            Init();
            NameBox.Text = "";
            LoginBox.Text = ""; 
            Passwd1.Text = "";
            Passwd2.Text = "";
            CaptchaBox.Text = "";

        }
        public void Init()
        {
            NameBox.Tag = false;
            LoginBox.Tag = false;
            Passwd1.Tag = false;
            CaptchaBox.Tag = false;
            Passwd2.Tag = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Validate();
            if (result)
            {
                
                MessageBox.Show("Поздравляю вы зарегистрировались!","Регистрация");
            }
            else
            {
                result = true;
                Init();
                captcha();
            }
           
            
        }
        public void captcha()
        {
            string[] pathFiles = Directory.GetFiles("Res/", "*.png", SearchOption.AllDirectories);

            Random rnd = new Random();
            int id = rnd.Next(0, pathFiles.Length);
            Bitmap imagePic = new Bitmap(pathFiles[id]);

            FileInfo imageFile = new FileInfo(pathFiles[id]);
            text = imageFile.Name;
            text = text.Replace(".png", "");
            CapthaImage.Image = imagePic;
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            NameBox.Tag = NameBox.Text.Length > 0;
            
        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {
            LoginBox.Tag = LoginBox.Text.Length > 0;
           
        }

        private void Passwd1_TextChanged(object sender, EventArgs e)
        {
            Passwd1.Tag = Passwd1.Text.Length > 7;
            if ((bool)Passwd1.Tag)
            {
                password1 = Passwd1.Text;
            }
           
        }

        private void Passwd2_TextChanged(object sender, EventArgs e)
        {
            Passwd2.Tag = Passwd2.Text.Length > 7;
            if ((bool)Passwd2.Tag)
            {
                password2 = Passwd1.Text;
            }
           
        }

        private void CaptchaBox_TextChanged(object sender, EventArgs e)
        {
            
           CaptchaBox.Tag = CaptchaBox.Text == text;
           

        }
        private void Validate()
        {
            if (!(bool)NameBox.Tag)
            {
                NameBox.Text = "Введите имя пользователя!";
                result = false;
            }
            if (!(bool)LoginBox.Tag)
            {
                LoginBox.Text = "Введите логин!";
                result = false;
            }
            if (!(bool)Passwd1.Tag && !(bool)Passwd2.Tag)
            {
                label6.Text = "Пароль должен быть более 7 символов!";
                result = false;
            }
            else
            {
                label6.Text = "";
                if (Passwd1.Text != Passwd2.Text)
                {
                    result = false;
                    label6.Text = "Пароль не совпадает!";
                }
            }
            if (!(bool)CaptchaBox.Tag)
            {
                CaptchaBox.Text = "Неправильно ввели капчу!";
                result = false;
            }
        }
        
    }
}
