using System;

class MitarbeiterVerwaltung
{
    static string[] names;
    static int[] ages;
    static string[] departments;

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Mitarbeiter hinzufügen");
            Console.WriteLine("2. Mitarbeiter Anzeigen");
            Console.WriteLine("3. Mitarbeiter Suchen");
            Console.WriteLine("4. Mitarbeiter nach Abteilung Sortieren");
            Console.WriteLine("5. Program Verlassen");
            Console.Write("Option auswählen: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddEmployees();
                    break;
                case "2":
                    ShowEmployees();
                    break;
                case "3":
                    SearchEmployee();
                    break;
                case "4":
                    SortAndShowEmployees();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }

    static void AddEmployees()
    {
        int numberOfEmployees = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("Wie viel Mitarbeiter möchten Sie hinzufügen");
            validInput = int.TryParse(Console.ReadLine(), out numberOfEmployees) && numberOfEmployees > 0;

            if (!validInput)
            {
                Console.WriteLine("Bitte eine gülte Anzahl an Mitarbeitern angeben.");
            }
        }

        names = new string[numberOfEmployees];
        ages = new int[numberOfEmployees];
        departments = new string[numberOfEmployees];

        for (int i = 0; i < numberOfEmployees; i++)
        {
            Console.WriteLine($"Bitte den Namen von Mitarbeiter {i + 1} eingeben:");
            names[i] = Console.ReadLine();

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine($"Bitte das Alter von Mitarbeiter {i + 1} eingeben:");
                validInput = int.TryParse(Console.ReadLine(), out int enteredAge) && enteredAge > 0;

                if (validInput)
                {
                    ages[i] = enteredAge;
                }
                else
                {
                    Console.WriteLine("Bitte ein gültiges Alter eingeben.");
                }
            }

            Console.WriteLine($"Bitte Abteilung von Mitarbeiter {i + 1} eingeben:");
            departments[i] = Console.ReadLine();
        }

        Console.WriteLine("\nMitarbeiter erfolgreich hinzugefügt");
    }

    static void ShowEmployees()
    {
        if (names == null)
        {
            Console.WriteLine("Es wurden noch keine Mitarbeiter angelegt.");
            return;
        }

        Console.WriteLine("\nListe Aller Mitarbeiter:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"Name: {names[i]}, Alter: {ages[i]}, Abteilung: {departments[i]}");
        }
    }

    static void SearchEmployee()
    {
        if (names == null)
        {
            Console.WriteLine("Es wurden noch keine Mitarbeiter angelegt.");
            return;
        }

        Console.WriteLine("Geben Sie den Namen des Mitarbeiters ein, den Sie suchen:");
        string searchedName = Console.ReadLine();
        bool found = false;

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Equals(searchedName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Mitarbeiter gefunden: Name: {names[i]}, Alter: {ages[i]}, Abteilung: {departments[i]}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Mitarbeiter nicht gefunden");
        }
    }

    static void SortAndShowEmployees()
    {
        if (names == null)
        {
            Console.WriteLine("Es wurden noch keine Mitarbeiter angelegt.");
            return;
        }

        for (int i = 0; i < departments.Length - 1; i++)
        {
            for (int j = 0; j < departments.Length - i - 1; j++)
            {
                if (String.Compare(departments[j], departments[j + 1]) > 0)
                {
                    Swap(j, j + 1);
                }
            }
        }

        ShowEmployees();
    }
    static void Swap(int index1, int index2)
    {
        // Tausche Namen
        string tempName = names[index1];
        names[index1] = names[index2];
        names[index2] = tempName;

        // Tausche Alter
        int tempage = ages[index1];
        ages[index1] = ages[index2];
        ages[index2] = tempage;

        // Tausche Abteilungen
        string tempDepartment = departments[index1];
        departments[index1] = departments[index2];
        departments[index2] = tempDepartment;
    }
}
