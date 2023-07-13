using Restaurant.DataBase;
using Restaurant.Models;
using SQLite;

namespace Restaurant.Services
{
    public class UserServices : IUserService,ICodeMessangeServices
    {
        private SQLiteAsyncConnection dbConnection;
        private const string DbName = "User.db3";
        private static string dbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

        public async Task DeleteTableAsync()
        {
            if (dbConnection != null)
            {
                await dbConnection.DropTableAsync<UserModel>();
            }
        }

        public void DeleteTable(SQLiteAsyncConnection connection)
        {
            connection.ExecuteAsync("DROP TABLE IF EXISTS UserModel");
        }
        public UserServices()
        {
            SetUpDB();
            //DeleteTable(dbConnection);
        }
        private async void SetUpDB()
        {
            if (dbConnection == null)
            {
                dbConnection = new SQLiteAsyncConnection(dbPath);
                await dbConnection.CreateTableAsync<UserModel>();
            }
        }
        public async Task AddUser(UserModel user)
        {
           await dbConnection.InsertAsync(user);
           Console.WriteLine("пользователь добавлен в базу данных");
        }
        public Task<List<UserModel>> GetUsersList()
        {
            var UserList = dbConnection.Table<UserModel>().ToListAsync();
            return UserList;
        }
        public async Task PrintUsersList()
        {
            List<UserModel> userList = await GetUsersList();
            foreach (UserModel user in userList)
            {
                Console.WriteLine($"Id: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Phone: {user.Phone}");
                Console.WriteLine($"Password: {user.Password}");
                // Выводите остальные свойства пользователя по необходимости
                Console.WriteLine("------------------------");
            }
        }
        public Task<int> RemoveUser(UserModel user)
        {
            Console.WriteLine("Удален user " + user.Phone);
            return dbConnection.DeleteAsync(user);
        }
        public async Task<int> UpdateUser(UserModel user)
        {
            var existingAccount = await dbConnection.Table<UserModel>().FirstOrDefaultAsync(a => a.Phone == user.Phone);

            if (existingAccount != null)
            {
                existingAccount.Password = user.Password;
                return await dbConnection.UpdateAsync(existingAccount);
            }

            return 0; // Возвращаем 0, если пользователь не найден
        }
        public Task<int> RemoveAllUser()
        {
            Console.WriteLine("Удалены все пользователи");
            return dbConnection.DeleteAllAsync<UserModel>();
        }
        public async Task<bool> FindUserByPhone(UserModel user)
        {
            var existingUser = await dbConnection.Table<UserModel>()
                                        .FirstOrDefaultAsync(x => x.Phone == user.Phone);
            return existingUser != null;
        }

        public void SendCode(UserModel user)
        {
            string phone = "+48" + user.Phone;
            PhoneVerification.SendCodeDB(phone);
        }

        public string CheckUser(UserModel user, string code)
        {
            var tempPhone = "+48" + user.Phone;
            var tempCode = code.Replace(" ", "");
            return PhoneVerification.CheckUser(tempPhone, tempCode);
        }

        public Task<UserModel> LogIn(UserModel user)
        {
            return dbConnection.Table<UserModel>().FirstOrDefaultAsync(x => x.Phone == user.Phone && x.Password == user.Password);
        }
        public UserModel ResetPasswordOrRegister(UserModel user, bool ResetPassword)
        {
            user.IsResetPassword = ResetPassword;
            return user;
        }

        public void DataReset(UserModel user)
        {
            user.Password = "";
            user.Name = "";
            user.Phone = "";
        }
    }
}
