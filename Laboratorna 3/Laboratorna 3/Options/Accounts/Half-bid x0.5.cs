using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_3.DB.Service;

namespace Laboratorna_3.Options.Accounts
{
    // Акаунт зі зменшеним розрахунком, успадкований від класу GameAccount
    class HalfAccount : Account
    {
        // Конструктор класу HalfAccount
        public HalfAccount(string userName, AccountService service, int ID) : base(userName, service, ID) { }

        // Перевизначений вірт. метод для розрахунку рейтингу (зменшує отриманий рейтинг вдвічі при програші)
        public override int RatingCalc(int rating)
        {
            return rating / 2;
        }
    }
}
