using DotNetDesignPatternDemos.Creational.Builder;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetDesignPatternDemos.Creational.Builder
{
    public class Person
    {
        public string Name, Position;
    }


//    This is the core functional builder.
//It stores a list of Action<Person> delegates — each one describes a step to configure a Person.
    public sealed class PersonBuilder
    {
        public readonly List<Action<Person>> Actions
          = new List<Action<Person>>();

        public PersonBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this; // Return the builder to allow chaining (fluent interface)
        }

        public Person Build()
        {
            var p = new Person();
            Actions.ForEach(a => a(p)); // Execute all actions on the person: applies the settings
            return p;
        }
    }


//    Adds a new method WorksAsA to PersonBuilder via extension methods.
//This follows the Open/Closed Principle: you can "extend" functionality without modifying the original class.
    public static class PersonBuilderExtensions
    {
        //This method extends PersonBuilder.
        //provided the extension method is in scope(i.e., the namespace it's in is accessible).

       // The compiler sees that PersonBuilder has no instance method WorksAsA, so it looks for extension methods that match, finds one in PersonBuilderExtensions, and binds it
        public static PersonBuilder WorksAsA
          (this PersonBuilder builder, string position)
        {

            builder.Actions.Add(p =>
            {
                p.Position = position;
            });
            return builder;
        }
    }

    static class Demo
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
            .Called("Alice")
            .WorksAsA("Developer")
            .Build();
        }
    }
}



