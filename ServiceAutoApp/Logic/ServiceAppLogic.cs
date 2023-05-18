using ServiceAutoApp.Cars;
using ServiceAutoApp.Customers;
using ServiceAutoApp.Database;
using ServiceAutoApp.Users;

namespace ServiceAutoApp.Logic
{
    public class ServiceAppLogic
    {
        UserInput userInput = new UserInput();
        DatabaseManager databaseManager = new DatabaseManager();
        static List<string> statusList = new List<string>() {"In progress", "Blocked", "Finished", "Waiting"};
        
        public void authUser()
        {
            Console.WriteLine("Username: ");
            string inputUsername = userInput.getUserInput();

            Console.WriteLine("Password: ");
            string inputPassword = userInput.getUserInput();

            User user = databaseManager.getUser(inputUsername, inputPassword);

            if(user != null)
            {
                bool adminUser = user.adminUser;
                Console.WriteLine("Login successfull as " + (adminUser ? "ADMIN" : "NORMAL") + " user");

                while (true) 
                {
                    if (adminUser)
                    {
                        string optionMenu = "Option menu: \n" +
                            "1 - Add new user \n" +
                            "2 - Edit user \n" +
                            "3 - Delete user \n" +
                            "4 - Add new customer \n" +
                            "5 - Delete customer \n" +
                            "6 - Add new car \n" +
                            "7 - Delete car \n" +
                            "8 - Service request \n" +
                            "9 - Update service request \n" +
                            "10 - EXIT";

                        Console.WriteLine(optionMenu);

                        string selectedOption = userInput.getUserInput();

                        switch (selectedOption)
                        {
                            default:
                                Console.WriteLine("No correct option selected. Please try again!");
                                break;

                            case "1": // 1 - Add new user
                                Console.WriteLine("You have selected option: 1 - Add new user");

                                Console.WriteLine("Username: ");
                                string usernameNewUser = userInput.getUserInput();

                                Console.WriteLine("Password: ");
                                string passwordNewUser = userInput.getUserInput();

                                Console.WriteLine("First name: ");
                                string firstNameNewUser = userInput.getUserInput();

                                Console.WriteLine("Last name: ");
                                string lastNameNewUser = userInput.getUserInput();

                                Console.WriteLine("Email: ");
                                string emailNewUser = userInput.getUserInput();

                                Console.WriteLine("Phone: ");
                                string phoneNewUser = userInput.getUserInput();

                                Console.WriteLine("Address: ");
                                string addressNewUser = userInput.getUserInput();

                                Console.WriteLine("Admin (yes/no): ");
                                string adminNewUser = userInput.getUserInput();

                                //TODO: continue the implementation


                                break;

                            case "2": // 2 - Edit user
                                Console.WriteLine("You have selected option: 2 - Edit user");

                                Console.WriteLine("Please select how you want to search the user by: \n" +
                                    "1 - Username \n" +
                                    "2 - User ID");

                                string fieldsToEdit = "Fields available to edit, please choose one from: \n" +
                                            "1 - Username \n" +
                                            "2 - Password \n" +
                                            "3 - First Name \n" +
                                            "4 - Last Name \n" +
                                            "5 - Email \n" +
                                            "6 - Phone \n" +
                                            "7 - Address \n" +
                                            "8 - Admin";

                                string optionField = userInput.getUserInput();
                                switch (optionField)
                                {
                                    default:
                                        Console.WriteLine("No correct option selected. Please try again!");
                                        break;

                                    case "1": // 1 - Username
                                        Console.WriteLine("Please add the username: ");
                                        string usernameInputToUpdate = userInput.getUserInput();

                                        Console.WriteLine(fieldsToEdit);

                                        string optionToEditUsername = userInput.getUserInput();

                                        string fieldUsername = switchEditUserByAdmin(optionToEditUsername);

                                        if (!String.IsNullOrEmpty(fieldUsername))
                                        {
                                            Console.WriteLine("You have selected option: " + optionField + "\nPlease add the new information: ");
                                            string newInfo = userInput.getUserInput();
                                            databaseManager.updateUserByUsername(usernameInputToUpdate, fieldUsername, newInfo);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No correct option selected");
                                        }
                                        break;

                                    case "2": // 2 - User ID
                                        Console.WriteLine("Please add the user ID: ");
                                        int userIdInputToUpdate = Int32.Parse(userInput.getUserInput());

                                        Console.WriteLine(fieldsToEdit);

                                        string optionToEditID = userInput.getUserInput();

                                        string fieldID = switchEditUserByAdmin(optionToEditID);

                                        if (!String.IsNullOrEmpty(fieldID))
                                        {
                                            Console.WriteLine("You have selected option: " + optionField + "\nPlease add the new information: ");
                                            string newInfo = userInput.getUserInput();
                                            databaseManager.updateUserByID(userIdInputToUpdate, fieldID, newInfo);
                                        }
                                        else
                                        {
                                            Console.WriteLine("No correct option selected");
                                        }

                                        break;
                                }
                                break;

                            case "3": // 3 - Delete user
                                Console.WriteLine("You have selected option: 3 - Delete user");

                                Console.WriteLine("Add User ID you want to delete: ");
                                string userIdDelete = userInput.getUserInput();

                                if (!String.IsNullOrEmpty(userIdDelete))
                                {
                                    databaseManager.deleteUser(Int32.Parse(userIdDelete));
                                }
                                else
                                {
                                    Console.Write("Some fields were left empty. Please complete them again!");
                                }
                                break;

                            case "4": // 4 - Add new customer
                                Console.WriteLine("You have selected option: 4 - Add new customer");

                                addNewCustomer();
                                break;

                            case "5": // 5 - Delete customer
                                Console.WriteLine("You have selected option: 5 - Delete customer");

                                Console.WriteLine("Customer ID you want to delete: ");
                                string deleteCustomerID = userInput.getUserInput();

                                if (!String.IsNullOrEmpty(deleteCustomerID))
                                {
                                    databaseManager.deteleCustomer(Int32.Parse(deleteCustomerID));
                                }
                                else
                                {
                                    Console.WriteLine("Some fields were left empty.Please complete them again!");
                                }
                                break;

                            case "6": // 6 - Add new car
                                Console.WriteLine("You have selected option: 6 - Add new car");

                                addNewCar();
                                break;

                            case "7": // 7 - Delete car
                                Console.WriteLine("You have selected option: 7 - Delete car");
                                Console.WriteLine("Car number you want to delete: ");

                                string deleteCarNumber = userInput.getUserInput();

                                if (!String.IsNullOrEmpty(deleteCarNumber))
                                {
                                    databaseManager.deleteCar(deleteCarNumber);
                                }
                                else
                                {
                                    Console.WriteLine("Some fields were left empty.Please complete them again!");
                                }
                                break;

                            case "8": // 8 - Service request
                                Console.WriteLine("You have selected option: 8 - Service request");

                                serviceRequest();
                                break;

                            case "9": // 9 - Update service request
                                Console.WriteLine("You have selected option: 9 - Update service request");

                                updateServiceRequestStatus();
                                break;

                            case "10": // 10 - EXIT
                                Console.WriteLine("You have selected option: 10 - EXIT");
                                return;
                                break;
                        }
                    }
                    else
                    {
                        string optionMenu = "Option menu: " +
                            "1 - Add new customer \n" +
                            "2 - Add new car \n" +
                            "3 - Service request \n" +
                            "4 - Update service request \n" +
                            "5 - EXIT";

                        Console.WriteLine(optionMenu);

                        switch (optionMenu)
                        {
                            default:
                                Console.WriteLine("No correct option selected. Please try again!");
                                break;

                            case "1": // 1 - Add new customer
                                Console.WriteLine("You have selected option: 1 - Add new customer");

                                addNewCustomer();
                                break;

                            case "2": // 2 - Add new car
                                Console.WriteLine("You have selected option: 2 - Add new car");

                                addNewCar();
                                break;
                            case "3": // 3 - Service request
                                Console.WriteLine("You have selected option: 3 - Service request");

                                serviceRequest();
                                break;

                            case "4": // 4 - Update service request
                                Console.WriteLine("You have selected option: 4 - Update service request");

                                updateServiceRequestStatus();
                                break;

                            case "5": // 5 - EXIT
                                Console.WriteLine("You have selected option: 5 - EXIT");
                                return;
                                break;
                        }
                    }
                }
                
            }
        }

