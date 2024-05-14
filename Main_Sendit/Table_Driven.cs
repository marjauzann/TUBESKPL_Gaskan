using System;
namespace Main_Sendit
{
	public static class Table_Driven
    {

        public static string GetJarakdariUkuran(double Jauhjarak)
        {
            string[] status = {"Sangat Jauh", "Jauh", "Sedang", "Dekat"};
            double[] batasjarak = {20.0, 10.0, 5.0, 0.0};
            int JarakMaksimal = status.Length - 1;

            string StatusJarak = "Dekat";
            double Jarak = 0;

            while ((StatusJarak = "Dekat") && (Jarak < JarakMaksimal)) {
                if (Jauhjarak > batasjarak[jarak])
                {
                    StatusJarak = status[Jarak];
                }
                Jarak++;
            }

            return StatusJarak;
        }
    }
}

