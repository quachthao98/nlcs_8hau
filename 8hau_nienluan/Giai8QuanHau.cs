using System;

namespace _8hau_nienluan
{
    class Giai8QuanHau
    {
        private static int[,,] ketqua = new int[100, 8, 8];
        private static int sttBanCo = 0;

        static void inbanco(int[,] banco)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // Console.Write("{0} ", banco[i, j]);// draw (image)
                    ketqua[sttBanCo, i, j] = banco[i, j];
                }
                // Console.WriteLine();//xóa
            }
            sttBanCo++;
            // Console.WriteLine();
            // Console.ReadLine();// bỏ luôn
        }
        static bool kiemtracot(int[,] banco, int h, int c)
        {
            for (int i = h - 1; i >= 0; i--)
            {
                if (banco[i, c] == 1)
                {
                    return false;
                }
            }
            return true;
        }
        static bool kiemtracheotrai(int[,] banco, int h, int c)
        {
            for (int i = h - 1, j = c - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (banco[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }


        static bool kiemtracheophai(int[,] banco, int h, int c)
        {
            for (int i = h - 1, j = c + 1; i >= 0 && j <= 7; i--, j++)
            {
                if (banco[i, j] == 1)
                {
                    return false;
                }
            }
            return true;
        }
        static bool hople(int[,] banco, int h, int c)
        {
            if (!kiemtracot(banco, h, c))
                return false;
            if (!kiemtracheotrai(banco, h, c))
                return false;
            if (!kiemtracheophai(banco, h, c))
                return false;
            return true;
        }
        static void xephau(int[,] banco, int i)
        {
            if (i == 8)
            {
                // in kq
                inbanco(banco);
                return;
            }
            for (int j = 0; j < 8; j++)
            {
                if (hople(banco, i, j))
                {
                    banco[i, j] = 1;
                    xephau(banco, i + 1);
                    banco[i, j] = 0;
                }
            }
        }
        public static void reset()
        {
            sttBanCo = 0;
        }
        public static int[,,] giaiBaiToan()
        {
            int[,] banco = new int[8, 8];
            xephau(banco, 0);
            return ketqua;
        }
    }
}