        private string switchEditUserByAdmin(string option)
        {
            string field = "";

            switch (option)
            {
                default:
                    field = "";
                    break;
                case "1":
                    field = "username";
                    break;
                case "2":
                    field = "password";
                    break;
                case "3":
                    field = "firstName";
                    break;
                case "4":
                    field = "lastName";
                    break;
                case "5":
                    field = "email";
                    break;
                case "6":
                    field = "phone";
                    break;
                case "7":
                    field = "address";
                    break;
                case "8":
                    field = "admin";
                    break;
            }
            return field;
        }

        private void addNewCustomer()
        {
            Console.WriteLine("First name: ");
            string firstNameCustomer = userInput.getUserInput();

            Console.WriteLine("Last name: ");
            string lastNameCustomer = userInput.getUserInput();

            Console.WriteLine("Phone number: ");
            string phoneNumberCustomer = userInput.getUserInput();

            Console.WriteLine("Address: ");
            string addressCustomer = userInput.getUserInput();

            Console.WriteLine("Email: ");
            string emailCustomer = userInput.getUserInput();

            if (!String.IsNullOrEmpty(firstNameCustomer) &&
                !String.IsNullOrEmpty(lastNameCustomer) &&
                !String.IsNullOrEmpty(phoneNumberCustomer) &&
                !String.IsNullOrEmpty(addressCustomer) &&
                !String.IsNullOrEmpty(emailCustomer))
            {
                DateTime registredDateCustomer = DateTime.Now;
                Customer customer = new Customer(
                    0,
                    firstNameCustomer,
                    lastNameCustomer,
                    phoneNumberCustomer,
                    addressCustomer,
                    emailCustomer,
                    registredDateCustomer);
                databaseManager.insertDataCustomers(customer);
                Console.WriteLine("New customer registered successfully");
            }
            else
            {
                Console.Write("Some fields were left empty. Please complete them again!");
            }
        }

