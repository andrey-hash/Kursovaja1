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
using System.IO;

namespace Kursovaja_rabota
{

    public partial class PBX_USER_FORM : Form
    {

        public PBX_USER_FORM()
        {
            InitializeComponent();

        }



        int sec = 0;
        public int CallerPhoneNumber;//номер телефона
        public int CalleePhoneNumder = 0; // номер набранного телефона
        public bool Call = false;// переменная, обозначающая вызов терминала
        public bool Cll = false;// переменная, обозначающая вызов телефона
        public bool Headset_1_State = false; //положение трубки АТС
        public bool Headset_2_State = false; // положение трубки телефона
        private const String dialButtonSound = @"D:\Рабочий стол\For KR\Button.wav";
        private const String toneSound = @"D:\Рабочий стол\For KR\Tone.wav";
        private const String ringSound = @"D:\Рабочий стол\For KR\Ring.wav";
        private const String shortToneSound = @"D:\Рабочий стол\For KR\ShortTone.wav";
        SoundPlayer player = new SoundPlayer(); // музыкальное сопровождение
        DispatcherTimer timer = new DispatcherTimer(); // таймер
        private void Timer_Run(object sender, EventArgs e) // событие таймера
        {
            TextBox1.Text = sec.ToString() + " s";
            TextBox.Text = sec.ToString() + " s";
            sec++;
        }

        public new void Click(string n) //нажатие кнопок
        {
            bool soundIsOn = false;
            if (System.IO.File.Exists(dialButtonSound))
            {
                player.SoundLocation = (dialButtonSound);
                player.Play();
                soundIsOn = true;
            }
            TextBox.Text = TextBox.Text += n;
            if (soundIsOn)
                player.Stop();

        }
        public void Click1(string k) //нажатие кнопок
        {
            bool soundIsOn = false;
            if (System.IO.File.Exists(dialButtonSound))
            {
                player.SoundLocation = (dialButtonSound);
                player.Play();
                soundIsOn = true;
            }
            TextBox1.Text = TextBox1.Text += k;
            if (soundIsOn)
                player.Stop();
        }

        public class Stack<T>
        {
            int index = 0;
            int size = 0;
            T[] innerArray = new T[1];
            public void Push(T item)
            {
                innerArray[index++] = item;
            }
            public T Pop()
            {
                return innerArray[--index];
            }

            public int Size()
            {
                return size = index + 1;
            }
            public T Get(int k) //should be changed to secure array access or catch out-of-bounds exeption
            {

                return innerArray[k];

            }

        }

        Stack<int> HiddenAddressBook = new Stack<int>();

        public void Button1_Click(object sender, EventArgs e)
        {
            Click(DialerButton1.Text);

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Click(DialerButton2.Text);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Click(DialerButton3.Text);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Click(DialerButton4.Text);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Click(DialerButton5.Text);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Click(DialerButton6.Text);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Click(DialerButton7.Text);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Click(DialerButton8.Text);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Click(DialerButton9.Text);
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            Click(DialerButton0.Text);
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            player.Stop();
            TextBox.Text = null; //Кнопка *
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            int last = HiddenAddressBook.Size() > 1 ? HiddenAddressBook.Get(1) : 0;
            string lasst = Convert.ToString(last);
            TextBox.Text = lasst;
            //кнопка # 
        }

        public void CallButtonOnClick(object sender, EventArgs e)
        {
            Call = true;
            OutCall();

        }

