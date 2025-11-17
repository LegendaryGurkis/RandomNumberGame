using System.Diagnostics;

namespace RandomNumberGame
{
    public partial class MainPage : ContentPage
    {
        private int randomNumber;
        private int numberOfGuesses;
        private int score = 0;
        public MainPage()
        {
            InitializeComponent();

            
        }


        void OnDificultyChanged(object? sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            if (selectedIndex == -1)
            {

            }
            else if (selectedIndex != -1)
            {
                if (selectedIndex == 0)
                {
                    Random random = new Random();
                    randomNumber = random.Next(1, 10);
                    Debug.WriteLine(randomNumber);
                    GuessNumber.IsEnabled = true;
                    GuessNumber.IsVisible = true;

                }
                else if (selectedIndex == 1)
                {
                    Random random = new Random();
                    randomNumber = random.Next(1, 100);
                    Debug.WriteLine(randomNumber);
                    GuessNumber.IsEnabled = true;
                    GuessNumber.IsVisible = true;

                }
                else if (selectedIndex == 2)
                {
                    Random random = new Random();
                    randomNumber = random.Next(1, 1000);
                    Debug.WriteLine(randomNumber);
                    GuessNumber.IsEnabled = true;
                    GuessNumber.IsVisible = true;

                }
            }
        }

        private void UserGuess(object? sender, EventArgs e)
        {
            //Debug.WriteLine(computerRandom);

            //Random random = new Random();
            //int pelle = random.Next(1, 10);
            //det här gör en ny random varje gång man trycker på knapen
            if(int.TryParse(UserInputEntry.Text, out int userInput))
            //Jag lyckas inte få den att använda numret jag genererade när jag valde svårighetsgrad.
            {
                Debug.WriteLine("Ett heltal: " + userInput);
                // här jämför vi användarens heltal med det slumpade
                if(randomNumber == userInput)
                {
                    Debug.WriteLine("det är korrekt wow");
                    score++;
                    Debug.WriteLine(score);
                    numberOfGuesses++;
                    NewGame.IsVisible = true;
                    NewGame.IsEnabled = true;
                    right_choice_picture.IsVisible = true;
                    wrong_choice_picture.IsVisible = false;
                    GuessNumber.IsEnabled = false;
                    GuessNumber.IsVisible = false;

                }
                else if (userInput < randomNumber)
                {
                    Debug.WriteLine("talet var för litet");
                    numberOfGuesses++;
                    Debug.WriteLine(numberOfGuesses);
                    wrong_choice_picture.IsVisible = true;
                    right_choice_picture.IsVisible = false;
                    GuessNumber.IsEnabled = true;
                    GuessNumber.IsVisible = true;
                }
                else
                {
                    Debug.WriteLine("talet var för stort");
                    numberOfGuesses++;
                    Debug.WriteLine(numberOfGuesses);
                    wrong_choice_picture.IsVisible = true;
                    right_choice_picture.IsVisible = false;
                    GuessNumber.IsEnabled = true;
                    GuessNumber.IsVisible = true;
                }
            }
            else
            {
                Debug.WriteLine("Inte ett heltal över 0: " + userInput);
            }
        }
            private void MakeMeWork(object sender, EventArgs e)
            {
                //Name.IsEnabled = true; (Knapen vars namn du använde syns)
            }

            private void UserNewGame(object? sender, EventArgs e) //UserNewGame refererar till när jag trycker knapen.
            //Jag kunde dock inte döpa klassen till NewGame vilket är namnet av knapen.
            //Jag vill att min knap ska sluta fungera när jag inte klarat spelet, och fungera när jag har klarat det.
            {
            NewGame.IsVisible = false;
            NewGame.IsEnabled = false;
            GuessNumber.IsEnabled = true;
            GuessNumber.IsVisible = true;
        }

        //private void UserNewGame(object? sender, EventArgs e)
        //{
        //int startaOm = 0;
        //slumpa ett nytt tal utifrån vilken svårighetsgrad du valde med pickern.
        //}

    }
}