        private void addNewCar()
        {
            Console.WriteLine("Customer ID: ");
            string carCustomerID = userInput.getUserInput();

            Console.WriteLine("Car number: ");
            string carNumber = userInput.getUserInput();

            Console.WriteLine("VIN number: ");
            string carVIN = userInput.getUserInput();

            Console.WriteLine("Year: ");
            string yearCar = userInput.getUserInput();

            Console.WriteLine("Engine capacity: ");
            string engineCapacityCar = userInput.getUserInput();

            Console.WriteLine("Fuel Type: ");
            string fuelTypeCar = userInput.getUserInput();

            Console.WriteLine("Color: ");
            string colorCar = userInput.getUserInput();

            if (!String.IsNullOrEmpty(carCustomerID) &&
                !String.IsNullOrEmpty(carNumber) &&
                !String.IsNullOrEmpty(carVIN) &&
                !String.IsNullOrEmpty(yearCar) &&
                !String.IsNullOrEmpty(engineCapacityCar) &&
                !String.IsNullOrEmpty(fuelTypeCar) &&
                !String.IsNullOrEmpty(colorCar))
            {
                DateTime registredDateCar = DateTime.Now;
                Car car = new Car(
                    0,
                    Int32.Parse(carCustomerID),
                    carNumber,
                    carVIN,
                    Int32.Parse(yearCar),
                    Int32.Parse(engineCapacityCar),
                    fuelTypeCar,
                    colorCar,
                    registredDateCar);

                databaseManager.insertDataCar(car);

                Console.WriteLine("Car registered succesfully");
            }
            else
            {
                Console.WriteLine("Some fields were left empty. Please complete them again!");
            }
        }

        private void serviceRequest()
        {
            Console.WriteLine("Add Customer ID: ");
            string customerIDServiceRequest = userInput.getUserInput();

            Console.WriteLine("Add car number: ");
            string carNumberServiceRequest = userInput.getUserInput();

            Console.WriteLine("Add car part name that needs to be replaced: ");
            string carPartNameServiceRequest = userInput.getUserInput();

            Console.WriteLine("Add car part description that needs to be replaced: ");
            string carPartDescriptionServiceRequest = userInput.getUserInput();

            Console.WriteLine("Add price: ");
            string carPartPriceServiceRequest = userInput.getUserInput();

            Console.WriteLine("Add status: ");
            string carPartStatusServiceRequest = userInput.getUserInput();

            if (!String.IsNullOrEmpty(customerIDServiceRequest) &&
                !String.IsNullOrEmpty(carNumberServiceRequest) &&
                !String.IsNullOrEmpty(carPartNameServiceRequest) &&
                !String.IsNullOrEmpty(carPartDescriptionServiceRequest) &&
                !String.IsNullOrEmpty(carPartPriceServiceRequest) &&
                !String.IsNullOrEmpty(carPartStatusServiceRequest))
            {
                Car carServiceRequest = databaseManager.getCar(carNumberServiceRequest);

                DateTime registredDateCarPart = DateTime.Now;
                CarPart carPart = new CarPart(
                    0,
                    carServiceRequest.carId,
                    carPartStatusServiceRequest,
                    carPartNameServiceRequest,
                    carPartDescriptionServiceRequest,
                    registredDateCarPart,
                    Int32.Parse(carPartPriceServiceRequest));

                databaseManager.insertDataCarParts(carPart);
            }
            else
            {
                Console.WriteLine("Some fields were left empty.Please complete them again!");
            }
        }

        private void updateServiceRequestStatus()
        {
            Console.WriteLine("Please add the car part ID: ");
            string carPartID = userInput.getUserInput();

            Console.WriteLine("Please add the new status of the service request: ");
            string newStatus = userInput.getUserInput();

            if (!String.IsNullOrEmpty(carPartID) && !String.IsNullOrEmpty(newStatus))
            {
                if (statusList.Contains(newStatus))
                {
                    databaseManager.updateCarPart(Int32.Parse(carPartID), newStatus);
                }
                else
                {
                    Console.WriteLine("Status is not the expected one.Please complete it again!");
                }
            }
            else
            {
                Console.WriteLine("Some fields were left empty.Please complete them again!");
            }
        }
    }
}
