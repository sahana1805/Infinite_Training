using System;
using System.Data.SqlClient;
using System.Data;

namespace Railway
{
    class Program
    {
        private static string connectionString = "Data Source=ICS-LT-D2YLV44\\SQLEXPRESS;Database=RailwayDB;Trusted_Connection=True;";
        public static void AdminLogin() //Admin Login
        {
            Console.WriteLine("-----------");
            Console.WriteLine("ADMIN LOGIN");
            Console.WriteLine("-----------");
            Console.Write("Enter Admin ID: ");
            string adminID = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "SELECT AdminID FROM Admins WHERE AdminID = @AdminID AND Password = @Password";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AdminID", adminID);
                        cmd.Parameters.AddWithValue("@Password", password);
                        conn.Open();

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            adminID = (string)result;
                            Console.WriteLine($"Login successful!");
                            AdminOptions();
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, please try again");
                            AdminLogin();
                        }
                    }
                }
            }

            catch (SqlException)
            {
                Console.WriteLine("Unable to connect to the database, please try again");
            }
        }

        public static void AdminOptions()
        {
            int adminchoice;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Admin Options: Please enter from 1-4");
            Console.WriteLine("1. Add trains");
            Console.WriteLine("2. Modify trains");
            Console.WriteLine("3. Delete trains");
            Console.WriteLine("4. Exit");
            Console.WriteLine("------------------------------------");

            adminchoice = Convert.ToInt32(Console.ReadLine());
            if (adminchoice == 1)
            {
                AddTrains();
            }
            else if (adminchoice == 2)
            {
                ModifyTrains();
            }
            else if (adminchoice == 3)
            {
                DeleteTrains();
            }
            else
            {
                Console.WriteLine("Exiting the program");
                Console.WriteLine();
                Program.Main(new string[0]);
            }
        }

        public static void AddTrains() //Function to Add Trains
        {
            Console.WriteLine("-------------");
            Console.WriteLine("ADD NEW TRAIN");
            Console.WriteLine("-------------");
            Console.Write("Enter Train Number: ");
            int trainNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter Origin: ");
            string origin = Console.ReadLine();
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter Status (Active/Inactive): ");
            string status = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("AddTrain", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@Origin", origin);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.ExecuteNonQuery();
                }

                // Add classes for the train
                AddTrainClass(trainNo);
                Console.WriteLine("Train added successfully!");

                Console.WriteLine();

                Console.WriteLine("----------");
                Console.WriteLine("ALL TRAINS");
                Console.WriteLine("----------");
                string query = "SELECT t.*, tc.ClassType, tc.TotalBerths, tc.AvailableBerths FROM Trains t, TrainClass tc WHERE t.TrainNo = tc.TrainNo";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}, IsDeleted: {reader["IsDeleted"]}, ClassType: {reader["ClassType"]}, TotalBerths: {reader["TotalBerths"]}, AvailableBerths: {reader["AvailableBerths"]}");
                            Console.WriteLine();
                        }
                    }
                }
            }

            Console.WriteLine();
            AdminOptions();
        }

        public static void AddTrainClass(int trainNo) //Function to Add Class Types
        {
            string[] classTypes = { "First", "Second", "Sleeper" };
            foreach (string classType in classTypes)
            {
                Console.Write($"Enter total berths for {classType} class: ");
                int totalBerths = Convert.ToInt32(Console.ReadLine());

                Console.Write($"Enter available berths for {classType} class: ");
                int availableBerths = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("AddTrainClass", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        {
                            cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                            cmd.Parameters.AddWithValue("@ClassType", classType);
                            cmd.Parameters.AddWithValue("@TotalBerths", totalBerths);
                            cmd.Parameters.AddWithValue("@AvailableBerths", availableBerths);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static void ModifyTrains() //Function to Modify Trains
        {
            Console.WriteLine("------------");
            Console.WriteLine("MODIFY TRAIN");
            Console.WriteLine("------------");
            Console.WriteLine("TRAIN LIST");
            string query1 = "SELECT * FROM Trains";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}, IsDeleted: {reader["IsDeleted"]}");
                            Console.WriteLine();
                        }
                    }
                }

                Console.Write("Enter Train Number: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Do you want to modify Train/Train Class?: ");
                string choice = Console.ReadLine();

                if (choice == "Train")
                {
                    Console.Write("Enter the column to modify (TrainNo/TrainName/Origin/Destination/Status): ");
                    string attribute = Console.ReadLine();
                    if (attribute == "TrainNo")
                    {
                        Console.Write("Enter the new value: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        string query2 = "UPDATE Trains SET " + attribute + "=" + value.ToString() + " WHERE TrainNo =" + trainNo.ToString();
                        using (SqlCommand cmd = new SqlCommand(query2, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Value updated!");
                    }
                    else
                    {
                        Console.Write("Enter the new value: ");
                        string value = Console.ReadLine();
                        string query3 = "UPDATE Trains SET " + attribute + "='" + value + "' WHERE TrainNo =" + trainNo.ToString();
                        using (SqlCommand cmd = new SqlCommand(query3, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Value updated!");
                    }
                }
                else
                {
                    string query4 = "SELECT * FROM TrainClass WHERE TrainNo =" + trainNo.ToString();
                    using (SqlCommand cmd = new SqlCommand(query4, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"Class ID: {reader["ClassID"]}, Train Number: {reader["TrainNo"]}, Class Type: {reader["ClassType"]}, Total Berths: {reader["TotalBerths"]}, Available Berths: {reader["AvailableBerths"]}");
                                Console.WriteLine();
                            }
                        }
                    }

                    Console.Write("Enter Class ID: ");
                    int classID = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the column to modify (ClassType/TotalBerths/AvailableBerths): ");
                    string attribute = Console.ReadLine();
                    if (attribute == "ClassType")
                    {
                        Console.Write("Enter the new value: ");
                        string value = Console.ReadLine();
                        string query5 = "UPDATE TrainClass SET " + attribute + "='" + value + "' WHERE ClassID =" + classID.ToString();
                        using (SqlCommand cmd = new SqlCommand(query5, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Value updated!");
                    }
                    else
                    {
                        Console.Write("Enter the new value: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        string query6 = "UPDATE TrainClass SET " + attribute + "=" + value.ToString() + " WHERE ClassID =" + classID.ToString();
                        using (SqlCommand cmd = new SqlCommand(query6, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        Console.WriteLine("Value updated!");
                    }
                }

                Console.WriteLine();
                AdminOptions();
            }
        }

        public static void DeleteTrains() //Function to Delete Trains
        {
            Console.WriteLine("------------");
            Console.WriteLine("DELETE TRAIN");
            Console.WriteLine("------------");
            Console.WriteLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query1 = "SELECT * FROM Trains WHERE IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}");
                            Console.WriteLine();
                        }
                    }
                }

                Console.Write("Enter Train Number: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                string query2 = "UPDATE Trains SET IsDeleted = 1, Status = 'Inactive' WHERE TrainNo =" + trainNo.ToString();
                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Train (soft) deleted!");
                Console.WriteLine();

                Console.WriteLine("----------");
                Console.WriteLine("ALL TRAINS");
                Console.WriteLine("----------");

                string query3 = "SELECT * FROM Trains";

                using (SqlCommand cmd = new SqlCommand(query3, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}, IsDeleted: {reader["IsDeleted"]}");
                            Console.WriteLine();
                        }
                    }
                }
            }

            Console.WriteLine();
            AdminOptions();
        }

        public static void UserRegistration() //New User Registration
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("USER REGISTRATION");
            Console.WriteLine("-----------------");
            Console.Write("Enter User ID: ");
            string userID = Console.ReadLine();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "INSERT INTO Users (UserID, Name, Password) VALUES (@userID, @name, @password)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Registration successful!");
            UserLogin();
        }

        public static void UserLogin() //User Login
        {
            Console.WriteLine("----------");
            Console.WriteLine("USER LOGIN");
            Console.WriteLine("----------");
            Console.Write("Enter UserID: ");
            string userID = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            string query = "SELECT UserID FROM Users WHERE UserID = @UserID AND Password = @Password";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@Password", password);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            userID = (string)result;
                            Console.WriteLine($"Login successful!");
                            Console.WriteLine();
                            UserOptions(userID);
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, please try again");
                            UserLogin();
                        }
                    }
                }
            }

            catch (SqlException)
            {
                Console.WriteLine("Unable to connect to the database, please try again");
            }
        }

        public static void UserOptions(string userID)
        {
            int userchoice;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("User Options: Please enter from 1-6");
            Console.WriteLine("1. Show trains");
            Console.WriteLine("2. Book trains");
            Console.WriteLine("3. Cancel booking");
            Console.WriteLine("4. View booking");
            Console.WriteLine("5. View cancellation");
            Console.WriteLine("6. Exit");
            Console.WriteLine("-----------------------------------");

            userchoice = Convert.ToInt32(Console.ReadLine());
            if (userchoice == 1)
            {
                ShowTrains(userID);
            }
            else if (userchoice == 2)
            {
                BookTrains(userID);
            }
            else if (userchoice == 3)
            {
                CancelBooking(userID);
            }
            else if (userchoice == 4)
            {
                ViewBooking(userID, true);
            }
            else if (userchoice == 5)
            {
                ViewCancellation(userID);
            }
            else
            {
                Console.WriteLine("Exiting the program");
            }
        }

        public static void ShowTrains(string userID) //Function to Show Trains that are not deleted
        {
            Console.WriteLine("----------------");
            Console.WriteLine("AVAILABLE TRAINS");
            Console.WriteLine("----------------");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Trains WHERE IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}");
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        UserOptions(userID);
                    }
                }
            }
        }

        public static void BookTrains(string userID) //Function to Book Trains that are Active
        {
            Console.WriteLine("-------------");
            Console.WriteLine("ACTIVE TRAINS");
            Console.WriteLine("-------------");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query1 = "SELECT * FROM Trains WHERE Status = 'Active' AND IsDeleted = 0";

                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Train Number: {reader["TrainNo"]}, Train Name: {reader["TrainName"]}, Origin: {reader["Origin"]}, Destination: {reader["Destination"]}, Status: {reader["Status"]}");
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine("DETAILS");
                Console.Write("Enter Train Number: ");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                string query2 = "SELECT Status FROM Trains WHERE TrainNo =" + trainNo.ToString();

                using (SqlCommand cmd = new SqlCommand(query2, conn))
                {
                    string status = (string)cmd.ExecuteScalar();
                    if (status == null)
                    {
                        Console.WriteLine("Train does not exist, please try again");
                        Console.WriteLine();
                        BookTrains(userID);
                    }
                    else if (status == "Active")
                    {
                        Console.WriteLine("Train is active, continue booking");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Train is not active, please enter again");
                        Console.WriteLine();
                        BookTrains(userID);
                    }
                }

                string query3 = "SELECT * FROM TrainClass WHERE TrainNo =" + trainNo.ToString();
                using (SqlCommand cmd = new SqlCommand(query3, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Class ID: {reader["ClassID"]}, Train Number: {reader["TrainNo"]}, Class Type: {reader["ClassType"]}, Total Berths: {reader["TotalBerths"]}, Available Berths: {reader["AvailableBerths"]}");
                            Console.WriteLine();
                        }
                    }
                }

                Console.Write("Enter Class ID: ");
                int classID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter number of berths: ");
                int berths = Convert.ToInt32(Console.ReadLine());

                string query4 = "SELECT AvailableBerths FROM TrainClass WHERE ClassID =" + classID.ToString() + "AND TrainNo =" + trainNo.ToString();
                using (SqlCommand cmd = new SqlCommand(query4, conn))
                {
                    int AvailableBerths = (int)cmd.ExecuteScalar();
                    if (AvailableBerths < berths)
                    {
                        Console.WriteLine("Berths not available");
                        BookTrains(userID);
                    }
                    else
                    {
                        using (SqlCommand cmd1 = new SqlCommand("Booking", conn))
                        {
                            cmd1.CommandType = CommandType.StoredProcedure;

                            cmd1.Parameters.AddWithValue("@UserID", userID);
                            cmd1.Parameters.AddWithValue("@TrainNo", trainNo);
                            cmd1.Parameters.AddWithValue("@ClassID", classID);
                            cmd1.Parameters.AddWithValue("@BerthsBooked", berths);
                            cmd1.Parameters.AddWithValue("@BookingDate", DateTime.Now);
                            cmd1.ExecuteNonQuery();
                        }

                        string query5 = "UPDATE TrainClass SET AvailableBerths = AvailableBerths -" + berths.ToString() + " WHERE TrainNo =" + trainNo.ToString() + "AND ClassID =" + classID;
                        using (SqlCommand cmd2 = new SqlCommand(query5, conn))
                        {
                            cmd2.ExecuteNonQuery();
                        }

                        Console.WriteLine("Train booked!");
                    }

                    Console.WriteLine();
                    UserOptions(userID);
                }
            }
        }

        public static void CancelBooking(string userID) //Function to Cancel Booking
        {
            ViewBooking(userID, false);
            Console.WriteLine("--------------");
            Console.WriteLine("CANCEL BOOKING");
            Console.WriteLine("--------------");
            Console.Write("Enter Booking ID: ");
            int bookingID = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query1 = "SELECT COUNT(*) FROM Bookings WHERE BookingID =" + bookingID.ToString() + "AND Status = 'Booked'";
                using (SqlCommand cmd1 = new SqlCommand(query1, conn))
                {
                    int count = (int)cmd1.ExecuteScalar();
                    if (count > 0)
                    {
                        string query2 = "UPDATE Bookings SET Status = 'Cancelled' WHERE BookingID =" + bookingID.ToString() + "AND Status = 'Booked'";
                        using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                        {
                            cmd2.ExecuteNonQuery();
                        }
                        string query3 = "SELECT BerthsBooked, ClassID FROM Bookings WHERE BookingID =" + bookingID.ToString();
                        using (SqlCommand cmd3 = new SqlCommand(query3, conn))
                        {
                            using (SqlDataReader reader = cmd3.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int berthsBooked = (int)reader["BerthsBooked"];
                                    int classID = (int)reader["ClassID"];
                                    reader.Close();
                                    string query4 = "UPDATE TrainClass SET AvailableBerths = AvailableBerths + " + berthsBooked.ToString() + "WHERE ClassID =" + classID.ToString();
                                    using (SqlCommand cmd4 = new SqlCommand(query4, conn))
                                    {
                                        cmd4.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        Console.WriteLine("Booking cancelled!");
                        Console.WriteLine();
                    }

                    else
                    {
                        Console.WriteLine("No booking found, try again!");
                    }

                    UserOptions(userID);
                }
            }
        }

        public static void ViewBooking(string userID, bool showUserOptions) //Function to View Booking
        {
            Console.WriteLine("---------------");
            Console.WriteLine("BOOKING DETAILS");
            Console.WriteLine("---------------");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT b.BookingID, u.Name, tc.TrainNo, tc.ClassType, b.BerthsBooked, b.Status, b.BookingDate FROM Bookings b, Users u, TrainClass tc WHERE b.UserID ='" + userID + "' AND b.UserID = u.UserID  AND b.ClassID = tc.ClassID AND b.Status = 'Booked'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Booking ID: {reader["BookingID"]}, Name: {reader["Name"]}, Train Number: {reader["TrainNo"]}, Class Type: {reader["ClassType"]}, Berths Booked: {reader["BerthsBooked"]}, Status: {reader["Status"]}, BookingDate: {reader["BookingDate"]}");
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        if (showUserOptions == true)
                        {
                            UserOptions(userID);
                        }

                    }
                }
            }
        }

        public static void ViewCancellation(string userID) //Function to view Cancelled Booking
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("CANCELLATION DETAILS");
            Console.WriteLine("--------------------");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT b.BookingID, u.Name, tc.TrainNo, tc.ClassType, b.BerthsBooked, b.Status, b.BookingDate FROM Bookings b, Users u, TrainClass tc WHERE b.UserID ='" + userID + "' AND b.UserID = u.UserID  AND b.ClassID = tc.ClassID AND b.Status = 'Cancelled'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Booking ID: {reader["BookingID"]}, Name: {reader["Name"]}, Train Number: {reader["TrainNo"]}, Class Type: {reader["ClassType"]}, Berths Booked: {reader["BerthsBooked"]}, Status: {reader["Status"]}, BookingDate: {reader["BookingDate"]}");
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                        UserOptions(userID);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Railway Reservation System!");

            int choice = 0;

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Please enter an option from 1-4");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Registration");
            Console.WriteLine("3. User Login");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-------------------------------");

            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                AdminLogin();
            }
            else if (choice == 2)
            {
                UserRegistration();
            }
            else if (choice == 3)
            {
                UserLogin();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Exiting the program");
            }
            else
            {
                Console.WriteLine("Invalid choice, please enter again");
                Console.WriteLine();
                Main(args);
            }
        }
    }
}