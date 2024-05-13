using System.Diagnostics.Contracts;

namespace APISendIt_.Model
{
        public class Kurir : User
        {

            public Kurir(string namaLengkap, string username, string password, string umur) : base(namaLengkap, username, password, umur)
            {
                Contract.Requires(!string.IsNullOrEmpty(namaLengkap));
                Contract.Requires(!string.IsNullOrEmpty(username));
                Contract.Requires(!string.IsNullOrEmpty(password));
                Contract.Requires(!string.IsNullOrEmpty(umur));
                Contract.Ensures(this.role == Role.Kurir);

                this.role = Role.Kurir;
            }
        }
 }
