using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class AppointmentUIHandler
    {
        private static readonly AppointmentService appointmentService = new AppointmentService();
        private static readonly AppointmentCRUDUIHandler appointmentCRUDUIHandler = new AppointmentCRUDUIHandler();
        public void MenuHandler()
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("\nZa povratak na main menu uneti x\nOpcije:");
                Console.WriteLine("1. CRUD TestMenu");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        appointmentCRUDUIHandler.MenuHandler();
                        continue;
                    case "x":
                        return;
                }
                Console.WriteLine("\n\n\nPress any key to contionue...");
                Console.ReadKey();

            } while (true);
        }
    }
}
