using System;
using System.Windows.Forms;

namespace RockPaperScissor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button[] choices = { rock, paper, scissor };
            for (int i = 0; i < choices.Length; i++)
            {
                int index = i; // Capture the current value of i

                choices[index].Click += (sender, e) =>
                {
                    string playerChoice = choices[index].Text;
                    string botChoice = Randomize();
                    Game(playerChoice, botChoice);
                };
            }
        }

        private static string Randomize()
        {
            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();
            int choiceIndex = random.Next(choices.Length);
            return choices[choiceIndex];
        }

        private void DisplayResult(string result)
        {
            info.Text = result;
        }

        private void Game(string playerChoice, string botChoice)
        {
            BotChoiceL.Text = "The Bot chose: " + botChoice;

            if (playerChoice == botChoice)
            {
                DisplayResult("It's a Tie");
            }
            else if ((playerChoice == "Rock" && botChoice == "Scissors") ||
                     (playerChoice == "Paper" && botChoice == "Rock") ||
                     (playerChoice == "Scissors" && botChoice == "Paper"))
            {
                int playerCurrentScore = Convert.ToInt32(playerScore.Text);
                playerScore.Text = Convert.ToString(++playerCurrentScore);
                DisplayResult("Player Won!");
            }
            else
            {
                int botCurrentScore = Convert.ToInt32(botScore.Text);
                botScore.Text = Convert.ToString(++botCurrentScore);
                DisplayResult("Bot Won!");
            }
        }

    }
}
