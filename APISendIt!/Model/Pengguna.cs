using System.Diagnostics.Contracts;

namespace APISendIt_.Model
{
    public class Pengguna : User
    {
        public Pengguna(string namaLengkap, string username, string password, string umur) : base(namaLengkap, username, password, umur)
        {
            Contract.Requires(!string.IsNullOrEmpty(namaLengkap));
            Contract.Requires(!string.IsNullOrEmpty(username));
            Contract.Requires(!string.IsNullOrEmpty(password));
            Contract.Requires(!string.IsNullOrEmpty(umur));
            Contract.Ensures(this.role == Role.Pengguna);

            this.role = Role.Pengguna;
        }
    }
}
