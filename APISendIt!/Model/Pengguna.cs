using System.Diagnostics.Contracts;

namespace APISendIt_.Model
{
    public class Pengguna : User
    {
        public Pengguna(int ID, string namaLengkap, string username, string password, string umur) : base(namaLengkap, username, password, umur)
        {
            Contract.Requires(!int.IsPositive(ID));
            Contract.Requires(!string.IsNullOrEmpty(namaLengkap));
            Contract.Requires(!string.IsNullOrEmpty(username));
            Contract.Requires(!string.IsNullOrEmpty(password));
            Contract.Requires(!string.IsNullOrEmpty(umur));
            Contract.Ensures(this.role == Role.Pengguna);

            this.role = Role.Pengguna;
        }
    }
}
