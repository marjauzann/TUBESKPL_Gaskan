using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Sendit.Model
{
    public class Kurir : User
    {

        public Kurir(int ID, string namaLengkap, string username, string password, string umur) : base(namaLengkap, username, password, umur)
        {
            Contract.Requires(!int.IsPositive(ID));
            Contract.Requires(!string.IsNullOrEmpty(namaLengkap));
            Contract.Requires(!string.IsNullOrEmpty(username));
            Contract.Requires(!string.IsNullOrEmpty(password));
            Contract.Requires(!string.IsNullOrEmpty(umur));
            Contract.Ensures(this.role == Role.Kurir);

            this.role = Role.Kurir;
        }
    }
}
