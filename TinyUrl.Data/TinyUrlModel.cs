namespace TinyUrl.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TinyUrlModel : DbContext
    {
        // Your context has been configured to use a 'TinyUrlModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TinyUrl.Data.TinyUrlModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TinyUrlModel' 
        // connection string in the application configuration file.
        public TinyUrlModel()
            : base("TinyUrlModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TinyUrlModel>(null);
            base.OnModelCreating(modelBuilder);
        }
    }

}