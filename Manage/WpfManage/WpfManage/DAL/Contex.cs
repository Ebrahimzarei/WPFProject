using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfManage.Model;


namespace WpfManage.DAL
{
    public class Contex : System.Data.Entity.DbContext
    {
        static string _connection;
        public Contex():base("MainContext")
            //: base(_connection ?? "MainContext")
        {
          //  System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contex>());
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contex, Migrations.Configuration>());
        }
   
      //public Contex(/*string connectionString*/ )
      //      //: base(connectionString)
         
      
      //  {
          
      //   //   _connection = connectionString;
      //    // System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Contex>());
      //      //بعد از فعال سازی مهاجرت
      //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<Contex, Migrations.Configuration>());

        
      //  }
   
 
 public DbSet<Personel> memberMap { get; set; }
        //public static string BuildEntityConnection(string connectionString)
        //{
        //    var entityConnection = new EntityConnectionStringBuilder
        //    {

        //         Provider = "System.Data.SqlClient",
        //       ProviderConnectionString = connectionString + "App=EntityFramework",



        //       // Metadata = "//*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl"

        //    };

        //    return entityConnection.ToString();
        //}
        public static string BuildEntityConnection(string DataSource, string Instance, string InitialCatalog, string UserID, string Password)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource + "\\".Trim() + Instance;
            builder.InitialCatalog = InitialCatalog;
            builder.UserID = UserID;
            builder.Password = Password;


            builder.MultipleActiveResultSets = true;
            builder.PersistSecurityInfo = true;
            return builder.ConnectionString.ToString();
        }
        public static string BuildEntityConnection1(string connString)
 {

     Type t = typeof(Contex);
     string assemblyFullName = t.Assembly.FullName.ToString();
     
     string connectionString = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder

     {
      Provider = "System.Data.SqlClient",

         //Metadata = string.Format("res://{0}/", //Models.Model.csdl|Models.Model.ssdl|Models.Model.msl", 
         //          assemblyFullName),

  





         ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder

         {

             InitialCatalog = "NortPersonel",

             //    DataSource = "192.168.0.17\\sql2014",
             DataSource = connString,
             IntegratedSecurity = true,
           
             ApplicationName = "Contex",
             UserID = "sa",                 // User ID such as "sa"

             Password = "@110",               // hide the password

         }.ConnectionString

     }.ConnectionString;

     return connectionString;

 }
    
    
    }
 
}
