// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;

string[][] computers = new string[4][];

computers[0] = new string[] { "1", "Acer", "Nitro5", "1000", "12" };
computers[1] = new string[] { "2", "Asus", "Zephyrus", "1700", "8" };
computers[2] = new string[] { "3", "Macbook", "pro14", "2000", "20" };
computers[3] = new string[] { "4", "Lenovo", "Legion5", "1200", "5" };

string[][] Phones = new string[4][];

Phones[0] = new string[] { "1", "Iphone", "pro15", "1000", "30" };
Phones[1] = new string[] { "2", "Samsung", "S23", "800", "15" };
Phones[2] = new string[] { "3", "Xiomi", "note8", "400", "50" };
Phones[3] = new string[] { "4", "Oppo", "x8", "600", "20" };

double balance = 10000;

Menu:
Console.Clear();
Console.WriteLine("1. Show all products\n2. Show computers\n3. Show phones\n4. Add product\n5. Total company price\n6. Sell product\n7. Quit");
string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Clear();
        for (int i = 0; i < computers.Length; i++)
        {
            Console.WriteLine($"ID: {computers[i][0]}");
            Console.WriteLine($"Brand: {computers[i][1]}");
            Console.WriteLine($"Model: {computers[i][2]}");
            Console.WriteLine($"Price: {computers[i][3]}");
            Console.WriteLine($"Quantity: {computers[i][4]}");
            Console.WriteLine("===============");
            Console.WriteLine();
        }
        for (int i = 0; i < Phones.Length; i++)
        {
            Console.WriteLine($"ID: {Phones[i][0]}");
            Console.WriteLine($"Brand: {Phones[i][1]}");
            Console.WriteLine($"Model: {Phones[i][2]}");
            Console.WriteLine($"Price: {Phones[i][3]}");
            Console.WriteLine($"Quantity: {Phones[i][4]}");
            Console.WriteLine("===============");
            Console.WriteLine();
        }
        Console.ReadKey();
        goto Menu;
        break;

    case "2":
        Console.Clear();
        for (int i = 0; i < computers.Length; i++)
        {
            Console.WriteLine($"ID: {computers[i][0]}");
            Console.WriteLine($"Brand: {computers[i][1]}");
            Console.WriteLine($"Model: {computers[i][2]}");
            Console.WriteLine($"Price: {computers[i][3]}");
            Console.WriteLine($"Quantity: {computers[i][4]}");
            Console.WriteLine("===============");
            Console.WriteLine();
        }
        Console.ReadKey();
        goto Menu;
        break;

    case "3":
        Console.Clear();
        for (int i = 0; i < Phones.Length; i++)
        {
            Console.WriteLine($"ID: {Phones[i][0]}");
            Console.WriteLine($"Brand: {Phones[i][1]}");
            Console.WriteLine($"Model: {Phones[i][2]}");
            Console.WriteLine($"Price: {Phones[i][3]}");
            Console.WriteLine($"Quantity: {Phones[i][4]}");
            Console.WriteLine("===============");
            Console.WriteLine();
        }
        Console.ReadKey();
        goto Menu;
        break;

    case "4":
        Console.Clear();
        Console.WriteLine("Enter what product do you want to add:\n1. Computer\n2. Phone");
        string productChoice = Console.ReadLine();
        switch (productChoice)
        {
            case "1":
                Console.Clear();
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();

                Console.Write("Enter Brand: ");
                string brand = Console.ReadLine();

                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                Console.Write("Enter Price: ");
                string price = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                string quantity = Console.ReadLine();

                int newSize = computers.Length + 1;
                Array.Resize(ref computers, newSize);

                computers[newSize - 1] = new string[] { id, brand, model, price, quantity };

                Console.WriteLine("Product added successfully!");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                goto Menu;
                break;
            case "2":
                Console.Clear();
                Console.Write("Enter ID: ");
                string pid = Console.ReadLine();

                Console.Write("Enter Brand: ");
                string pbrand = Console.ReadLine();

                Console.Write("Enter Model: ");
                string pmodel = Console.ReadLine();

                Console.Write("Enter Price: ");
                string pprice = Console.ReadLine();

                Console.Write("Enter Quantity: ");
                string pquantity = Console.ReadLine();

                int pnewSize = Phones.Length + 1;
                Array.Resize(ref Phones, pnewSize);

                Phones[pnewSize - 1] = new string[] { pid, pbrand, pmodel, pprice, pquantity };

                Console.WriteLine("Product added successfully!");
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                goto Menu;
                break;
            default:
                break;
        }

        break;

    case "5":
        Console.Clear();
        double computerPrice = 0;
        for (int i = 0; i < computers.Length; i++)
        {
            computerPrice += Convert.ToDouble(computers[i][3]) * Convert.ToInt32(computers[i][4]);
        }
        double phonePrice = 0;
        for (int i = 0; i < Phones.Length; i++)
        {
            phonePrice += Convert.ToDouble(Phones[i][3]) * Convert.ToInt32(Phones[i][4]);
        }
        Console.Write("Total company price: ");
        Console.WriteLine(phonePrice + computerPrice);
        Console.ReadKey();
        goto Menu;
        break;

    case "6":
        Console.Clear();
        Console.WriteLine("Select category:");
        Console.WriteLine("1. Computers");
        Console.WriteLine("2. Phones");
        string categoryChoice = Console.ReadLine();

        string[][] selectedCategory = null;

        switch (categoryChoice)
        {
            case "1":
                selectedCategory = computers;
                break;
            case "2":
                selectedCategory = Phones;
                break;
            default:
                Console.WriteLine("Invalid category selected.");
                Console.ReadKey();
                goto Menu;
        }

        Console.Write("Enter the model name you want to sell: ");
        string sellModel = Console.ReadLine();

        int productIndex = -1;

        for (int i = 0; i < selectedCategory.Length; i++)
        {
            if (selectedCategory[i][2].Equals(sellModel, StringComparison.OrdinalIgnoreCase))
            {
                productIndex = i;
                break;
            }
        }

        if (productIndex != -1)
        {
            Console.Write($"Enter the quantity to sell (Available: {selectedCategory[productIndex][4]}): ");
            int quantityToSell = int.Parse(Console.ReadLine());

            int availableQuantity = int.Parse(selectedCategory[productIndex][4]);

            if (quantityToSell <= availableQuantity)
            {
                selectedCategory[productIndex][4] = (availableQuantity - quantityToSell).ToString();
                Console.WriteLine("Product sold successfully!");
            }
            else
            {
                Console.WriteLine("Insufficient stock for the requested quantity.");
            }
        }
        else
        {
            Console.WriteLine("Model not found in the selected category.");
        }

        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
        goto Menu;
        break;

    case "7":
        Console.Clear();
        Console.WriteLine("Exiting...");
        break;

    default:
        Console.WriteLine("Invalid choice, please try again.");
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
        goto Menu;
        break;
}


