        public void PhoneNumber()
        {
            string bmssg;
            bmssg = "Wrong CalleePhoneNumder";

            if (TextBox.Text != null)
            {
                string numb = TextBox.Text;             
                int count = numb.ToCharArray().Count(); 

                if (count == 3) 
                {
                    if (TextBox.Text != "000")
                    {
                        int index = Convert.ToInt32(numb); 
                        PhoneCall();
                        HiddenAddressBook.Push(index); 
                        HiddenAddressBook.Pop();
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
                string numb1 = TextBox1.Text;            
                int count1 = numb1.ToCharArray().Count(); 

                if (count1 == 3) 
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
            if (File.Exists(ringSound))
            {
                player.SoundLocation = ringSound;
                player.Play();
            }
        }
        public void OutCall()
        {
            PhoneNumber();
            if (File.Exists(toneSound))
            {
                player.SoundLocation = toneSound;
                player.Play();
            }

        }
        public void Busy()
        {
            if (File.Exists(shortToneSound)) ;
            player.SoundLocation = shortToneSound;
            player.Play();
        }
        private void HeadSet_1_Click(object sender, EventArgs e) //Код отвечающий за трубку
        {
            bool soundIsOn = false;

            if (!Call)
            {
                if (!Headset_1_State)
                {
                    if (Cll)
                    {
                        Headset_1_State = true;
                        if (soundIsOn)
                            player.Stop();
                        timer.Tick += new EventHandler(Timer_Run);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }
                    else
                    {
                        if (System.IO.File.Exists(toneSound))
                        {
                            player.SoundLocation = toneSound;
                            player.Play();
                            soundIsOn = true;
                        }
                        Headset_1_State = true;
                        CallButton.Visible = true;
                        panel1.Visible = true;
                    }
                }
                else
                {
                    if (Cll)
                    {
                        Headset_1_State = false;
                        if (soundIsOn)
                            player.Stop();
                        timer.Stop();
                        TextBox.BackColor = Color.White;
                        Cll = false;
                        TextBox.Text = null;
                        sec = 0;
                    }
                    else
                    {
                        if (soundIsOn)
                            player.Stop();
                        Headset_1_State = false;
                        CallButton.Visible = false;
                        panel1.Visible = false;
                        TextBox.Text = null;
                    }
                }
            }

        }




        public void PhoneCall() //для принятия вызова и передачи на целевой телефон
        {

            if (!Cll)
            {
                if (!Headset_2_State)
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
                if (!Headset_1_State)
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

        private void SecondPhoneDialerButton1OnClick(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton1.Text);
        }

        private void B2_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton2.Text);
        }
        private void B3_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton3.Text);
        }

        private void B4_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton4.Text);
        }

        private void B5_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton5.Text);
        }

        private void B6_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton6.Text);
        }

        private void B7_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton7.Text);
        }

        private void B8_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton8.Text);
        }

        private void B9_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton9.Text);
        }

        private void B0_Click(object sender, EventArgs e)
        {
            Click1(SecondPhoneDialerButton0.Text);
        }

        private void SecondCallButtonOnClick(object sender, EventArgs e)
        {
            Cll = true;
            OutCall();
        }

        private void BPipe_Click(object sender, EventArgs e)
        {
            bool soundIsOn = false;

            if (Cll == false) //Телефон не звонит
            {
                if (Headset_2_State == false)
                {
                    if (Call == true)
                    {
                        Headset_2_State = true;
                        player.Stop();
                        timer.Tick += new EventHandler(Timer_Run);
                        timer.Interval = new TimeSpan(0, 0, 1);
                        timer.Start();
                    }
                    else
                    {


                        if (System.IO.File.Exists(toneSound))
                        {
                            player.SoundLocation = toneSound;
                            player.Play();
                            soundIsOn = true;
                        }

                        Headset_2_State = true;
                        SecondPhoneCallButton.Visible = true;
                        panel2.Visible = true;

                    }


                } //Трубка в положении выкл
                else
                {
                    if (Call == true)
                    {
                        Headset_2_State = false;
                        if (soundIsOn)
                            player.Stop();
                        timer.Stop();
                        TextBox1.BackColor = Color.White;
                        Call = false;
                        TextBox1.Text = null;
                        sec = 0;
                    }
                    else
                    {
                        if (soundIsOn)
                            player.Stop();
                        Headset_2_State = false;
                        SecondPhoneCallButton.Visible = false;
                        panel2.Visible = false;
                        TextBox1.Text = null;
                    }

                }             //Трубка в положении вкл

            }

        }

    }


}





