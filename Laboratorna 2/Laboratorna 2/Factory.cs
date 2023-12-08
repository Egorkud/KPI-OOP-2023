﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    // Клас GameFactory відповідає за створення різних типів гри, відповідно до завдання
    internal class GameFactory
    {
        // Метод для створення Standart mode
        public Game GameStandart(Account player1, Account player2)
        {
            return new StandartGame(player1, player2);
        }
        // Метод для створення гри типу Safe mode
        public Game GameSafemode(Account player1, Account player2)
        {
            return new SafeGame(player1, player2);
        }
        // Метод для створення гри типу Lucky Try
        public Game GameLuckyTry(Account player1, Account player2)
        {
            return new LuckyTry(player1, player2);
        }

    }
}
