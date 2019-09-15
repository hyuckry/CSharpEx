using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SOLID
{
    #region SRP Single Responsibility Principle
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        public static int count = 0;
        public int AddEntry(string Text)
        {
            entries.Add($"{++count} : {Text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
        // Save & Load Method는 entries 처리를 위한 기능들이 아님.
        // Class의 관심사가 다름 SRP 분할 처리 하는게 좋음.
        public void Save(string filename)
        {
        }
        public void Load(string filename)
        {
        }
        //
    }
    class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
    #endregion SRP

    #region OCP Open Close Principle
    public enum Color
    {
        Red, Green, Blue
    }
    enum Size
    {
        Small, Medium, Large, Yuge
    }
    class Product
    {
        public string name;
        public Color color;
        public Size size;

        public Product(string name, Color color, Size size)
        {
            if (name == null) throw new ArgumentNullException(paramName: nameof(name));
            this.name = name;
            this.color = color;
            this.size = size;
        }
    }
    class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.size == size) yield return p;
            }
        }
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            return from p in products
                   where p.color == color
                   select p;
        }
        public IEnumerable<Product> FilterBySizeAbdColor(IEnumerable<Product> products, Size size, Color color)
        {
            return products.Where(p => p.color == color && p.size == size).Select(p => p);
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    class ColorSpecification : ISpecification<Product>
    {
        Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.color == color;
        }
    }
    class SizeSpecification : ISpecification<Product>
    {
        Size size;
        public SizeSpecification(Size size) => this.size = size;
        public bool IsSatisfied(Product t) => t.size == size;
    }

    class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            if (first == null) throw new ArgumentNullException(paramName: nameof(first));
            this.first = first;
            this.second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }

        public bool IsSatisfied(T t)
        {
            return first.IsSatisfied(t) && second.IsSatisfied(t);
        }
    }

    class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach (var i in items)
                if (spec.IsSatisfied(i))
                    yield return i;
        }
    }
    #endregion OCP

    #region LSP Liskov Substitution Principle
    class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle()
        {
        }

        public override string ToString()
        {
            return $"{nameof(Width)} : {Width}, {nameof(Height)} : {Height}";
        }
    }

    class Square : Rectangle
    {
        public override int Width { set { base.Width = base.Height = value; } }
        public override int Height { set => base.Width = base.Height = value; }
    }

    #endregion

    #region ISP Interface Segregation Principle
    class Document
    {
    }
    interface IMachine
    {
        void print(Document d);
        void scan(Document d);
        void fax(Document d);
    }
    class MultifunctionPrinter : IMachine
    {
        public void fax(Document d) => throw new NotImplementedException();
        public void print(Document d) => throw new NotImplementedException();
        public void scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    interface IPrinter
    {
        void Print(Document d);
    }
    interface IScanner
    {
        void Scan(Document d);
    }

    class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new NotImplementedException();
        }
        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }

    interface IMultiFunctionDevice : IScanner,IPrinter//...
    {

    }

    class MultifunctionDevice : IMultiFunctionDevice
    {
        IPrinter printer;
        IScanner scanner;

        public MultifunctionDevice(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }//decorator pattern
    }
    #endregion

    #region DIP Dependency Inversion Principle
    enum Relationship
    {
        Parent, Child, Sibling
    }

    class Person
    {
        public string Name { get; set; }
    }

    interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    class RelationshipsH : IRelationshipBrowser
    {
        public List<(Person, Relationship, Person)> Relations { get; } = new List<(Person, Relationship, Person)>();
        public void AddParentAndChild(Person parent, Person child)
        {
            Relations.Add((parent, Relationship.Parent, child));
            Relations.Add((child, Relationship.Child, parent));
        }
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {

            //foreach (var r in Relations.Where(
            //     x => x.Item1.Name == name && x.Item2 == Relationship.Parent
            //     ))
            //{
            //    yield return r.Item3;
            //}
            //return from r in Relations.Where(
            //                 x => x.Item1.Name == name && x.Item2 == Relationship.Parent
            //                 )
            //select r.Item3;
            return Relations.Where(
                             x => x.Item1.Name == name && x.Item2 == Relationship.Parent
                             ).Select(r => r.Item3);
        }
    }
    //low-level
    class Relationships
    {
        public List<(Person, Relationship, Person)> Relations { get; } = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            Relations.Add((parent, Relationship.Parent, child));
            Relations.Add((child, Relationship.Child, parent));
        }
    }

    class Research
    {
        public Research(Relationships relationships)
        {
            var relations = relationships.Relations;
            foreach (var r in relations.Where(
                x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent
                ))
            {
                Console.WriteLine($"John has a child called {r.Item3.Name}");
            }
        }

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                Console.WriteLine($"John has a child called {p.Name}");
        }
    }

    #endregion
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;
        static void Main(string[] args)
        {
            #region SRP Single Responsibility Principle
            Journal j = new Journal();
            j.AddEntry("Hello World!");
            j.AddEntry("Hello World2!");

            Persistence persistence = new Persistence();
            string filename = @"c:\j.txt";
            //persistence.SaveToFile(j, filename, true);
            //Process.Start(filename);
            #endregion SRP

            #region OCP Open Close Principle
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            List<Product> products = new List<Product> { apple, tree, house };

            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product(i.ToString(), Color.Green, Size.Large));
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //
            var pf = new ProductFilter();
            Console.WriteLine("Old Filter 시작 시간 : {0}", sw.Elapsed.Milliseconds.ToString());
            Console.WriteLine("Green products (old):");
            foreach (var p in pf.FilterByColor(products, Color.Green))
            {
                //Console.WriteLine($" - {p.name} {p.color} is green");
            }
            Console.WriteLine("Old Filter 종료 시간 : {0}", sw.Elapsed.Milliseconds.ToString());

            //
            var bF = new BetterFilter();
            Console.WriteLine("New Filter 시작 시간 : {0}", sw.Elapsed.Milliseconds.ToString());
            Console.WriteLine("Green products (new):");
            foreach (var p in bF.Filter(products, new ColorSpecification(Color.Green)))
            {
                //Console.WriteLine($" - {p.name} {p.color} is green");
            }
            Console.WriteLine("New Color Filter 처리 시간 : {0}", sw.Elapsed.Milliseconds.ToString());
            Console.WriteLine("Large products (new):");
            foreach (var p in bF.Filter(products, new SizeSpecification(Size.Large)))
            {
                //Console.WriteLine($" - {p.name} {p.color} is green");
            }
            Console.WriteLine("New Size Filter 처리 시간 : {0}", sw.Elapsed.Milliseconds.ToString());

            foreach (var p in bF.Filter(products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Green),
                    new SizeSpecification(Size.Large)
                    )))
            {

            }
            sw.Stop();
            #endregion OCP

            #region LSP Liskov Substitution Principle
            Rectangle rc = new Rectangle(3, 4);
            Console.WriteLine($"{rc} has area {Area(rc)}");

            Square sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");

            Rectangle recsq = new Square();
            recsq.Width = 4;
            Console.WriteLine($"{recsq} has area {Area(recsq)}");
            #endregion LSP

            #region ISP Interface Segregation Principle

            #endregion

            #region DIP Dependency Inversion Principle
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
            new Research(relationships);

            var relationshipsH = new RelationshipsH();
            relationshipsH.AddParentAndChild(parent, child1);
            relationshipsH.AddParentAndChild(parent, child2);
            new Research(relationshipsH);
            #endregion
        }
    }
}
