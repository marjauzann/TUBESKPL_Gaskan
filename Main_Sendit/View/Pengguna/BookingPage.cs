using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Main_Sendit.Model;
using System.Net.Http;

namespace Main_Sendit.View.Pengguna
{
    public class BookingPage
    {
        public static HttpClient client = new HttpClient();

        public static string urlLocalPengguna = "http://localhost:5247/api/Pengguna";
        public static string urlLocalKurir = "http://localhost:5247/api/Kurir";

        public static DateTime bookingDate { get; set; }

        public BookingPage()
        {

            LoadDataKurir();
            GetDataPengguna();
        }
        private async void LoadDataKurir()
        {
            try
            {
                var response = await client.GetAsync(urlLocalKurir);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                Console.WriteLine(data);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Loading Data");
            }
        }

        private async void GetDataPengguna() 
        {
            var response = await client.GetAsync(urlLocalPengguna);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{data}");
        }
    }
}
