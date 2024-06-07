using Main_Sendit.View.Pengguna;
using System;
using System.Collections.Generic;
using Main_Sendit.Model;

class Program
{
    static List<User> pengguna = new List<User>();
    static List<Order> pesanan = new List<Order>();
    static User penggunaSaatIni;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine(",________________________________________________,");
            Console.WriteLine("|   __________      __________      __________   |");
            Console.WriteLine("|  |   |  |   |    |   |  |   |    |   |  |   |  |");
            Console.WriteLine("|  |   |__|   |    |   |__|   |    |   |__|   |  |");
            Console.WriteLine("|  |          |    |          |    |          |  |");
            Console.WriteLine("|  |          |    |          |    |          |  |");
            Console.WriteLine("|  |__________|    |__________|    |__________|  |");
            Console.WriteLine("|------------------------------------------------|");
            Console.WriteLine("|           Aplikasi Pengiriman Barang           |");
            Console.WriteLine("|                     SENDIT                     |");
            Console.WriteLine("|           Created By Kelompok Gaskan           |");
            Console.WriteLine("|          Naswan, Nizar, Theo, & Hasan          |");
            Console.WriteLine("|     Tugas Besar Konstruksi Perangkat Lunak     |");
            Console.WriteLine("|------------------------------------------------|");
            Console.WriteLine("| +  +  +  +  +  +  +  +  +  +  +  +  +  +  +  + |");
            Console.WriteLine("|           Pilihlah Menu Dibawah Ini!           |");
            Console.WriteLine("| +  +  +  +  +  +  +  +  +  +  +  +  +  +  +  + |");
            Console.WriteLine("|------------------------------------------------|");
            Console.WriteLine("|                      MENU                      |");
            Console.WriteLine("|                   1. Daftar                    |");
            Console.WriteLine("|                   2. Masuk                     |");
            Console.WriteLine("|                   3. Keluar                    |");
            Console.WriteLine("'------------------------------------------------'");
            Console.Write("Pilih opsi: ");
            int opsi = Convert.ToInt32(Console.ReadLine());

