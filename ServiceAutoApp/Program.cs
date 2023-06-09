﻿using ServiceAutoApp.Database;
using ServiceAutoApp.Logic;
using ServiceAutoApp.Users;
using System.Data.Entity;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
            
            Service Auto App

            [X] the person that is on the shift at the auto service should authenticate with a user
            [X] the following type of users should have different permissions
                [X] Normal user -> can only add new customers, new car, make a service request and update the status of the request
                [X] Admin user -> this user is the only one that can delete/create/update the normal user
            [X] possibility to register new customers
            [X] the customers can have multiple cars
            [X] every car should have a history that contains the parts changed, price, date, car number, color, km, owner, status
            [X] Admin/Normal user can update the status of the service request
           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");


        ServiceAppLogic serviceAutoApp = new ServiceAppLogic();
        serviceAutoApp.authUser();


        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}