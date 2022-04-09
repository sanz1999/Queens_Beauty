﻿using DatabaseLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingCA.UIHandler
{
    public class ServiceUIHandler
    {
        private static readonly ServiceService uslugaService = new ServiceService();
        private static readonly ServiceCRUDUIHandler uslugaCRUDService = new ServiceCRUDUIHandler();

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
                        uslugaCRUDService.MenuHandler();
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