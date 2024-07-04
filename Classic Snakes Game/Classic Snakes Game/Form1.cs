using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System;


namespace Classic_Snakes_Game
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int score;
        int highScore;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && Settings.Directions != "right")
            {
                goLeft = true;
                goRight = goUp = goDown = false;
            }
            if (e.KeyCode == Keys.D && Settings.Directions != "left")
            {
                goRight = true;
                goLeft = goUp = goDown = false;
            }
            if (e.KeyCode == Keys.W && Settings.Directions != "down")
            {
                goUp = true;
                goLeft = goRight = goDown = false;
            }
            if (e.KeyCode == Keys.S && Settings.Directions != "up")
            {
                goDown = true;
                goLeft = goRight = goUp = false;
            }
        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.W)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown = false;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void TakeSnapShot(object sender, EventArgs e)
        {
            Label caption = new Label
            {
                Text = "I scored: " + score + " and my Highscore is " + highScore + " on the Snake Game",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Purple,
                AutoSize = false,
                Width = picCanvas.Width,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter
            };
            picCanvas.Controls.Add(caption);

            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = "Snake Game Snapshot",
                DefaultExt = "jpg",
                Filter = "JPG Image File | *.jpg",
                ValidateNames = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                int width = picCanvas.Width;
                int height = picCanvas.Height;
                Bitmap bmp = new Bitmap(width, height);
                picCanvas.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                picCanvas.Controls.Remove(caption);
            }
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
            {
                Settings.Directions = "left";
            }
            if (goRight)
            {
                Settings.Directions = "right";
            }
            if (goDown)
            {
                Settings.Directions = "down";
            }
            if (goUp)
            {
                Settings.Directions = "up";
            }

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.Directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                        }
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            picCanvas.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            for (int i = 0; i < Snake.Count; i++)
            {
                snakeColour = i == 0 ? Brushes.Black : Brushes.DarkGreen;
                canvas.FillEllipse(snakeColour, new Rectangle(
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height));
            }
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle(
                food.X * Settings.Width,
                food.Y * Settings.Height,
                Settings.Width, Settings.Height));
        }

        private void RestartGame()
        {
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            Snake.Clear();

            startButton.Enabled = false;
            snapButton.Enabled = true;
            score = 0;
            txtScore.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        private void EatFood()
        {
            score++;
            txtScore.Text = "Score: " + score;

            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };
            Snake.Add(body);

            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver()
        {
            gameTimer.Stop();
            startButton.Enabled = true;
            snapButton.Enabled = true;

            if (score > highScore)
            {
                highScore = score;
                txtHighScore.Text = "High Score: " + Environment.NewLine + highScore;
                txtHighScore.ForeColor = Color.Maroon;
                txtHighScore.TextAlign = ContentAlignment.MiddleCenter;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGame(sender, e);
        }

        private void snapButton_Click(object sender, EventArgs e)
        {
            TakeSnapShot(sender, e);
        }
    }
}
