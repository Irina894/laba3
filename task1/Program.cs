﻿using System;   

class Person
    {
    public string Name;
    public int Age;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Show()
        {
            Console.WriteLine($"Name: {Name}  Age: {Age} ");
        }
}
public class Program
    {
       public static void Main()
        {
           Person person = new Person("Alice", 30);
        person.Show();
        Person person2 = new Person("Bob", 25);
        person2.Show();
        Person person3 = new Person("Petro", 15);
        person3.Show();

    }
    }

