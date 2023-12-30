using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorna_4.UI.Base;

namespace Laboratorna_4.UI
{
    internal class ProgrammeTermination : IUserInterface
    {
        // Даний клас необхіден для того, щоб коректно реалізувати роботу через масив,
        // оскільки при виборі останньої цифри необхідно буде потрапити в елемент масиву,
        // який має існувати, щоб запобігти помилці
        public void Execute()
        {
            // Повідомлення про завершення роботи програми
            Console.WriteLine("\nProgram code ended with 0");
        }
    }
}
