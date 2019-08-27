using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Threading;



namespace Kursovaja_rabota
{
    
        public partial class Form_001 : Form
{
        
        public Form_001()
        {
            InitializeComponent();
            
        }

       

        int sec = 0;
        public int phone;//номер телефона
        public int number = 0; // номер набранного телефона
        public bool Call = false;// переменная, обозначающая вызов терминала
        public bool Cll = false;// переменная, обозначающая вызов телефона
        public bool Pipe = false; //положение трубки АТС
        public bool Ppe = false; // положение трубки телефона
        SoundPlayer player = new SoundPlayer(); // музыкальное сопровождение
        DispatcherTimer timer = new DispatcherTimer(); // таймер
        private void Timer_Run(object sender, EventArgs e) // событие таймера
        {
            TextBox1.Text = sec.ToString() + " s";
            TextBox.Text = sec.ToString() + " s";
            sec++;
        }
       
        public void Klik(string n) //нажатие кнопок
        {

            player.SoundLocation = (@"D:\Рабочий стол\For KR\Button.wav");
            player.Play();
            TextBox.Text = TextBox.Text += n;
            player.Stop();
        }
        public void Klik1(string k) //нажатие кнопок
        {

            player.SoundLocation = (@"D:\Рабочий стол\For KR\Button.wav");
            player.Play();
            TextBox1.Text = TextBox1.Text += k;
            player.Stop();
        }

            public class Stack<T>
        {
            int index = 0;
            T[] innerArray = new T[1];
            public void Push (T item)
            {
                innerArray[index++] = item;
            }
            public T Pop()
            {
                return innerArray[--index];
            }
            public T Get (int k)
            {
                return innerArray[k];
            }
            
         }

         Stack<int> HiddenBook = new //создать новую адресную книгу
         Stack<int>();

