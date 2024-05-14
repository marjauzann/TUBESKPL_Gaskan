using Main_Sendit.View.Pengguna;
using System;
using System.Collections.Generic;

class Program
{
    static List<User> users = new List<User>();
    static List<Order> orders = new List<Order>();
    static User currentUser;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Register();
                    BookingPage bok
                        = new BookingPage();
                    
                    break;
                case 2:
                    Login();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Check user credentials
        foreach (User user in users)
        {
            if (user.Username == username && user.Password == password)
            {
                currentUser = user;
                Console.WriteLine("Login successful!");
                if (currentUser.Role == Role.Sender)
                {
                    SenderMenu();
                }
                else if (currentUser.Role == Role.Courier)
                {
                    CourierMenu();
                }
                return;
            }
        }
        Console.WriteLine("Invalid username or password.");
    }

    static void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        Console.Write("Enter role (Sender/Courier): ");
        Role role = (Role)Enum.Parse(typeof(Role), Console.ReadLine());

        users.Add(new User { Username = username, Password = password, Role = role });
        Console.WriteLine("Registration successful!");
    }

    static void SenderMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Send package");
            Console.WriteLine("2. View orders");
            Console.WriteLine("3. Logout");
            Console.Write("Choose option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    SendPackage();
                    break;
                case 2:
                    ViewOrders();
                    break;
                case 3:
                    currentUser = null;
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void SendPackage()
    {
        Console.WriteLine("Enter sender details:");
        Console.Write("Name: ");
        string senderName = Console.ReadLine();
        Console.Write("Address: ");
        string senderAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string senderPhone = Console.ReadLine();

        Console.WriteLine("Enter recipient details:");
        Console.Write("Name: ");
        string recipientName = Console.ReadLine();
        Console.Write("Address: ");
        string recipientAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string recipientPhone = Console.ReadLine();

        Console.Write("Enter package details:");
        Console.Write("Type: ");
        string packageType = Console.ReadLine();
        Console.Write("Weight (kg): ");
        double packageWeight = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter distance (km): ");
        double distance = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose payment method:");
        Console.WriteLine("1. Bank transfer");
        Console.WriteLine("2. QRIS");
        int paymentOption = Convert.ToInt32(Console.ReadLine());

        bool isPaid = false;
        if (paymentOption == 1 || paymentOption == 2)
        {
            double price = distance * 5000;

            Console.WriteLine($"Price: {price}");

            Console.WriteLine("1. Paid");
            Console.WriteLine("2. Not Paid");
            int paidOption = Convert.ToInt32(Console.ReadLine());
            isPaid = paidOption == 1;

            Order newOrder = new Order
            {
                Sender = currentUser,
                SenderName = senderName,
                SenderAddress = senderAddress,
                SenderPhone = senderPhone,
                RecipientName = recipientName,
                RecipientAddress = recipientAddress,
                RecipientPhone = recipientPhone,
                PackageType = packageType,
                PackageWeight = packageWeight,
                Distance = distance,
                Price = price,
                IsPaid = isPaid,
                Status = "Pending"
            };
            orders.Add(newOrder);

            Console.WriteLine("Order placed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid payment option.");
        }
    }

    static void ViewOrders()
    {
        Console.WriteLine("Your orders:");
        foreach (Order order in orders)
        {
            if (order.Sender.Username == currentUser.Username)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }

    static void CourierMenu()
    {
        while (true)
        {
            Console.WriteLine("1. My orders");
            Console.WriteLine("2. Logout");
            Console.Write("Choose option: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ViewCourierOrders();
                    break;
                case 2:
                    currentUser = null;
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void ViewCourierOrders()
    {
        Console.WriteLine("Your orders:");
        foreach (Order order in orders)
        {
            if (order.Status != "Delivered")
            {
                Console.WriteLine(order.ToString());
                Console.Write("Update order status (Picked up/Delivering/Delivered): ");
                string status = Console.ReadLine();
                order.Status = status;
                Console.WriteLine("Order status updated successfully!");
                return;
            }
        }
        Console.WriteLine("No pending orders.");
    }
}

enum Role
{
    Sender,
    Courier
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}

class Order
{
    public User Sender { get; set; }
    public string SenderName { get; set; }
    public string SenderAddress { get; set; }
    public string SenderPhone { get; set; }
    public string RecipientName { get; set; }
    public string RecipientAddress { get; set; }
    public string RecipientPhone { get; set; }
    public string PackageType { get; set; }
    public double PackageWeight { get; set; }
    public double Distance { get; set; }
    public double Price { get; set; }
    public bool IsPaid { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Sender: {SenderName}, Recipient: {RecipientName}, Distance: {Distance} km, Price: {Price}, Status: {Status}";
    }
}