//    case "2":
//        Console.Clear();
//        Console.Write("Enter ID: ");
//        string id = Console.ReadLine();

//        Console.Write("Enter Name: ");
//        string name = Console.ReadLine();

//        Console.Write("Enter Surname: ");
//        string surname = Console.ReadLine();

//        Console.Write("Enter Phone: ");
//        string phone = Console.ReadLine();

//        int newSize = phonebook.Length + 1;
//        Array.Resize(ref phonebook, newSize);

//        phonebook[newSize - 1] = new string[] { id, name, surname, phone };

//        Console.WriteLine("Contact added successfully!");
//        Console.WriteLine("Press any key to return to menu...");
//        Console.ReadKey();
//        goto Menu;
//        break;
//    case "3":
//        Console.Clear();
//        Console.Write("Select ID which you want edit: ");
//        string editID = Console.ReadLine();
//        int index = -1;

//        for (int i = 0; i < phonebook.Length; i++)
//        {
//            if (phonebook[i][0] == editID)
//            {
//                index = i; break;
//            }
//        }
//        if (index != -1)
//        {
//            Console.Clear();
//            Console.WriteLine("What do you want to edit\n1.Name\n2.Surname\n3.Phone");
//            string editChoice = Console.ReadLine();

//            switch (editChoice)
//            {
//                case "1":
//                    Console.Clear();
//                    Console.Write("Enter new name: ");
//                    phonebook[index][1] = Console.ReadLine();
//                    Console.WriteLine("name updated");
//                    Console.ReadKey();
//                    goto Menu;
//                    break;
//                case "2":
//                    Console.Clear();
//                    Console.Write("Enter new Surname: ");
//                    phonebook[index][2] = Console.ReadLine();
//                    Console.WriteLine("surname updated");
//                    Console.ReadKey();
//                    goto Menu;
//                    break;
//                case "3":
//                    Console.Clear();
//                    Console.Write("Enter new Phone number: ");
//                    phonebook[index][3] = Console.ReadLine();
//                    Console.WriteLine("Phone number updated");
//                    Console.ReadKey();
//                    goto Menu;
//                    break;
//                default:
//                    break;
//            }
//        }
//        else
//        {
//            Console.WriteLine("It is not valid ID");
//        }
//        break;
//    case "4":
//        Console.Clear();
//        Console.Write("select contact ID which you want delete: ");
//        string deleteID = Console.ReadLine();
//        int deleteIndex = -1;
//        for (int i = 0; i < phonebook.Length; i++)

