namespace WindowsFormsApp21
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class EntityModel : DbContext
    {
        // Your context has been configured to use a 'EntityModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WindowsFormsApp21.EntityModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EntityModel' 
        // connection string in the application configuration file.
        public EntityModel()
            : base("EntityModel.cs")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Custom> customs { get; set; }
        public virtual DbSet<Prod> products { get; set; }
        public virtual DbSet<Orders> orders { get; set; }
    }

    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public User() { }

        public User(int id, string userName, string password, string name, string surname)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
        }
    }

    public class Custom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public User User_id { get; set; }

        public Custom()
        {
        }

        public Custom(int id, string name, string surname, string email, string phone, string address, User user_id)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Address = address;
            User_id = user_id;
        }
    }
    public class Prod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public User User_id { get; set; }

        public Prod()
        {
        }

        public Prod(int id, string name, string price, int quantity, string description, User user_id)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
            User_id = user_id;
        }
    }
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Custom Client_id { get; set; }
        public Prod Product_id { get; set; }
        public int Quantity { get; set; }
        public DateTime Arrive { get; set; }
        public DateTime OrderTime { get; set; }
        public User User_id { get; set; }

        public Orders()
        {
        }

        public Orders(int id, Custom client_id, Prod product_id, int quantity, DateTime arrive, DateTime orderTime, User user_id)
        {
            Id = id;
            Client_id = client_id;
            Product_id = product_id;
            Quantity = quantity;
            Arrive = arrive;
            OrderTime = orderTime;
            User_id = user_id;
        }
    }
}