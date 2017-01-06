# Stuck?  Want to learn more about these technologies?
**Contact me on CodeMentor for Live 1:1 Help!**

[![Contact me on Codementor](https://cdn.codementor.io/badges/contact_me_github.svg)](https://www.codementor.io/copperstarconsulting?utm_source=github&utm_medium=button&utm_term=copperstarconsulting&utm_campaign=github)
# Tickinator  
Tickinator is an example support ticket management system that's implemented in Microsoft's .NET framework and Windows Presentation Foundation (WPF).
This project is intended to illustrate programming principles including:
* SOLID Principles
* Test-Driven Development
* Inversion of Control
* MVVM Pattern

# Technologies:
* Windows Presentation Foundation (WPF) - UI Layer
* MVVMLight - ViewModel Layer
* Castle Windsor - Inversion of Control (IoC) container
* NUnit - Unit testing framework
* Moq - Mocking framework

# Project Overview:
I implemented this project as a teaching example for my [CodeMentor](https://www.codementor.io/copperstarconsulting) students.  

For the actual scope of this project, the approaches are somewhat over-engineered,
however I wanted an intermediate example to show students how these different pieces
fit together in larger-scale applications.

## General Approach:
In implementing this project, I used the following practices:
* **Top-down design**:  Each feature implementation starts at the highest-possible level
 (often the UI layer), and stubbing out the next-lower layer's API.  See below for more details on this approach.  
 ***Note**: Each of my implementation checkins include a set of design notes outlining the plan for implementing the current feature.  It may be helpful to review these notes to further understand the top-down process.*
* **Test-driven development**:  Each feature has a comprehensive suite of unit tests implemented in NUnit, following Test-Driven Development (TDD) practices.
* **Dependency Injection / Inversion of Control**:  The preliminary implementation of this project used manual dependency injection to illustrate the basic tenets of Dependency Injection.  As is often the case, the project became more and more complex as even simple features were added, specifically due to managing dependencies.  This is a common situation that often provides motivation to adopt an Inversion of Control container.
* **SOLID Principles**:  SOLID principles are a set of architectural practices that aid in engineering robust, flexible, and stable software solutions.  SOLID is an acronym for:
  * **Single Responsibility Principle**
    * A class should have a single responsibility.  When properly implemented, a change in the specification should only impact one class.
  * **Open-Closed Principle**
    * A class should be open for extension but closed to modification.  When combined with the Dependency Inversion principle and the Liskov Substitution principle, enables class behaviors to be injected (thereby changing the class' behavior) at runtime, without modifying the code for the dependent class.
  * **Liskov Substitution Principle**
    * Objects in a program should be substitutable with instances of their subtypes.  In effect, this means that if I have a class of type A and a class of type B which inherits from type A, I can pass either type to a method that is expecting type A (see below).
      ```c#
      class A{
        public void GreetA(){
            Console.WriteLine("Greetings from A");
        }
      }

      class B : A{
        public void GreetB(){
            Console.WriteLine("Greetings from B");
        }
      }

      function DoSomething(A parameter){
        // I can pass either type A or type B to this method
        // but I can only interact with it as a type A here
        // for example, this works whether or not I passed in 
        // type A or B:
        parameter.GreetA();

        // This won't work, even if I passed in type B:
        // parameter.GreetB();
      }

      function DoSomething(B){
        // I can only pass type B to this method, type A will not compile.
      }
      ```
  * **Interface Segregation Principle**
    * Prefer many small client-specific interfaces to one general-purpose interface.  In a nutshell, this means that individual interfaces should be small and specific, and can be composed into larger implementations as needed.
      ```c#
      // Bad example:
      // This is considered bad because not all clients will need all parts
      // of this interface.
      public interface IRepository{
          void Add(...);
          void Update(...);
          ... GetById(...);
          ... GetAll();
          void Delete(...);
      }
      
      // Segregated approach:
      public interface IRepositoryAdd{
          void Add(...);
      }
      
      public interface IRepositoryUpdate{
          void Update(...);
      }
      
      public interface IRepositoryDelete{
          void Delete(...)
      }
      
      public interface IRepository{
          ... GetById(...);
          ... GetAll(...);
      }
      
      public class ComplexRepository : IRepository, IRepositoryAdd, IRepositoryUpdate, IRepositoryDelete{
          // This class would represent a full-featured repository
          // that can retrieve, add, update, and delete items
          //
          // If, for example, a consuming class only needs the read functionality,
          // it can ask for an IRepository and this instance can fulfill it (see below)
      }
      
      var repo = new ComplexRepository();
      
      // We can pass ComplexRepository to the Consumer constructor
      // because it implements IRepository
      var consumer = new ReadOnlyRepositoryConsumer(repo);
      
      public class ReadOnlyRepositoryConsumer{
          public ReadOnlyRepositoryConsumer(IRepository repository){
              // Even though we have an instance of ComplexRepository,
              // we can only interact with the IRepository methods on it
              // which is cool because we don't need all the other stuff
              // here (theoretically speaking)
          }
      }
      ```
  * **Dependency Inversion Principle**
    * Depend upon abstractions, not concrete types.  In a nutshell, this means that it is better to depend upon abstractions (abstract types or interfaces) than to depend upon concrete types.  The reasoning behind this principle is that it is not possible to substitute different concrete types at runtime unless abstraction is involved.  This principle also has a major impact upon unit testing.
      ```c#
      // Bad approach:
      public class DataTransferObject{
       // just a POCO serving as a container for data.
      }
      
      public class DtoProcessor{
        // Although this is a trivialized example, you cannot inject a fake DataTransferObject into
        // this method for testing, so you will have no easy way to verify that the method
        // actually did the work you expected it to.
        public bool ProcessDto(DataTransferObject input){
            ...do some work on input...
            ...return a result...
        }
      }
      
      // Programming to the abstraction
      public interface IDataTransferObject{
       // This acts as an abstraction of a DataTransferObject
       ...methods/properties...
      }
      
      public class DataTransferObject : IDataTransferObject{
       ...IDataTransferObject implementation...
      }
      
      public class DtoProcessor{
        // Note that the input type is now IDataTransferObject
        // 
        public bool ProcessDto(IDataTransferObject input){
            ...do some work on input...
            ...return a result...
        }
      }
      
      // Now if we wanted to test it...
      [TestFixture]
      public class DtoProcessorTests{
        [Test]
        ProcessDto_Always_PerformsExpectedWork(){
         var dto = new Mock<IDataTransferObject>();
         ...set up mock expectations...
         var systemUnderTest = new DtoProcessor();
        
         // dto.Object is Moq-specific syntax, just accept it for now.
         var result = systemUnderTest.ProcessDto(dto.Object);
        
         // Verify that the result was what we expected:
         Assert.That(result, Is.EqualTo(true));
        
         // Verify that the processor interacted with the mock as we expected:
         // If the mock's expectations were not met, the test will fail.
         dto.VerifyAll();
        }
      }
       ```
### Other patterns:
Tickinator makes use of the Model-View-ViewModel (MVVM) pattern as implemented by Laurent Bugnion's excellent [MvvmLight](https://mvvmlight.codeplex.com/) library.  MVVM is a pattern that encourages separation between actual model data (i.e. POCOs) and view-related metadata such as events, commands, view state, etc.

A typical separation in MVVM would be:
* View components
  * .xaml files **without** (or at least with minimal) code-behind.  Data values are bound to ViewModel properties using WPF binding syntax in the xaml code.
* ViewModel components
  * C# classes exposing data **and** behavior for consumption by the associated View component, such as:
    *  Data properties
    *  Commands (for binding to buttons, etc.)
    *  Other display-related state (i.e. validation messages, etc.)
  * Often ViewModels have an associated Model that they wrap, for example:
    ```c#
    // Model class, note that there is no behavior beyond property getters/setters
    public class Contact{
        public string FirstName{get;set;}
        public string LastName{get;set;}
    }

    // ViewModel class representing the data to the UI layer
    public class ContactViewModel : INotifyPropertyChanged{
       // INotifyPropertyChanged is what tells the WPF UI to update its bindings from the ViewModel
       public event PropertyChangedEventHandler PropertyChanged;

        Contact model;
        public ContactViewModel(Contact model){
            this.model = model;
        }

        // Note that we just delegate retrieval and assignment to our internal model object
        // but we add a key piece of functionality, namely raising the PropertyChanged event.
        public FirstName{
            get{
                return model.FirstName;
            }
            set{
                model.FirstName = value;
            }
        }

        void RaisePropertyChanged(string propertyName){
            var handler = PropertyChanged;
            if(handler!=null){
                // Raise the event;
                handler(new PropertyChangedEventArgs(propertyName);
            }
        }
    }

    ``` 
  * ViewModels typically implement the INotifyPropertyChanged interface to communicate changes to the UI layer.  This is the magic that underpins the WPF DataBinding infrastructure.
* Model components
  * The very simplest components in MVVM, they act as dumb data containers (they have no behavior or logic) and are used solely to transport data between layers.
## Interesting Parts of the Code:
### Application Startup
* As usual, the best place to start checking things out is at the application's entry point.  In this case, the entry point is in ```Tickinator.Ui.Wpf.App.xaml.cs```
  The OnStartup method is responsible for starting up the application (Bootstrapping) and displaying the initial form.
* The Bootstrapper is another key component.  Its responsibility is configuring the Windsor container so that Windsor can resolve types for us at runtime.  The bootstrapper calls into IWindsorContainer.Install, which in turn searches the assembly for any classes that implement IWindsorInstaller (see below) and executing their Install methods.  
* Next on the list are the XXXAssemblyInstaller classes, which correspond to other assemblies in the project and whose responsibility is registering types with the IoC container.  In most cases, the heavy lifting is handled by the AssemblyInstallerBase class (for example ModelAssemblyInstaller), but in some specialized cases we override Castle Windsor defaults (for example MockDataAssemblyInstaller, which needs to register certain types as singletons.)  Once all the AssemblyInstallers have executed, the fully-configured Windsor container is returned from the Bootstrapper.
* Once the container is configured, we're back to the OnStartup method to finish starting the application.  One interesting thing to note is that we have to create instances of types (such as MainViewModel, etc.) but we do so **without** using the ```new()``` operator, instead letting the container create instances for us, using ```container.Resolve<T>```:
  ```c#
  // Ask the container for an instance of ICurrentUserViewModelFactory
  // (this is a Windsor factory, so we don't actually have a class that implements
  // this interface - Windsor dynamically creates one at runtime when the factory interface is resolved.)
  var currentUserFactory = container.Resolve<ICurrentUserViewModelFactory>();

  // Get an instance of ICurrentUserViewModel from the factory, injecting a 
  // dummy userId of 1.
  var currentUser = currentUserFactory.Create(1);

  // Ask the container for an instance of IMainViewModelFactory
  var mainViewModelFactory = container.Resolve<IMainViewModelFactory>();

  // Get an instance of IMainViewModel from the factory, injecting the currentUser
  // we created above.
  // NOTE:  
  // This is the MainViewModel constructor:
  // public MainViewModel(ITeamDashboardViewModel teamDashboardViewModel, IMyDashboardViewModelFactory myDashboardViewModelFactory, ITicketListViewModel todaysTicketsListViewModel,ICurrentUserViewModel currentUserViewModel)
  // 
  // Windsor automatically resolves all of the dependencies with the exception of ICurrentUser
  // because CurrentUser requires a value injected at runtime (this is why we use a factory to create it) -
  // we inject the value using the ICurrentUserFactory, get an instance, and then inject that instance into MainViewModel
  // using IMainViewModelFactory.
  var mainViewModel = mainViewModelFactory.Create(currentUser);
  ``` 
  **Important Note:**  Once you have created your composition root (IMainViewModel in this case), you should **not** have to call ```container.Resolve<T>``` anywhere else in the application - Windsor should be able to inject any additional dependencies.  Passing the container around is considered the [ServiceLocator AntiPattern]( http://blog.ploeh.dk/2010/02/03/ServiceLocatorisanAnti-Pattern/), which is a Very Bad Thing&trade;.
  
  Once we have our MainView and MainViewModel resolved, we can tie the two together by setting the View's DataContext property to the ViewModel and showing the main form.

### Layered Architecture
The application is layered to mimic a typical large-scale application, segregating major primary responsibilities into different assemblies.

Generally speaking, a layer may only communicate with the layer directly below it, so for example a UI component cannot bypass business logic (in the ViewModel) by communicating directly with the Repository layer.

#### In (architecturally) descending order, the main layers are:
* Tickinator.Ui.Wpf
  * Wpf-based UI for the project, responsibility is rendering data and allowing user interaction.
  * *Separated out like this in case we want a different UI layer in the future, i.e. ASP.NET, etc.*
* Tickinator.ViewModel
  * Business Logic implementation, responsibility is mediating between View and Repository layers
  * *Note that the View layer 'knows about' (i.e. references) the ViewModel layer, therefore the ViewModel layer cannot know anything about the View layer - it would be a circular reference otherwise* .
* Repository Layer
  * This layer consists of multiple assemblies all at the same logical layer, whose responsibility is to act as an abstraction for an underlying data store.
    * Tickinator.Repository
      * Defines the interfaces for the repository layer.  These interfaces are implemented by concrete Repository libraries.
      * *Note that this is an example of the Dependency Inversion Principle.  The ViewModel layer only knows about the interfaces defined in this assembly, not any of the actual classes in a concrete repository assembly.  This allows us to swap out concrete repository types as needed, for example to support a new database platform, without having to change the remainder of our codebase.* 
    * Tickinator.Repository.MockData [Concrete repository implementation]
      * Provides a simulated (in-memory) repository implementation for use during early application development.
    * [Coming Soon] Tickinator.Repository.MySql [Concrete repository implementation]
      * Provides a repository implementation for a MySql backend.

#### In addition to the main layers, the project has a few assemblies to address common concerns:
* Tickinator.Model
  * Implements Plain Old CLR Objects (POCOs) representing our domain objects.  These POCOs are simple classes that do not contain behavior or raise events.  They are intended to transport data between the Repository and ViewModel layers.
  * *It is important to note that the Model assembly only references the Tickinator.Common assembly.*
* Tickinator.Common
  * Contains truly common functionality/classes for use throughout the application, i.e. enums, strings for UI use, etc.
  * *It is important to note that the Common assembly does not reference **any** other assemblies from this solution.*

#### The final set of assemblies are the ```*.Tests``` assemblies.  
These assemblies contain NUnit tests for their respective target assemblies.  There is generally one test class per entity in the target assembly, that contains all of the tests for that type.

***Note:**  Generally speaking, we do not unit test UI layer components.  Because of this, we try to minimize the amount of code in the UI layer, preferring to keep behavior, etc. in the ViewModel layer.  By similar logic, we do not generally unit test the Models assembly classes because they are just simple property containers and should have no behavior or dependencies.*

***Note:**  I did not implement unit tests for the Tickinator.Repository.MockData assembly because it is not intended for production use and only returns static data.*
* Tickinator.ViewModel.Tests
  * Contains unit tests for the ViewModel layer
* Tickinator.Repository.Tests
  * Currently empty, will contain common Repository test infrastructure once we start implementing non-mock repositories.

## Other Fun Little Nuggets

### WPF Goodies:
* Example of WPF DataTemplating Functionality
  * Tickinator.UI.Wpf.Resources.DashboardTemplate.xaml defines the template to use when rendering Dashboard data
  * Tickinator.UI.Wpf.Resources.DashboardStyle.xaml ties the template to the MyDashboard and TeamDashboard types
* WPF UserControl examples
  * Dashboard.xaml, TicketNotes.xaml, and TicketList.xaml are all just basic UserControls following the standard WPF UserControl pattern.
  * DashboardBase.cs, MyDashboard.xaml, and TeamDashboard.xaml illustrate the pattern of implementing a common base class for similar UserControls.
* ICommand examples
  * The Tickinator.ViewModel.Command namespace contains several commands used by the application.  Commands are an alternative to the traditional EventHandler model used in WinForms apps.  Handy features include:
    * The concept of "CanExecute", allowing the command to determine whether or not it can execute at any given moment.  CanExecute is also used by the WPF UI to automatically enable/disable UI elements bound to commands (i.e. buttons, menu items, etc.).

### Castle Windsor Excitement:
* Examples of Castle Windsor's TypedFactoryFacility.
  * Factories are used to construct objects that have runtime dependencies (i.e. things that Castle cannot instantiate on its own).  In many circumstances, factories are concrete classes that are allowed to "New" up instances, injecting runtime dependencies, i.e.
  ```c#
  // Traditional factory example
  // We use this pattern because newing things up all over the place is the path to madness.
  public class ContactFactory{
    // Let's assume that firstName is only known at runtime, so it has to be injected into Contact.
    public Contact Create(string firstName){
        return new Contact(firstName);
    }
  }
  ``` 
  On the other hand, Castle Windsor's TypedFactoryFacility only requires us to specify an interface for the factory and register it with the container as a factory:
  ```c#
  // With Castle + TypedFactoryFacility, we only have to create an interface
  // and register it as a factory with Castle.  At runtime, Castle
  // will use Reflection to create an instance of the factory and use
  // it to create objects.
  public interface IContactFactory{
    // GOTCHA:  When using Castle Factories, the parameter names for the Factory Method
    // **MUST** match up with the constructor arguments, for example:
    // if Contact's constructor looked like this:
    // public Contact(string firstName)
    // then all will be well... **BUT** if the constructor looked like this instead:
    // public Contact(string name) <-- Notice the param is called name, not firstName
    // then Castle will quietly try to resolve the String type and you will get a null 
    // parameter injected - Sad!
    Contact Create(string firstName);
  }

  public class NeedsToCreateContacts{
    IContactFactory contactFactory;
    // Castle will create and inject the factory for us.
    public NeedsToCreateContacts(IContactFactory contactFactory){
        this.contactFactory = contactFactory;
    }
  
    public void DoSomethingThatRequiresANewContact(){
        var contact = contactFactory.Create("Fred");
        // Castle gives us a Contact instance with its name set to Fred.
        ...do some work with the contact...
    }
  }
  ```

## More Thrills to Come!

# Coming Soon:
* Persistent data storage 
  * Eventually we will implement repositories targeting other data stores, for example perhaps an Xml datastore, or MySql, or Sqlite, etc.
* Alternate front-ends (perhaps ASP.NET, UWP, maybe a console app for the true nerds...
* End-to-end Integration Tests
  * An advanced approach to automate end-to-end testing
* Installer Package