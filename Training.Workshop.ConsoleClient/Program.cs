using System;
using System.Linq;

using Training.Workshop.Domain.Entities;
using Training.Workshop.Service;
using Training.Workshop.Service.ServiceLocator;
using Training.Workshop.Domain.Services;
using System.Collections.Generic;
using System.Text;

namespace Training.Workshop.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {



            string[] names = {"John","Bill","Alex","Christopher","Ada","Adalyn","Adele","Barney"
				 	 ,"Becky","Brandon","Candi","Cate","Dale","Richard","Dyson","Emily"
					 ,"Flora","Floyd","Graham","Hank","Eileen","James","Joshua","Kylie"
					 ,"Laura","Madison","Miles","Morgana","Nelson","Patty","Phyllis"
					 ,"Posy","Ralph","Rex","Ronald","Rudy","Saxon","Sharon","Shelley"
					 ,"Sophia","Stewart","Thomas","Tricia","Vance","Warwick","William"
					 ,"Yasmin","Selma","Zula","Zoe"};

            string[] surnames = {"Adamson","Adhock","Acker","Beckett","Bonner","Brooks","Causer"
						,"Clayton","Cox","Cory","Curtis","Davidson","Dixon","Dyson","Ewart"
						,"Forest","Foster","Garnett","Greene","Harlan","Hawk","Hayley","Hollins"
						,"Howe","Jervis","Kersey","Kirby","Lockwood","Mathews","Merill","Moore"
						,"Nash","Olson","Parish","Peak","Readdie","Rose","Savage","Sexton","Simmons"
						,"Spear","Starr","Tailor","Thomas","Tifft","Tinker","Wallis","West","Woods","York"};

            var rand = new Random();





            for (int i = 0; i < 50; i++)
            {
                string password = "";

                string passwordwithsaltSHA = "";

                string salt = "";

                byte[] hash;

                for (int k = 0; k < 20; k++)
                {
                    password += Convert.ToChar(rand.Next(65, 90));
                }

                for (int j = 0; j < rand.Next(8, 15); j++)
                {
                    salt += Convert.ToChar(rand.Next(65, 90));
                }

                using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                {
                    hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password + salt));
                }
                var stringbuilder = new StringBuilder();
                foreach (byte b in hash)
                {
                    stringbuilder.AppendFormat("{0:x2}", b);
                }
                passwordwithsaltSHA = stringbuilder.ToString();

                string str = names[rand.Next(0, 49)] + " " + surnames[rand.Next(0, 49)] + " " + passwordwithsaltSHA + " " + salt;

                Console.WriteLine(str);
            }
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            //Register Existing Services
            ServiceLocator.RegisterService<IUserService>(typeof(UserService));

            ServiceLocator.RegisterService<IBikeService>(typeof(BikeService));

            ServiceLocator.RegisterService<ISparepartService>(typeof(SparepartService));

            ////Configuration of Database 
            ////Work with file database, uncomment if need and comment the SQL factory.
            ////Data.Context.Current.RepositoryFactory = new RepositoryFactory();

            //UnitOfWork.Context.Current.UnitOfWorkFactory = new FileSystemDatabaseUnitOfWorkFactory();

            //Configuration of Database
            //Work with SQL Database,if need work with file database need to comment Factory;
            Data.Context.Current.RepositoryFactory = new Data.SQL.RepositoryFactory();

            UnitOfWork.Context.Current.UnitOfWorkFactory = new Data.SQL.SQLSystemUnitOfWork.SQLSystemDatabaseUnitofWorkFactory();

            // execute
            string command;
            while (!string.IsNullOrEmpty(command = Console.ReadLine()))
            {
                // adduser username password
                var commandArgs = command.Split(' ');

                switch (commandArgs[0])
                {
                    case "adduser":

                        if (commandArgs.Count() == 4)
                        {
                            string[] str = { commandArgs[3] };
                            User.Create(commandArgs[1], commandArgs[2], str);
                        }
                        else
                        {
                            string[] str = { commandArgs[3], commandArgs[4] };
                            User.Create(commandArgs[1], commandArgs[2], str);
                        }
                        break;

                    case "deleteuser":

                        //TODO
                        //wrong version of code,need rework (but working version)
                        Data.Context.Current.RepositoryFactory.GetUserRepository().DeleteUser(commandArgs[1]);
                        break;

                    case "updateuser":
                        break;

                    case "login":
                        User.GetUser(commandArgs[1], commandArgs[2]);
                        break;
                    //Old method
                    case "searchuser":
                        Data.Context.Current.RepositoryFactory.GetUserRepository().GetRolesandPermissionsbyUsername(commandArgs[1]);
                        break;
                    //new method by RetrieveUser(string username)
                    case "getuser":
                        User.GetUser(commandArgs[1]);
                        break;
                    //new method by RetrieveAllUsers()
                    case "getallusers":
                        User.GetAllUsers();
                        break;

                    case "addbike":
                        Bike.Create(commandArgs[1], commandArgs[2], commandArgs[3], Convert.ToInt32(commandArgs[4]), commandArgs[5]);
                        break;

                    case "deletebike":
                        Bike.Delete(commandArgs[1], int.Parse(commandArgs[2]));
                        break;

                    case "updatebike":
                        //manufacturer, mark, ownerID, newcondition
                        Bike.UpdateCondition(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]), commandArgs[4], commandArgs[5]);
                        break;

                    case "searchbikes":
                        Bike.Findbikebyownername(commandArgs[1]);
                        break;

                    case "getbike":
                        Bike.Findbikebybikeid(int.Parse(commandArgs[1]));
                        break;

                    case "getallbikes":
                        Bike.Search();
                        break;

                    case "addsparepart":
                        Sparepart.Create(commandArgs[1], commandArgs[2], commandArgs[3], Convert.ToInt32(commandArgs[4]));
                        break;

                    case "deletesparepart":
                        break;

                    case "updatesparepart":
                        break;

                    default:
                        throw new InvalidOperationException("Unknown command.");
                }
            }
        }
    }
}
