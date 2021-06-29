using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.WriteLine("Sum:");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("\nAverage:");
            Console.WriteLine(numbers.Average());

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascArray = numbers.OrderBy(num => num);
            var descArray = numbers.OrderByDescending(num => num);

            Console.WriteLine("\nAscending array:");
            foreach (var num in ascArray)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nDescending array:");
            foreach (var num in descArray)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var moreThanSix = numbers.Where(num => num > 6);

            Console.WriteLine("\nNumbers greater than 6:");
            foreach (var num in moreThanSix)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var onlyFour = ascArray.Take(4);

            Console.WriteLine("Take 4 from ascending array:");
            foreach (var num in onlyFour)
            {
                Console.WriteLine(num);
            }

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 25;
            descArray = numbers.OrderByDescending(num => num);

            Console.WriteLine("New descending array with my age added:");
            foreach (var num in descArray)
            {
                Console.WriteLine(num);
            }

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var csNames = employees.Where(name => name.FirstName[0] == 'C' || name.FirstName[0] == 'S').OrderBy(name => name.FirstName);

            Console.WriteLine("\nC or S employee names: ");
            foreach (var name in csNames)
            {
                Console.WriteLine(name.FullName);
            }

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var olderThan26 = employees.Where(name => name.Age > 26).OrderBy(name => name.Age).ThenBy(name => name.FirstName);

            Console.WriteLine("\nEmployees over the age of 26:");
            foreach(var name in olderThan26)
            {
                Console.WriteLine(name.FullName + " " + name.Age);
            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoeEmployees = employees.Where(name => name.YearsOfExperience <= 10 && name.Age > 35);

            Console.WriteLine("\nYOE Sum:");
            Console.WriteLine(yoeEmployees.Sum(name => name.YearsOfExperience));

            Console.WriteLine("\nYOE Average:");
            Console.WriteLine(yoeEmployees.Average(name => name.YearsOfExperience));

            //Add an employee to the end of the list without using employees.Add()
            var newEmployeeList = employees.Append(new Employee("Greatest", "Ever", 9001, 1)).ToList();

            Console.WriteLine("\nMy new employee:");
            Console.WriteLine(newEmployeeList[newEmployeeList.Count - 1].FullName);

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
