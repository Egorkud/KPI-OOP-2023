// Створюємо видиму область для класів гри
namespace Laboratorna
{
    // Створюю перший клас, обліковий запис гравця (Головна умова)
    class GameAccount
    {
        // Властивості класу (Є головними умовами завдання)
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        public int GamesCount { get; set; }
        public List<GameResult> GameResults { get; set; } = new List<GameResult>();

        // Методи класу
        // Викликається у випадку перемоги (Головна умова)
        public void WinGame(int rating, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            CurrentRating += rating;
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        // Викликається у випадку поразки (Головна умова)
        public void LoseGame(int rating, string player1, string player2, string winner, int gameIndex)
        {
            GamesCount++;
            CurrentRating -= rating;
            if (CurrentRating < 1)
            {
                CurrentRating = 1;
            }
            GameResults.Add(new GameResult(player1, player2, winner, rating, gameIndex));
        }
        // Історія ігор (Головна умова)
        public void GetStats()
        {
            foreach (GameResult result in GameResults)
            {
                Console.WriteLine($"{result.Player} VS {result.Opponent}, Player {result.Winner} won, played for {result.Rating} rating, Game index №{result.GameIndex + 1}");
            }
        }
        // Друк результату
        public void OutPlayers()
        {
            Console.WriteLine($"\nPlayer name: {UserName}\nRating: {CurrentRating} \nRounds payed: {GamesCount}\n");
        }

    }

    class Program
    {
        static void Main() //Головний метод програми
        {
            // Змінні для введення користувачем та оцінювання гри
            string answer;
            int rating;

            // Створення об'єкту гравця 1
            GameAccount Player1 = new();
            Console.WriteLine("Input the name of the first player: ");
            Player1.UserName = Console.ReadLine();
            Player1.CurrentRating = 150;

            // Створення об'єкту гравця 2
            GameAccount Player2 = new();
            Console.WriteLine("Input the name of the second player: ");
            Player2.UserName = Console.ReadLine();
            Player2.CurrentRating = 150;

            // Виведення інформації про гравців
            Player1.OutPlayers();
            Player2.OutPlayers();

            // Цикл гри безпосередньо
            do
            {
                // Введення користувачем оцінювання гри
                Console.WriteLine("Input the bid of the rating you are playing for:");
                rating = int.Parse(Console.ReadLine());

                // Перевірка на допустимість оцінювання гри
                while (rating <= 0)
                {
                    Console.WriteLine("Rating cannot be less than 0");
                    rating = int.Parse(Console.ReadLine());
                }

                // Створення об'єкту гри та проведення гри між гравцями
                Game game = new();
                game.PlayGame(Player1, Player2, rating);


                // Питання про продовження гри, та можливість продовжити
                Console.WriteLine("Retry? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");

            // Виведення статистики гравця 1 після завершення ігор
            Player1.GetStats();

            // Повторне виведення інформації про гравців
            Player1.OutPlayers();
            Player2.OutPlayers();
        }
    }

    class Game // Клас, який редставляє гру
    {
        // Метод проведення гри між двома гравцями
        public void PlayGame(GameAccount player1, GameAccount player2, int rating)
        {

            // Створення екземпляру класу Random для випадкового вибору переможця
            Random random = new();

            // Визначення ініційних значень переможця та індексу гри
            string winner = player1.UserName;
            int gameIndex = player1.GamesCount;

            // Випадковий вибір, який гравець перемагає
            int coin = random.Next(1, 3);

            // Cтворив логіку гри в залежності від випадкового вибору
            if (coin == 1)
            {
                winner = player1.UserName;
                Console.WriteLine("Player 1 won");
                player1.WinGame(rating, player1.UserName, player2.UserName, winner, gameIndex);
                Console.WriteLine("Player 2 lost");
                player2.LoseGame(rating, player2.UserName, player1.UserName, winner, gameIndex);
            }

            if (coin == 2)
            {
                winner = player2.UserName;
                Console.WriteLine("Player 2 won");
                player2.WinGame(rating, player2.UserName, player1.UserName, winner, gameIndex);
                Console.WriteLine("Player 1 lost");
                player1.LoseGame(rating, player1.UserName, player2.UserName, winner, gameIndex);
            }
        }
    }

    // Клас, що представиляє результат гри (Головна умова)
    class GameResult
    {

        // Друк результату ігор
        public string Player { get; }
        public string Opponent { get; }
        public string Winner { get; }
        public int Rating { get; }
        public int GameIndex { get; }

        // Ініціалізація з переданими параметрами
        public GameResult(string player, string opponent, string winner, int rating, int gameIndex)
        {
            Player = player;
            Opponent = opponent;
            Winner = winner;
            Rating = rating;
            GameIndex = gameIndex;
        }
    }
}