        public void Button1_Click(object sender, EventArgs e)
        {
            Klik(button1.Text);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Klik(button2.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Klik(button3.Text);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Klik(button4.Text);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Klik(button5.Text);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Klik(button6.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Klik(button7.Text);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Klik(button8.Text);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Klik(button9.Text);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Klik(button11.Text);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            player.Stop();
            TextBox.Text = null; //Кнопка *
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            int last = HiddenBook.Get(1);
           string lasst = Convert.ToString(last);
           TextBox.Text = lasst;
           //кнопка # 
        }
        
        public void Button15_Click(object sender, EventArgs e)
        {
            Call = true;
            OutCall();
                     
        }

        public void PhoneNumber()
        {
            string bmssg;
            bmssg = "Wrong number";
            
            if (TextBox.Text != null)
            {
                string numb = TextBox.Text;             // Приведение написанного в текстбоксе к одной переменной
                int count = numb.ToCharArray().Count(); // Подсчет символов в текстбоксе

                if (count == 3) // Если колво равно 3
                {
                    if (TextBox.Text != "000")
                    {
                        int index = Convert.ToInt32(numb); //перевести в инт
                        PhoneCall();
                        HiddenBook.Push(index); //последний набранный номер
                        HiddenBook.Pop();
                    }
                    if (TextBox.Text == "000")
                    {
                        TextBox.Text = bmssg;
                    }
                }

                if (count > 3)
                {

                    TextBox.Text = bmssg;

                }

                if (count < 3)
                {
                    TextBox.Text = bmssg;
                }
            }
            else
            {
                string numb1 = TextBox1.Text;             // Приведение написанного в текстбоксе к одной переменной
                int count1 = numb1.ToCharArray().Count(); // Подсчет символов в текстбоксе

                if (count1 == 3) // Если колво равно 3
                {
                    if (TextBox1.Text == "000")
                    {
                        player.Stop();
                        PhoneCall();
                        
                    }
                    if (TextBox1.Text != "000")
                    {
                        TextBox1.Text = bmssg;
                    }
                }

                if (count1 > 3)
                {
                    TextBox1.Text = bmssg;
                }

                if (count1 < 3)
                {
                    TextBox1.Text = bmssg;
                }
            }
        }

        public void InCall()
        {
            player.SoundLocation = @"D:\Рабочий стол\For KR\Ring.wav";
            player.Play();
        }
        public void OutCall()
        {
           PhoneNumber();
           player.SoundLocation = @"D:\Рабочий стол\For KR\Tone.wav";
           player.Play();
                       
        }
        public void Busy()
        {
            player.SoundLocation = @"D:\Рабочий стол\For KR\ShortTone.wav";
            player.Play();
        }
        private void Button14_Click(object sender, EventArgs e) //Код отвечающий за трубку
        {
            if (Call == false)
            {
                if (Pipe == false)
                {
                    if (Cll == true)
                    {
                        Pipe = true;
                        player.Stop();
                        timer.Tick += new EventHandler(Timer_Run);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }
                    else
                    {
                        player.SoundLocation = @"D:\Рабочий стол\For KR\Tone.wav";
                        player.Play();
                        Pipe = true;
                        button15.Visible = true;
                        panel1.Visible = true;
                    }
                    

                }
                else
                {
                    if (Cll == true)
                    {
                        Pipe = false;
                        player.Stop();
                        timer.Stop();
                        TextBox.BackColor = Color.White;
                        Cll = false;
                        TextBox.Text = null;
                        sec = 0;
                    }
                    else
                    {
                        player.Stop();
                        Pipe = false;
                        button15.Visible = false;
                        panel1.Visible = false;
                        TextBox.Text = null;
                    }
                    

                }
            }
           
        }
        
        
       
        
        public void PhoneCall() //для принятия вызова и передачи на целевой телефон
        {

                if (Cll != true)
                {
                    if (Ppe == false)
                    {
                        TextBox1.BackColor = Color.Green;
                        InCall();
                    }
                    else
                    {
                        Busy();
                        TextBox1.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (Pipe == false)
                    {
                        TextBox.BackColor = Color.Green;
                        InCall();
                    }
                    else
                    {
                         Busy();
                         TextBox.BackColor = Color.Red;
                    }
                }
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void B1_Click(object sender, EventArgs e)
        {
            Klik1(B1.Text);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Klik1(B2.Text);
        }
        private void B3_Click(object sender, EventArgs e)
        {
            Klik1(B3.Text);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            Klik1(B4.Text);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            Klik1(B5.Text);
        }

        private void B6_Click(object sender, EventArgs e)
        {
            Klik1(B6.Text);
        }

        private void B7_Click(object sender, EventArgs e)
        {
            Klik1(B7.Text);
        }

        private void B8_Click(object sender, EventArgs e)
        {
            Klik1(B8.Text);
        }

        private void B9_Click(object sender, EventArgs e)
        {
            Klik1(B9.Text);
        }

        private void B0_Click(object sender, EventArgs e)
        {
            Klik1(B0.Text);
        }

        private void BCALL_Click(object sender, EventArgs e)
        {
            Cll = true;
            OutCall();
        }

        private void BPipe_Click(object sender, EventArgs e)
        {
            if (Cll == false) //Телефон не звонит
            {
                if (Ppe == false)
                {
                    if (Call == true)
                    {
                        Ppe = true;
                        player.Stop();
                        timer.Tick += new EventHandler(Timer_Run);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }
                    else
                    {
                        player.SoundLocation = @"D:\Рабочий стол\For KR\Tone.wav";
                        player.Play();
                        Ppe = true;
                        BCALL.Visible = true;
                        panel2.Visible = true;
                    }
                   

                } //Трубка в положении выкл
                else
                {
                    if (Call == true)
                    {
                        Ppe = false;
                        player.Stop();
                        timer.Stop();
                        TextBox1.BackColor = Color.White;
                        Call = false;
                        TextBox1.Text = null;
                        sec = 0;
                    }
                    else
                    {
                        player.Stop();
                        Ppe = false;
                        BCALL.Visible = false;
                        panel2.Visible = false;
                        TextBox1.Text = null;
                    }

                }             //Трубка в положении вкл
               
            }
            
        }

    }
        

}
                 




