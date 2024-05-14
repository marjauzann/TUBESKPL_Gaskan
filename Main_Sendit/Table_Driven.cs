using System;
namespace Main_Sendit
{
	public static class Table_Driven
    {
        public static string GetJarakdariUkuran(double Jauhjarak)
        {
            string[] status = { "Sangat Jauh", "Jauh", "Sedang", "Dekat" };
            double[] batasjarak = { 20.0, 10.0, 5.0, 0.0 };

            for (int i = 0; i < batasjarak.Length; i++)
            {
                if (Jauhjarak > batasjarak[i])
                {
                    return status[i];
                }
            }

            return "Dekat";
        }
    }
}

