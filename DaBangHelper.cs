using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaBang
{
    public class DaBangHelper
    {
        char[] bangChuCai = new char[] { 'e', 'w', 'q', 'r', 't', 'u', 'i', 'o', 'p', 
            'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
        char[,] bangTra;
        public String khoa { get; set; }

        public DaBangHelper()
        {
            bangTra = new char[bangChuCai.Length, bangChuCai.Length];
            for (int i = 0; i < bangChuCai.Length; i++)
                for (int j = 0; j < bangChuCai.Length; j++)
                    bangTra[i, j] = bangChuCai[(i + j) % bangChuCai.Length];
        }

        public String MaHoa(String value)
        {
            // Sinh khóa
            Random rd = new Random();
            for (int i = 0; i < value.Length; i++)
                khoa += bangChuCai[rd.Next(0, bangChuCai.Length - 1)];

            // Mã hóa
            String result = "";
            for(int i = 0; i < value.Length; i++)
            {
                int viTri = -1;
                for(int j = 0; j < bangChuCai.Length; j++)
                {
                    if(bangChuCai[j].ToString().Equals(value[i].ToString()))
                    {
                        viTri = j;
                        break;
                    }    
                }

                if (viTri == -1)
                    result += value[i].ToString();
                else
                {
                    int viTriKhoa = 0;
                    for(int j = 0; j < bangChuCai.Length; j++)
                    {
                        if(bangChuCai[j].ToString().Equals(khoa[i].ToString()))
                        {
                            viTriKhoa = j;
                            break;
                        }    
                    }
                    result += bangTra[viTri, viTriKhoa];
                }    
            }
            return result;
        }

        public String GiaiMa(String value, String key)
        {
            String result = "";
            for (int i = 0; i < value.Length; i++)
            {
                int viTri = -1;
                for (int j = 0; j < bangChuCai.Length; j++)
                {
                    if (bangChuCai[j].ToString().Equals(value[i].ToString()))
                    {
                        viTri = j;
                        break;
                    }
                }

                if (viTri == -1)
                    result += value[i].ToString();
                else
                {
                    // Xac dinh ky tu khoa tai vị trí thứ i
                    char ktKhoa = key[i];

                    // Xác định vị trí của ký tự khóa trong bảng chữ cái
                    int viTriKhoa = 0;
                    for(int j = 0; j < bangChuCai.Length; j++)
                    {
                        if(bangChuCai[j].Equals(ktKhoa))
                        {
                            viTriKhoa = j;
                            break;
                        }    
                    }

                    // Tìm trong hàng hoặc cột thứ (vị trí khóa) ở bảng tra xem giá trị cần giải mã ở vị trí nào
                    // --> thì giá trị giải mã được là ký tự ở vị trí đố trong bảng chữ cái
                    int viTriGiaiMa = 0;
                    for(int j = 0; j < bangChuCai.Length; j++)
                    {
                        if(bangTra[viTriKhoa, j].Equals(value[i]))
                        {
                            viTriGiaiMa = j;
                            break;
                        }    
                    }
                    result += bangChuCai[viTriGiaiMa];
                }
            }
            return result;
        }
    }
}