//        {
//            if (phonebook[i][0] == deleteID)
//            {
//                deleteIndex = i; break;
//            }
//        }
//        if (deleteIndex != -1)
//        {
//            for (int i = deleteIndex; i < phonebook.Length - 1; i++)
//            {
//                phonebook[i] = phonebook[i + 1];
//            }
//            Array.Resize(ref phonebook, phonebook.Length - 1);
//            Console.WriteLine("Contact deleted successfully!");
//        }
//        else
//        {
//            Console.WriteLine("Not valid ID");
//        }
//        Console.ReadKey();
//        goto Menu;
//        break;
//    case "5":
//        Console.Clear();
//        Console.WriteLine("Search by:\n1.name\n2.surname\n3.phone");
//        string searchChoice = Console.ReadLine();
//        bool phonefound = false;

//        switch (searchChoice)
//        {
//            case "1":
//                Console.Clear();
//                Console.Write("enter the name: ");
//                string nameChoice = Console.ReadLine();
//                for (int i = 0; i < phonebook.Length; i++)
//                {
//                    if (phonebook[i][1].Equals(nameChoice, StringComparison.OrdinalIgnoreCase))
//                    {
//                        Console.WriteLine($"ID: {phonebook[i][0]}");
//                        Console.WriteLine($"Name: {phonebook[i][1]}");
//                        Console.WriteLine($"Surname: {phonebook[i][2]}");
//                        Console.WriteLine($"Phone: {phonebook[i][3]}");
//                        Console.WriteLine();
//                        phonefound = true;
//                    }
//                }
//                if (!phonefound)
//                {
//                    Console.WriteLine("no contact found with that name");
//                }
//                Console.ReadKey();
//                goto Menu;
//                break;


//            case "2":
//                Console.Clear();
//                Console.Write("enter the name: ");
//                string surnameChoice = Console.ReadLine();
//                for (int i = 0; i < phonebook.Length; i++)
//                {
//                    if (phonebook[i][1].Equals(surnameChoice, StringComparison.OrdinalIgnoreCase))
//                    {
//                        Console.WriteLine($"ID: {phonebook[i][0]}");
//                        Console.WriteLine($"Name: {phonebook[i][1]}");
//                        Console.WriteLine($"Surname: {phonebook[i][2]}");
//                        Console.WriteLine($"Phone: {phonebook[i][3]}");
//                        Console.WriteLine();
//                        phonefound = true;
//                    }
//                }
//                if (!phonefound)
//                {
//                    Console.WriteLine("no contact found with that name");
//                }
//                Console.ReadKey();
//                goto Menu;
//                break;

//            case "3":
//                Console.Clear();
//                Console.Write("enter the name: ");
//                string phoneChoice = Console.ReadLine();
//                for (int i = 0; i < phonebook.Length; i++)
//                {
//                    if (phonebook[i][1].Equals(phoneChoice, StringComparison.OrdinalIgnoreCase))
//                    {
//                        Console.WriteLine($"ID: {phonebook[i][0]}");
//                        Console.WriteLine($"Name: {phonebook[i][1]}");
//                        Console.WriteLine($"Surname: {phonebook[i][2]}");
//                        Console.WriteLine($"Phone: {phonebook[i][3]}");
//                        Console.WriteLine();
//                        phonefound = true;
//                    }
//                }
//                if (!phonefound)
//                {
//                    Console.WriteLine("no contact found with that name");
//                }
//                Console.ReadKey();
//                goto Menu;
//                break;
//            default:
//                break;
//        }
//        break;
//    case "6":
//        break;
//    default:
//        break;
//}

