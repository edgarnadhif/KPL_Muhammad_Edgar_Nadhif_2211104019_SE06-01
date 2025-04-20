using Microsoft.AspNetCore.Mvc;
using MahasiswaAPI.Models;
using System.Collections.Generic;

namespace MahasiswaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Static list menyimpan data mahasiswa
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Edgar", Nim = "1234567890" },
            new Mahasiswa { Nama = "Aufa", Nim = "1302000002" },
            new Mahasiswa { Nama = "Idham", Nim = "1302000003" }
            // Tambahkan sesuai jumlah anggota
        };

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAll()
        {
            return mahasiswaList;
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Index tidak ditemukan.");

            return mahasiswaList[index];
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhs)
        {
            mahasiswaList.Add(mhs);
            return Ok("Mahasiswa berhasil ditambahkan.");
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound("Index tidak ditemukan.");

            mahasiswaList.RemoveAt(index);
            return Ok("Mahasiswa berhasil dihapus.");
        }
    }
}
