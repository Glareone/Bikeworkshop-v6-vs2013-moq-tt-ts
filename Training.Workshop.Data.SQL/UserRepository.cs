using System;
using System.Collections.Generic;
using System.Text;
using Training.Workshop.Domain.Entities;
using Training.Workshop.Data.SQL.SQLSystemUnitOfWork;
using System.Data;
using System.Data.SqlClient;

namespace Training.Workshop.Data.SQL
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Save User in SQL database
        /// </summary>
        /// <param name="user"></param>
        public bool SaveNewUser(string username, string password, string[] rolearray)
        {
            //Added user if username doesn't exist in database
            if (CountUsersWithUsername(username) == 0)
            {
                //Adding into User table
                using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
                {
                    using (var command = unitofwork.Connection.CreateCommand())
                    {
                        //Add new user if database do not have another user with this username
                        var salt = GenerateSalt();

                        command.CommandText = "InsertUser";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("Username", username);
                        command.Parameters.AddWithValue("Password", GenerateSHAHashFromPasswordWithSalt(password, salt));
                        command.Parameters.AddWithValue("Salt", salt);
                        command.ExecuteNonQuery();

                        command.Parameters.Clear();

                        //Adding into UserRole table
                        foreach (var role in rolearray)
                        {
                            //TODO
                            //adding new userrole rows
                            command.CommandText = "InputintoUserRole";
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("Username", username);
                            command.Parameters.AddWithValue("Rolename", role);
                            command.ExecuteNonQuery();
                            command.Parameters.Clear();
                        }
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Delete all users with username from SQL Database
        /// </summary>
        /// <param name="username"></param>
        public void DeleteUser(string username)
        {
            //Delete all user roles and user permissions.
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "DeletefromUserRole";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();

                    //Deleting user from database
                    command.CommandText = "DeleteUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Search and return user if he exist in database,with all his roles and permissions.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User GetUser(string username, string password)
        {
            var user = new User();
            string saltfromdatabase;
            string enteredPasswordwithSaltHash;
            //take salt from database by username and generate SHA hash from entered password and salt
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {

                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var salt = new SqlParameter("salt", SqlDbType.VarChar);

                    //add Value to search by username
                    command.CommandText = "TakeSaltbyUserName";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);
                    //add values to output data from database

                    salt.Direction = ParameterDirection.Output;
                    salt.Size = 15;

                    command.Parameters.Add(salt);

                    command.ExecuteNonQuery();

                    saltfromdatabase = command.Parameters["salt"].Value.ToString();
                    enteredPasswordwithSaltHash = GenerateSHAHashFromPasswordWithSalt(password, saltfromdatabase);
                    //clear parameters for new procedure
                    command.Parameters.Clear();

                    command.CommandText = "CheckPasswordAndReturnUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);
                    command.Parameters.AddWithValue("enteredpassword", enteredPasswordwithSaltHash);

                    var correctusername = new SqlParameter("correctusername", SqlDbType.VarChar);
                    correctusername.Direction = ParameterDirection.Output;
                    correctusername.Size = 50;
                    command.Parameters.Add(correctusername);
                    command.ExecuteNonQuery();
                    //Construct User
                    user.Username = command.Parameters["correctusername"].Value.ToString();

                }
            }
            //return filled user if username and password is correct
            //return empty user if user does not exist in database
            user.Roles = GetRolesandPermissionsbyUsername(user.Username);
            return user;
        }
        /// <summary>
        /// Function returns Count of Users with this username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int CountUsersWithUsername(string username)
        {
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "CountUsersWithUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var countParameter = new SqlParameter("@UserWithUsernameCount", 0);

                    countParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(countParameter);
                    command.ExecuteNonQuery();

                    int count = Int32.Parse(command.Parameters["@UserWithUsernameCount"].Value.ToString());

                    return count;
                }
            }
        }
        /// <summary>
        /// Get all permissions that role has.
        /// </summary>
        /// <param name="rolename"></param>
        /// <returns></returns>
        public List<string> GetPermissionsbyRolename(string rolename)
        {
            var Permissionlist = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    //Configure parameters
                    var Permission = new SqlParameter("Permissionname", SqlDbType.VarChar);

                    Permission.Direction = ParameterDirection.Output;
                    Permission.Size = 50;

                    command.CommandText = "RetrievePermissionbyRolename";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Rolename", rolename);
                    command.Parameters.Add(Permission);

                    var reader = command.ExecuteReader();
                    //take all permissions from database to list
                    while (reader.Read())
                    {
                        Permissionlist.Add(reader["Permissionname"].ToString());
                    }
                }
            }
            return Permissionlist;
        }
        /// <summary>
        /// return all role names which user with username obtained
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public List<string> GetRoleNamesByUsername(string username)
        {
            var rolenamelist = new List<string>();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    var Rolename = new SqlParameter("@Rolename", SqlDbType.VarChar);

                    Rolename.Direction = ParameterDirection.Output;
                    Rolename.Size = 50;
                    command.Parameters.Add(Rolename);

                    command.CommandText = "RetrieveRolesbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        rolenamelist.Add(reader["RoleName"].ToString());
                    }
                }
            }
            return rolenamelist;
        }
        /// <summary>
        /// return all obtained User Roles by username and fill it by permissions,return List of Roles with all permissions.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Role> GetRolesandPermissionsbyUsername(string username)
        {
            List<string> RoleNamesListwhichUserhas = Data.Context.Current.RepositoryFactory.GetUserRepository().GetRoleNamesByUsername(username);

            var RoleList = new List<Role>();

            foreach (var role in RoleNamesListwhichUserhas)
            {
                var Role = new Role()
                {
                    Name = role,
                    Permissions = GetPermissionsbyRolename(role)
                };
                RoleList.Add(Role);
            }

            return RoleList;
        }
        /// <summary>
        /// return all users from database with permissions and roles
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {

            var listofusernames = new List<string>();

            var listofusers = new List<User>();
            //return all usernames
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveAllUsernames";
                    command.CommandType = CommandType.StoredProcedure;

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listofusernames.Add(reader["username"].ToString());
                    }
                }
            }
            //take all roles by usernames and construct list of users with userroles
            foreach (var username in listofusernames)
            {
                var user = new User()
                {
                    Username = username,
                    Roles = GetRolesandPermissionsbyUsername(username)
                };
                listofusers.Add(user);
            }

            return listofusers;
        }
        /// <summary>
        /// return userid by username. this method used when bike creating with ownerID field
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserIDbyUsername(string username)
        {
            int userid = 0;
            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "RetrieveUserIdbyUsername";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("username", username);

                    var userID = new SqlParameter("userID", 0);
                    userID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(userID);

                    command.ExecuteNonQuery();
                    //If owner with username exist in database return UserId, else return 0
                    if (command.Parameters["userID"].Value.ToString() != "")
                    {
                        userid = Int32.Parse(command.Parameters["userID"].Value.ToString());
                    }

                }
            }
            return userid;
        }

        /// <summary>
        /// Generate Salt. Function,that works with user creating.
        /// </summary>
        /// <returns></returns>
        private string GenerateSalt()
        {
            string salt = "";

            //Create salt with random lenght
            var rnd = new Random();

            for (int i = 0; i < rnd.Next(8, 15); i++)
            {
                //Take random char from eng alphabet and push to string salt
                salt += Convert.ToChar(64 + rnd.Next(1, 26));
            }
            return salt;
        }
        /// <summary>
        /// Generate new SHA-hash using user password and salt.
        /// Used when user creating or when userpassword checking.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private string GenerateSHAHashFromPasswordWithSalt(string password, string salt)
        {

            byte[] hash;

            using (var sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
            {
                hash = sha1.ComputeHash(Encoding.Unicode.GetBytes(password + salt));
            }

            var stringbuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringbuilder.AppendFormat("{0:x2}", b);
            }

            return stringbuilder.ToString();
        }
        /// <summary>
        /// Returns all users with permissions and roles.
        /// New method works with 1 stored procedure.
        /// </summary>
        /// <returns></returns>
        public List<User> RetrieveAllUsers()
        {
            var listofusers = new List<User>();


            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "usp_GetAllUsers";
                    command.CommandType = CommandType.StoredProcedure;

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        //UserID,Username
                        List<Tuple<string, string>> userlist = GetUser(reader);

                        if (!reader.NextResult())
                            throw new InvalidOperationException("Cant execute SELECT ROLES");
                        //UserID,RoleID,RoleName
                        List<Tuple<string, string, string>> roleslist = GetRoles(reader);

                        if (!reader.NextResult())
                            throw new InvalidOperationException("Cant execute SELECT PERMISSIONS");

                        // Get Permissions by username
                        List<Tuple<string, string, string>> permissionslist = GetPermissions(reader);
                        reader.Close();

                        //filled user fields before return.
                        foreach (var userelement in userlist)
                        {
                            var newuser = new User();

                            var userid = userelement.Item1;

                            newuser.Username = userelement.Item2.ToString();

                            var rolelist = new List<Role>();

                            foreach (var roleelement in roleslist)
                            {
                                var role = new Role();
                                if (userid == roleelement.Item1)
                                {
                                    role.Name = roleelement.Item3;

                                    var Permissionlist = new List<string>();

                                    foreach (var permissionelement in permissionslist)
                                    {
                                        //if permission relates to role-adding permission to list belongs to role.
                                        if (roleelement.Item2 == permissionelement.Item2)
                                        {
                                            {
                                                Permissionlist.Add(permissionelement.Item3.ToString());
                                            }
                                        }
                                    }
                                    //adding all permissions to role
                                    role.Permissions = Permissionlist;
                                    //adding role to role list of user
                                    rolelist.Add(role);
                                }


                            }
                            newuser.Roles = rolelist;

                            listofusers.Add(newuser);
                        }




                    }
                }
            }

            return listofusers;
        }

        /// <summary>
        /// Get User with roles and permissions by one stored procedure
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User RetrieveUser(string username)
        {
            //User Construction
            var user = new User();

            using (var unitofwork = (ISQLUnitOfWork)Training.Workshop.UnitOfWork.UnitOfWork.Start())
            {
                using (var command = unitofwork.Connection.CreateCommand())
                {
                    command.CommandText = "usp_GetUser";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Username", username);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        //UserID,Username
                        List<Tuple<string, string>> userlist = GetUser(reader);
                        //to search roles and permissions by userID
                        string userID = userlist[0].Item1;

                        if (!reader.NextResult())
                            throw new InvalidOperationException("Cant execute SELECT ROLES");
                        //UserID,RoleID,RoleName
                        List<Tuple<string, string, string>> roleslist = GetRoles(reader, userID);

                        if (!reader.NextResult())
                            throw new InvalidOperationException("Cant execute SELECT PERMISSIONS");

                        // Get Permissions by username
                        //UserID,RoleID,Permission
                        List<Tuple<string, string, string>> permissionslist = GetPermissions(reader, userID);
                        reader.Close();


                        //filled user role and permissions before return.
                        user.Username = username;

                        var rolelist = new List<Role>();

                        foreach (var roleelement in roleslist)
                        {
                            var role = new Role();

                            role.Name = roleelement.Item3.ToString();

                            var Permissionlist = new List<string>();

                            foreach (var permissionelement in permissionslist)
                            {
                                //if permission relates to role-adding permission to list belongs to role.
                                if (roleelement.Item2.ToString() == permissionelement.Item2.ToString())
                                {
                                    Permissionlist.Add(permissionelement.Item3.ToString());
                                }
                            }
                            //adding all permissions to role
                            role.Permissions = Permissionlist;
                            //adding role to role list of user
                            rolelist.Add(role);

                        }
                        user.Roles = rolelist;
                    }
                }
            }
            return user;
        }
        /// <summary>
        /// Get user roles by userID. Used by RetrieveUser(string username) method
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public List<Tuple<string, string, string>> GetRoles(IDataReader reader, string userID)
        {
            var tableofroles = new List<Tuple<string, string, string>>();

            while (reader.Read())
            {
                var getuserIDfromdb = reader["UserID"].ToString();

                if (userID == getuserIDfromdb)
                {
                    var RoleElement = new Tuple<string, string, string>(
                           reader["UserID"].ToString(),
                           reader["RoleID"].ToString(),
                           reader["RoleName"].ToString());

                    tableofroles.Add(RoleElement);
                }

            }
            return tableofroles;
        }
        /// <summary>
        /// Get user permissions by userID. Used from RetrieveUser(string username)
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Tuple<string, string, string>> GetPermissions(IDataReader reader, string userID)
        {
            var tableofpermissions = new List<Tuple<string, string, string>>();

            while (reader.Read())
            {
                var getuserIDfromdb = reader["UserID"].ToString();

                if (getuserIDfromdb == userID)
                {
                    var PermissionElement = new Tuple<string, string, string>(
                            reader["UserID"].ToString(),
                            reader["RoleID"].ToString(),
                            reader["Permissionname"].ToString());

                    tableofpermissions.Add(PermissionElement);
                }

            }
            return tableofpermissions;
        }
        /// <summary>
        /// Ger user roles. Userd by RetrieveAllUsers() method
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Tuple<string, string, string>> GetRoles(IDataReader reader)
        {
            var tableofroles = new List<Tuple<string, string, string>>();

            while (reader.Read())
            {
                var RoleElement = new Tuple<string, string, string>(
                       reader["UserID"].ToString(),
                       reader["RoleID"].ToString(),
                       reader["RoleName"].ToString());

                tableofroles.Add(RoleElement);

            }
            return tableofroles;
        }
        /// <summary>
        /// Get user permissions. Used by RetrieveAllUsers() method
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Tuple<string, string, string>> GetPermissions(IDataReader reader)
        {
            var tableofpermissions = new List<Tuple<string, string, string>>();

            while (reader.Read())
            {
                var PermissionElement = new Tuple<string, string, string>(
                        reader["UserID"].ToString(),
                        reader["RoleID"].ToString(),
                        reader["Permissionname"].ToString());

                tableofpermissions.Add(PermissionElement);
            }
            return tableofpermissions;
        }
        /// <summary>
        /// Get User by username. Used by RetrieveAllUsers() method
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public List<Tuple<string, string>> GetUser(IDataReader reader)
        {
            var tableofusers = new List<Tuple<string, string>>();

            while (reader.Read())
            {
                var UserElement = new Tuple<string, string>(
                    reader["UserID"].ToString(),
                    reader["Username"].ToString());

                tableofusers.Add(UserElement);
            }
            return tableofusers;
        }

    }
}
