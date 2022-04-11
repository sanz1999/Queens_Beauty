using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class TestingUIHandler
    {
        private static readonly AppointmentUIHandler appointmentUI = new AppointmentUIHandler();
        private static readonly CustomerUIHandler customerUI = new CustomerUIHandler();
        private static readonly ServiceUIHandler serviceUI = new ServiceUIHandler();
        private static readonly SIAUIHandler siaUI = new SIAUIHandler();
        private static readonly WorkerUIHandler workerUI = new WorkerUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine("\nZa izlazak uneti x\nOdabir tabele za testiranje:");
                Console.WriteLine("1. Appointment Testing");
                Console.WriteLine("2. Customer Testing");
                Console.WriteLine("3. Service Testing");
                Console.WriteLine("4. SIA (services in a appointment) Testing");
                Console.WriteLine("5. Worker Testing");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        appointmentUI.MenuHandler();
                        break;
                    case "2":
                        customerUI.MenuHandler();
                        break;
                    case "3":
                        serviceUI.MenuHandler();
                        break;
                    case "4":
                        siaUI.MenuHandler();
                        break;
                    case "5":
                        workerUI.MenuHandler();
                        break;
                    case "x":
                        return;
                }

            } while (true);
        }

    }
}
