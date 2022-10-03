using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace WinFormsApp1
{
    public partial class Pomodoro : Form
    {
        public Pomodoro()
        {
            InitializeComponent();
        }

        Timer timer = null!;
        int m, s;
        bool isRunning = false;
        static string path = "C:\\Users\\Svitlana\\Programierung\\C#TeamWork_2022\\dodomu.wav";
        SoundPlayer player = new SoundPlayer(path);

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTime.Text = "25:00";
            this.BackColor = Color.LightCoral;
                        
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            if (lblTime.Text.Contains("25:00"))
            {
                m = 25; s = 0;
            }
            if (lblTime.Text.Contains("15:00"))
            {
                m = 15; s = 0;
            }
            if (lblTime.Text.Contains("05:00"))
            {
                m = 5; s = 0;
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (m >= 0)
                {
                    if (s == 0)
                    {
                        s = 59;
                        m -= 1;
                    }
                    else
                    {
                        s -= 1;
                    }
                }              

                if(m ==0 && s == 0)
                {
                    timer.Stop();
                    btnStart.Text = "Start";
                    player.Play();
                    isRunning = false;
                }

                if (m < 0)
                {
                    timer.Stop();
                    m = 0; s = 0;
                    lblTime.Text = "00:00";
                    btnStart.Text = "Start";
                }
                                                
                lblTime.Text = m.ToString("00") + ":" + s.ToString("00");
            }));
        }

        private void btnPomodoro_Click(object sender, EventArgs e)
        {
            player?.Stop();
            lblTime.Text = "25:00";
            this.BackColor = Color.LightCoral;
            timer?.Stop();
            string message = "Are you sure you want to switch?";
            string title = "Close window";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);
            if (result == DialogResult.Yes)
            {
                m = 25; 
                s = 0;
                Application.DoEvents();
            }
        }

        private void btnLongB_Click(object sender, EventArgs e)
        {
            player?.Stop();
            lblTime.Text = "15:00";
            this.BackColor = Color.LightSeaGreen;
            string message = "Are you sure you want to switch?";
            string title = "Close window";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);
            if (result == DialogResult.Yes)
            {
                m = 15;
                s = 0;
                Application.DoEvents();
            }
        }

        private void btnShortB_Click(object sender, EventArgs e)
        {
            player?.Stop();
            lblTime.Text = "05:00";
            this.BackColor = Color.LightBlue;
            string message = "Are you sure you want to switch?";
            string title = "Close window";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, button);
            if (result == DialogResult.Yes)
            {
                m = 5;
                s = 0;
                Application.DoEvents();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            player?.Stop();
            if (isRunning == true)
            {
                timer.Stop();
                Application.DoEvents();
                isRunning = false;
                btnStart.Text = "Start";
            }
            else
            {
                btnStart.Text = "Stop";
                timer.Start();
                isRunning = true;
            }

            if (lblTime.Text.Contains("00:00"))
            {
                MessageBox.Show("Choose level to start!");
            }
        }
    }
}