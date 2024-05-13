namespace Library_Sendit.Menu
{
	public class Menu
	{
		public void header()
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
            Console.WriteLine("|                    1. Login                    |");
            Console.WriteLine("|                   2. Register                  |");
            Console.WriteLine("|                    3. Exit                     |");
            Console.WriteLine("'------------------------------------------------'");
        }
        public void menuKurir()
        {
            Console.WriteLine(",------------------------------------------------,");
            Console.WriteLine("|                   MENU KURIR                   |");
            Console.WriteLine("|                   1. Pesanan                   |");
            Console.WriteLine("|                   2. LogOut                    |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|            Pilih Opsi yang Tersedia            |");
            Console.WriteLine("'------------------------------------------------'");
        }

        public void menuPengirim()
        {
            Console.WriteLine(",------------------------------------------------,");
            Console.WriteLine("|                  MENU PENGIRIM                 |");
            Console.WriteLine("|                 1. Kirim Paket                 |");
            Console.WriteLine("|                   2. LogOut                    |");
            Console.WriteLine("|                                                |");
            Console.WriteLine("|            Pilih Opsi yang Tersedia            |");
            Console.WriteLine("'------------------------------------------------'");
        }

        public void exit()
        {
            Console.WriteLine(".------------------------------------------------.");
            Console.WriteLine("|         TERIMA KASIH TELAH MENGGUNAKAN         |");
            Console.WriteLine("|                Aplikasi SENDIT                 |");
            Console.WriteLine("|                  Sampai Jumpa                  |");
            Console.WriteLine("'------------------------------------------------'");
        }
	}
}