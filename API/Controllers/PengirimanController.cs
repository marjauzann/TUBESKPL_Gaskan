using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PengirimanController : ControllerBase
    {
        private static List<Pengiriman> daftarPengiriman = new List<Pengiriman>();

        // GET: api/Pengiriman
        [HttpGet]
        public IEnumerable<Pengiriman> Get()
        {
            return daftarPengiriman;
        }

        // GET api/Pengiriman/5
        [HttpGet("{id}")]
        public ActionResult<Pengiriman> Get(int id)
        {
            var pengiriman = daftarPengiriman.Find(p => p.idPengiriman == id);
            if (pengiriman == null)
            {
                return NotFound();
            }
            return pengiriman;
        }

        // POST api/Pengiriman
        [HttpPost]
        public ActionResult<Pengiriman> Post([FromBody] Pengiriman pengiriman)
        {
            if (pengiriman == null)
            {
                return BadRequest("Data pengiriman tidak valid");
            }

            pengiriman.idPengiriman = GenerateId();
            daftarPengiriman.Add(pengiriman);
            return CreatedAtAction(nameof(Get), new { id = pengiriman.idPengiriman }, pengiriman);
        }

        // PUT api/Pengiriman/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pengiriman pengiriman)
        {
            var existingPengiriman = daftarPengiriman.Find(p => p.idPengiriman == id);
            if (existingPengiriman == null)
            {
                return NotFound();
            }

            // Update properties based on the received pengiriman object
            existingPengiriman.nama_pengirim = pengiriman.nama_pengirim;
            existingPengiriman.nomor_pengirim = pengiriman.nomor_pengirim;
            existingPengiriman.tujuan = pengiriman.tujuan;
            existingPengiriman.beratBarang = pengiriman.beratBarang;
            existingPengiriman.nama_penerima = pengiriman.nama_penerima;
            existingPengiriman.tanggal_pengiriman = pengiriman.tanggal_pengiriman;
            existingPengiriman.tanggal_tiba = pengiriman.tanggal_tiba;

            return NoContent();
        }

        // DELETE api/Pengiriman/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pengiriman = daftarPengiriman.Find(p => p.idPengiriman == id);
            if (pengiriman == null)
            {
                return NotFound();
            }

            daftarPengiriman.Remove(pengiriman);
            return NoContent();
        }

        private int GenerateId()
        {
            // In a real-world scenario, you might want to implement a more robust method to generate unique IDs.
            // For simplicity, this example uses a random number generator.
            return new Random().Next(1, 1000);
        }
    }
}
