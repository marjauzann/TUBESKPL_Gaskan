using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using 

namespace APISendIt_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenggunaController : ControllerBase
    {
        public static List<Pengguna> PenggunaData = new List<Pengguna>
        {
            new Pengguna("Budi Yanto", "budiyanto", "password123", "27"),
            new Pengguna("Bob Sadino", "bobsadino", "password456", "55"),
            new Pengguna("Jonny Cage", "jonnycage", "password789", "39")
        };

        [HttpGet]
        public IEnumerable<Pengguna> Get()
        {
            Debug.Assert(PenggunaData != null, "Data Pengguna tidak boleh kosong");
            return PenggunaData;
        }

        [HttpGet("{id}")]
        public Pengguna? Get(int id)
        {
            Debug.Assert(id > 0, "ID haruslah bilangan bulat positif");

            for (int i = 0; i < PenggunaData.Count; i++)
            {
                if (PenggunaData[i].Id == id)
                {
                    return PenggunaData[i];
                }
            }

            return null;
        }

        [HttpPost]
        public void Post([FromBody] Pengguna value)
        {
            Debug.Assert(value != null, "Nilai tidak boleh kosong");
            PenggunaData.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pengguna value)
        {
            Debug.Assert(id > 0, "ID haruslah bilangan bulat positif");
            Debug.Assert(value != null, "Nilai tidak boleh kosong");

            for (int i = 0; i < PenggunaData.Count; i++)
            {
                if (PenggunaData[i].Id == id)
                {
                    PenggunaData[i] = value;
                    return;
                }
            }

            Debug.Fail("Pengguna dengan ID tersebut tidak ditemukan");
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Debug.Assert(id > 0, "ID haruslah bilangan bulat positif");

            for (int i = 0; i < PenggunaData.Count; i++)
            {
                if (PenggunaData[i].Id == id)
                {
                    PenggunaData.RemoveAt(i);
                    return;
                }
            }

            Debug.Fail("Pengguna dengan ID tersebut tidak ditemukan");
        }
    }
}