            switch (opsi)
            {
                case 1:
                    Daftar();
                    break;
                case 2:
                    Masuk();
                    break;
                case 3:
                    Console.WriteLine(".------------------------------------------------.");
                    Console.WriteLine("|         TERIMA KASIH TELAH MENGGUNAKAN         |");
                    Console.WriteLine("|                Aplikasi SENDIT                 |");
                    Console.WriteLine("|                  Sampai Jumpa                  |");
                    Console.WriteLine("'------------------------------------------------'");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }
        }
    }

    static void Masuk()
    {
        Console.Write("Masukkan nama pengguna: ");
        string namaPengguna = Console.ReadLine();
        Console.Write("Masukkan kata sandi: ");
        string kataSandi = Console.ReadLine();

        // Periksa kredensial pengguna
        foreach (User pengguna in pengguna)
        {
            if (pengguna.Username == namaPengguna && pengguna.Password == kataSandi)
            {
                penggunaSaatIni = pengguna;
                Console.WriteLine("Masuk berhasil!");
                if (penggunaSaatIni.Role == Role.Pengirim)
                {
                    MenuPengirim();
                }
                else if (penggunaSaatIni.Role == Role.Kurir)
                {
                    MenuKurir();
                }
                return;
            }
        }
        Console.WriteLine("Nama pengguna atau kata sandi salah.");
    }

    static void Daftar()
    {
        Console.Write("Masukkan nama pengguna: ");
        string namaPengguna = Console.ReadLine();
        Console.Write("Masukkan kata sandi: ");
        string kataSandi = Console.ReadLine();
        Console.Write("Masukkan peran (Pengirim/Kurir): ");
        Role peran = (Role)Enum.Parse(typeof(Role), Console.ReadLine());

        pengguna.Add(new User { Username = namaPengguna, Password = kataSandi, Role = peran });
        Console.WriteLine("Pendaftaran berhasil!");
    }

    static void MenuPengirim()
    {
        while (true)
        {
            Console.WriteLine("1. Kirim paket");
            Console.WriteLine("2. Lihat pesanan");
            Console.WriteLine("3. Keluar");
            Console.Write("Pilih opsi: ");
            int opsi = Convert.ToInt32(Console.ReadLine());

            switch (opsi)
            {
                case 1:
                    KirimPaket();
                    break;
                case 2:
                    LihatPesanan();
                    break;
                case 3:
                    penggunaSaatIni = null;
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }
        }
    }

    static void KirimPaket()
    {
        Console.WriteLine("Masukkan detail pengirim:");
        Console.Write("Nama: ");
        string namaPengirim = Console.ReadLine();
        Console.Write("Alamat: ");
        string alamatPengirim = Console.ReadLine();
        Console.Write("Nomor telepon: ");
        string teleponPengirim = Console.ReadLine();

        Console.WriteLine("Masukkan detail penerima:");
        Console.Write("Nama: ");
        string namaPenerima = Console.ReadLine();
        Console.Write("Alamat: ");
        string alamatPenerima = Console.ReadLine();
        Console.Write("Nomor telepon: ");
        string teleponPenerima = Console.ReadLine();

        Console.Write("Masukkan detail paket:");
        Console.Write("Tipe: ");
        string tipePaket = Console.ReadLine();
        Console.Write("Berat (kg): ");
        double beratPaket = Convert.ToDouble(Console.ReadLine());

        Console.Write("Masukkan jarak (km): ");
        double jarak = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Pilih metode pembayaran:");
        Console.WriteLine("1. Transfer bank");
        Console.WriteLine("2. QRIS");
        int opsiPembayaran = Convert.ToInt32(Console.ReadLine());

        bool sudahDibayar = false;
        if (opsiPembayaran == 1 || opsiPembayaran == 2)
        {
            double harga = jarak * 5000;

            Console.WriteLine($"Harga: {harga}");

            Console.WriteLine("1. Sudah dibayar");
            Console.WriteLine("2. Belum dibayar");
            int opsiDibayar = Convert.ToInt32(Console.ReadLine());
            sudahDibayar = opsiDibayar == 1;

            Order pesananBaru = new Order
            {
                Pengirim = penggunaSaatIni,
                NamaPengirim = namaPengirim,
                AlamatPengirim = alamatPengirim,
                TeleponPengirim = teleponPengirim,
                NamaPenerima = namaPenerima,
                AlamatPenerima = alamatPenerima,
                TeleponPenerima = teleponPenerima,
                TipePaket = tipePaket,
                BeratPaket = beratPaket,
                Jarak = jarak,
                Harga = harga,
                SudahDibayar = sudahDibayar,
                Status = "Pending"
            };
            pesanan.Add(pesananBaru);

            Console.WriteLine("Pesanan berhasil ditambahkan!");
        }
        else
        {
            Console.WriteLine("Opsi pembayaran tidak valid.");
        }
    }

    static void LihatPesanan()
    {
        Console.WriteLine("Pesanan Anda:");
        foreach (Order pesanan in pesanan)
        {
            if (pesanan.Pengirim.Username == penggunaSaatIni.Username)
            {
                Console.WriteLine(pesanan.ToString());
            }
        }
    }

    static void MenuKurir()
    {
        while (true)
        {
            Console.WriteLine("1. Pesanan saya");
            Console.WriteLine("2. Keluar");
            Console.Write("Pilih opsi: ");
            int opsi = Convert.ToInt32(Console.ReadLine());

            switch (opsi)
            {
                case 1:
                    LihatPesananKurir();
                    break;
                case 2:
                    penggunaSaatIni = null;
                    return;
                default:
                    Console.WriteLine("Opsi tidak valid.");
                    break;
            }
        }
    }

    static void LihatPesananKurir()
    {
        Console.WriteLine("Pesanan Anda:");
        foreach (Order pesanan in pesanan)
        {
            if (pesanan.Status != "Diterima")
            {
                Console.WriteLine(pesanan.ToString());
                Console.Write("Perbarui status pesanan (Diambil/Dikirim/Diterima): ");
                string status = Console.ReadLine();
                pesanan.Status = status;
                Console.WriteLine("Status pesanan berhasil diperbarui!");
                return;
            }
        }
        Console.WriteLine("Tidak ada pesanan yang sedang berjalan.");
    }
}

enum Role
{
    Pengirim,
    Kurir
}

class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}

class Order
{
    public User Pengirim { get; set; }
    public string NamaPengirim { get; set; }
    public string AlamatPengirim { get; set; }
    public string TeleponPengirim { get; set; }
    public string NamaPenerima { get; set; }
    public string AlamatPenerima { get; set; }
    public string TeleponPenerima { get; set; }
    public string TipePaket { get; set; }
    public double BeratPaket { get; set; }
    public double Jarak { get; set; }
    public double Harga { get; set; }
    public bool SudahDibayar { get; set; }
    public string Status { get; set; }

    public override string ToString()
    {
        return $"Pengirim: {NamaPengirim}, Penerima: {NamaPenerima}, Jarak: {Jarak} km, Harga: {Harga}, Status: {Status}";
    }
}