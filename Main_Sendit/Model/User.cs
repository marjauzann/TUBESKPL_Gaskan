using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Sendit.Model
{
        public enum Role
        {
            Kurir,
            Pengguna
        }

    public class User
    {
        public int Id { get; set; }
        public string NamaLengkap { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string umur { get; set; }
        public Role role { get; set; }

        public User(string namaLengkap, string username, string password, string umur)
        {
            Contract.Requires(!string.IsNullOrEmpty(namaLengkap));
            Contract.Requires(!string.IsNullOrEmpty(username));
            Contract.Requires(!string.IsNullOrEmpty(password));
            Contract.Requires(!string.IsNullOrEmpty(umur));
            Contract.Requires(umur.All(char.IsDigit));
            Contract.Ensures(this.NamaLengkap == namaLengkap);
            Contract.Ensures(this.userName == username);
            Contract.Ensures(this.password == password);
            Contract.Ensures(this.umur == umur);

            Random random = new Random();
            this.NamaLengkap = namaLengkap;
            this.userName = username;
            this.umur = umur;
            this.Id = random.Next();
            this.password = password;

        }
    }
}
