using System;
using System.Collections.Generic;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n---------------------- Factory    ----------------------------\n");


            #region 1. Factory
            //Factory Method in C# 
            new Client().Main();
            #endregion

            Console.WriteLine("\n---------------------- Builder    ----------------------------\n");


            #region 2. Builder 
            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.

            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());
            #endregion

            Console.WriteLine("\n---------------------- Facade    ----------------------------\n");

            #region 3. Facade
            // The client code may have some of the subsystem's objects already
            // created. In this case, it might be worthwhile to initialize the
            // Facade with these objects instead of letting the Facade create
            // new instances.
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            FacadeClient.ClientCode(facade);


            Console.WriteLine("----------------------CLIENT ORDERS FOR PIZZA----------------------------\n");
            var facadeForClient = new RestaurantFacade();
            facadeForClient.GetNonVegPizza();
            facadeForClient.GetVegPizza();
            Console.WriteLine("\n----------------------     ----------------------------\n");
            facadeForClient.GetGarlicBread();
            facadeForClient.GetCheesyGarlicBread();



            #endregion

            Console.WriteLine("\n---------------------- Template    ----------------------------\n");

            #region 4. Template 
            Console.WriteLine("Same client code can work with different subclasses:");

            TemplateClient.ClientCode(new ConcreteClass1());

            Console.Write("\n");

            Console.WriteLine("Same client code can work with different subclasses:");
            TemplateClient.ClientCode(new ConcreteClass2());

            #endregion


            Console.WriteLine("\n---------------------- Proxy    ----------------------------\n");

            #region 5. Proxy
            ProxyClient client = new ProxyClient();

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            client.ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            client.ClientCode(proxy);



            Console.WriteLine("\n---------------------- Proxy ACCESS Sample    ----------------------------\n");

            Console.WriteLine("Client passing employee with Role Developer to folderproxy");
            Employee emp1 = new Employee("Dilshod", "password123", "Developer");
            SharedFolderProxy folderProxy1 = new SharedFolderProxy(emp1);
            folderProxy1.PerformRWOperations();
            Console.WriteLine();
            Console.WriteLine("Client passing employee with Role Manager to folderproxy");
            Employee emp2 = new Employee("Aziza", "password321", "Manager");
            SharedFolderProxy folderProxy2 = new SharedFolderProxy(emp2);
            folderProxy2.PerformRWOperations();



            Console.WriteLine("\n---------------------- Proxy Math Sample    ----------------------------\n");

            // Create math proxy
            MathProxy proxy2 = new MathProxy();
            // Do the math
            Console.WriteLine("4 + 2 = " + proxy2.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy2.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy2.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy2.Div(4, 2));
         

            #endregion


            Console.WriteLine("\n---------------------- Singleton    ----------------------------\n");

            #region 6. Singleton

            Singleton fromTeachaer = Singleton.GetInstance;
            fromTeachaer.PrintDetails("From Teacher");
            Singleton fromStudent = Singleton.GetInstance;
            fromStudent.PrintDetails("From Student");
            Console.ReadLine();

            Console.Read();

            #endregion

            #region Strategy

            Console.WriteLine("\n---------------------- Strategy Generic   ----------------------------\n");
            
            // The client code picks a concrete strategy and passes it to the
            // context. The client should be aware of the differences between
            // strategies in order to make the right choice.
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();





            Console.WriteLine("\n---------------------- Strategy Developer Example   ----------------------------\n");
            //Strategy
            // if we have similar classes in our project that only differ on how they execute some behavior, the Strategy pattern should be the right choice for us.
            //We should consider introducing this pattern in situations where a single class has multiple conditions over different variations of the same functionality.
            var reports = new List<DeveloperReport>
        {
            new DeveloperReport {Id = 1, Name = "Dev1", Level = DeveloperLevel.Senior, HourlyRate = 30.5, WorkingHours = 160 },
            new DeveloperReport { Id = 2, Name = "Dev2", Level = DeveloperLevel.Junior, HourlyRate = 20, WorkingHours = 120 },
            new DeveloperReport { Id = 3, Name = "Dev3", Level = DeveloperLevel.Senior, HourlyRate = 32.5, WorkingHours = 130 },
            new DeveloperReport { Id = 4, Name = "Dev4", Level = DeveloperLevel.Junior, HourlyRate = 24.5, WorkingHours = 140 }
        };
            var calculatorContext = new SalaryCalculator(new JuniorDevSalaryCalculator());
            var juniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for junior salaries is: {juniorTotal}");
            calculatorContext.SetCalculator(new SeniorDevSalaryCalculator());
            var seniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for senior salaries is: {seniorTotal}");
            Console.WriteLine($"Total cost for all the salaries is: {juniorTotal + seniorTotal}");


            #endregion



            #region   Observer
            Console.WriteLine("\n---------------------- Observer Developer Example   ----------------------------\n");
            //Observer
            //The Observer pattern provides a way to subscribe and unsubscribe to 
            // and from these events for any object that implements a subscriber interface.
            //Usage examples: The Observer pattern is pretty common in C# code, especially in the GUI components. 
            //It provides a way to react to events happening in other objects without coupling to their classes.
            
            
            //Create a Product with Out Of Stock Status
            SubjectOBS RedMI = new SubjectOBS("Red MI Mobile", 10000, "Out Of Stock");
            //User Jamshid will be created and user1 object will be registered to the subject
            Observer user1 = new Observer("Jamshid", RedMI);
            //User Sevara will be created and user1 object will be registered to the subject
            Observer user2 = new Observer("Sevara", RedMI);
            //User Sergey will be created and user3 object will be registered to the subject
            Observer user3 = new Observer("Sergey", RedMI);

            Console.WriteLine("Red MI Mobile current state : " + RedMI.getAvailability());
            Console.WriteLine();
            // Now product is available
            RedMI.setAvailability("Available");




            #endregion


            #region Iterator
            //Iterator
            Console.WriteLine("\n---------------------- Iterator Example   ----------------------------\n");
            /*
             Iterator is a behavioral design pattern that allows sequential 
              traversal through a complex data structure without exposing its internal details.

             Usage examples: The pattern is very common in C# code. Many frameworks and libraries use it to 
             provide a standard way for traversing their collections.

            Identification: Iterator is easy to recognize by the navigation methods (such as next, previous and others). 
            Client code that uses iterators might not have direct access to the collection being traversed.


             */

            //CREATING SIMILAR FOREACH FUNCTION FOR OUR OBJECT.

            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");
            // Create iterator
            Iterator iterator = collection.CreateIterator();
            // Skip every other item
            iterator.Step = 2;
            Console.WriteLine("Iterating over collection:");
            for (Item item = iterator.First();
                !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
            
            #endregion



        }

    }
}
