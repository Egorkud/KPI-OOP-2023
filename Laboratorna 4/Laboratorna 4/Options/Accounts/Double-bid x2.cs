using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.DB.Service;

namespace Laboratorna_4.Options.Accounts
{
    // Акаунт із подвоєнним розрахунком, успадкований від класу GameAccount
    class DoubleAccount : Account
    {
        // Конструктор класу DoubleAccount
        public DoubleAccount(string userName, AccountService service, int ID) : base(userName, service, ID) { }
        public override int RatingCalc(int rating)
        {
            return rating * 2;
        }
    }
}
