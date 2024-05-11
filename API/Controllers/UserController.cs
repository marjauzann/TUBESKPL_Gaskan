using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private List<User> users = new List<User>(); // Simpan data pengguna di sini. Ini sementara, Anda mungkin ingin menyimpannya di database.

            // GET: api/<UserController>
            [HttpGet]
            public IEnumerable<User> Get()
            {
                return users;
            }

            // GET api/<UserController>/5
            [HttpGet("{id}")]
            public ActionResult<User> Get(int id)
            {
                var user = users.Find(u => u.id == id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }

            // POST api/<UserController>
            [HttpPost]
            public IActionResult Post([FromBody] User newUser)
            {
                // Validasi uniknya id atau email atau field lain yang menurut Anda unik
                var existingUser = users.Find(u => u.id == newUser.id);
                if (existingUser != null)
                {
                    return Conflict("User already exists.");
                }

                // Simpan user ke dalam daftar
                users.Add(newUser);
                return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);
            }

            // POST api/<UserController>/login
            [HttpPost("login")]
            public IActionResult Login([FromBody] User loginUser)
            {
                // Cari pengguna berdasarkan kriteria yang sesuai, seperti id, nama pengguna, atau email
                var user = users.Find(u => u.nama == loginUser.nama && u.id == loginUser.id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Validasi kata sandi, Anda mungkin perlu menambahkan properti kata sandi ke kelas User
                // Contoh: if (user.Password != loginUser.Password)
                // {
                //     return Unauthorized("Invalid password.");
                // }

                // Jika semuanya valid, Anda dapat mengembalikan informasi pengguna atau token akses di sini
                return Ok(user);
            }

            // PUT api/<UserController>/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] User updatedUser)
            {
                var existingUser = users.Find(u => u.id == id);
                if (existingUser == null)
                {
                    return NotFound();
                }

                // Lakukan update properti yang sesuai
                existingUser.nama = updatedUser.nama;
                existingUser.role = updatedUser.role;
                existingUser.tgl_lahir = updatedUser.tgl_lahir;

                return NoContent();
            }

            // DELETE api/<UserController>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var userToDelete = users.Find(u => u.id == id);
                if (userToDelete == null)
                {
                    return NotFound();
                }

                users.Remove(userToDelete);
                return NoContent();
            }
        }
        // GET: api/<UserController>
    }
