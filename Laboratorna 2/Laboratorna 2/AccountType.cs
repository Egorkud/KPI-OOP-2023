using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorna_2
{
    // Стандартний акаунт, успадкований від класу GameAccount
    class StandartAccount : Account
    {
        // Конструктор класу StandartAccount, викликає конструктор базового класу з переданим ім'ям користувача
        public StandartAccount(string userName) : base(userName) { }

        // Перевизначений віртуальний метод для розрахунку рейтингу
        public override int RatingCalc(int rating)
        {
            return rating;
        }
    }

    // Акаунт зі зменшеним розрахунком, успадкований від класу GameAccount
    class HalfAccount : Account
    {
        // Конструктор класу HalfAccount
        public HalfAccount(string userName) : base(userName) { }
        // Перевизначений вірт. метод для розрахунку рейтингу (зменшує отриманий рейтинг вдвічі при програші)
        public override int RatingCalc(int rating)
        {
            return rating / 2;
        }
    }

    // Акаунт із подвоєнним розрахунком, успадкований від класу GameAccount
    class DoubleAccount : Account
    {
        // Конструктор класу DoubleAccount
        public DoubleAccount(string userName) : base(userName) { }
        public override int RatingCalc(int rating)
        {
            return rating * 2;
        }
    }
}
