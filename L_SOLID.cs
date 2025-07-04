﻿using static System.Console;

namespace DotNetDesignPatternDemos.SOLID.LiskovSubstitutionPrinciple
{
    // using a classic example
    public class Rectangle
    {

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        //public new int Width
        //{
        //  set { base.Width = base.Height = value; }
        //}

        //public new int Height
        //{ 
        //  set { base.Width = base.Height = value; }
        //}

        public override int Width 
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

        public class Demo
        {
            static public int Area(Rectangle r) => r.Width * r.Height;

            static void Main(string[] args)
            {
                Rectangle rc = new Rectangle(2, 3);
                WriteLine($"{rc} has area {Area(rc)}");

            // should be able to substitute a base type for a subtype
            /*Square*/
            Rectangle sq = new Square();
            sq.Width = 4;
            WriteLine($"{sq} has area {Area(sq)}");
            // but this will not work as expected
            // because the square is not a rectangle in the sense of Liskov Substitution Principle
            // WriteLine($"{sq} has area {Area(sq)}");
            // so we need to fix the Square class to ensure it adheres to the Liskov Substitution Principle

        }
    }
    }