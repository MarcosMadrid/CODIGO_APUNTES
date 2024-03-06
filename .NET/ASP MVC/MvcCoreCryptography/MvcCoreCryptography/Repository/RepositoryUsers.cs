using Microsoft.EntityFrameworkCore;
using MvcCoreCryptography.Data;
using MvcCoreCryptography.Helpers;
using MvcCoreCryptography.Models;

namespace MvcCoreCryptography.Repository
{
    public class RepositoryUsers
    {
        UsersContext context;
        public RepositoryUsers(UsersContext users)
        {
            this.context = users;
        }

        private async Task<int> GetMaxIdUser()
        {
            if (context.Users.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Users.MaxAsync(user => user.IdUsuario) + 1;
            }
        }

        public async Task Register(string nombre, string email, string password, string imagen)
        {
            User user = new User
            {
                IdUsuario = await this.GetMaxIdUser(),
                Email = email,
                Nombre = nombre,
                Imagen = imagen,
                Salt = HelperCryptography.GenerateSalt(),
            };
            user.Password = HelperCryptography.EncryptPassword(password, user.Salt);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<User?> LogIn(string email, string password)
        {
            User? user = await this.context.Users.FirstOrDefaultAsync(userRow => userRow.Email.Equals(email));

            if (user == null)
            {
                return user;
            }

            string salt = user.Salt;
            byte[] temp = HelperCryptography.EncryptPassword(password, salt);
            byte[] passUser = user.Password;
            bool response = HelperCryptography.CompareArrays(temp, passUser);

            if (!response)
            {
                return null;
            }
            return user;
        }
    }
}
