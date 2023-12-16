using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Service;

namespace Laboratorna_3.Options.Accounts
{
    // Стандартний акаунт, успадкований від класу GameAccount
    class StandartAccount : Account
    {
        // Конструктор класу StandartAccount, викликає конструктор базового класу з переданим ім'ям користувача
        public StandartAccount(string userName, AccountService service, int ID) : base(userName, service, ID) { }

        // Перевизначений віртуальний метод для розрахунку рейтингу
        public override int RatingCalc(int rating)
        {
            return rating;
        }
    }
}
