using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace study
{


    public partial class Form1 : Form
    {

       

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CSvar obj = new CSvar();
            obj.globalVar = 1;
            obj.Method();

            //배열 선언 
            string[] player = new string[10];
            string[] regions = { "a", "b", "c" };

            string[,] Depts = { { "1", "2" }, { "3", "4" } };

            // 가변 배열
            int[][] A = new int[3][];

            A[0] = new int[2];
            A[1] = new int[3] { 1, 2, 3 };
            A[2] = new int[4] { 1, 2, 3, 4 };

            A[0][0] = 1;
            A[0][1] = 2;

            //배열 사용 법 
            int sum = 0;
            int[] scores = { 1, 2, 3, 4, 5 };

            int temp = CalculateSum(scores);

            for(int i0 = 0; i0 < scores.Length; i0++)
            {
                sum += scores[i0];
            }

            // string 는 고정문자에 사용
            // stringBuilder는 가변 문자에 사용 
            //문자열 
            string s = "abcdefg";
            string strtemp;
            for (int i1 = 0; i1 < s.Length; i1++)
                strtemp = string.Format("{0} {1}", i1, s[i1]);

            string s1 = "hello";
            char[] chararray = s1.ToCharArray(); // 문자 배열로 넣는 함수 

            char[] chararray2 = { 'a', 'b', 'c' };
            string s2 = new string(chararray2);

            char c1 = 'a';
            char c2 = (char)(c1 + 3);


            StringBuilder sb = new StringBuilder();
            for(int i2 = 0; i2 < 26; i2++)
            {
                sb.Append(i2.ToString());
                sb.Append(System.Environment.NewLine);
            }

            string s3 = sb.ToString();

            // 널러블은 언제 쓰이나? -> 값의 할당 여부를 확인 할때 
            int? i = null;
            i = i ?? 0;

            string s4 = null;
            s4 = s ?? string.Empty;

            // 조건
            string option = "1";
            switch (option)
            {
                case "1":
                    break;
                case "2":
                    break;
                default:
                    break;

            }

            // 배열 
            string[] array = new string[] { "1", "2", "3" };

            foreach( string s7 in array)
            {
                string strtemp1 = string.Format("{0}", s7);
            }


            string[,,] arr = new string[,,]
            {
                { {"1","1" },  {"1","1" }},
                { { "1","1" },  { "1","1" } }
            };




        }

        static int CalculateSum(int[] scoresArray)
        {
            int sum = 0;
            for (int i = 0; i < scoresArray.Length; i++)
                sum += scoresArray[i];

            return sum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = new MyList();

            foreach(var item in list)
            {
                string strtemp = string.Format("{0}", item);
                MessageBox.Show(strtemp);
            }

            /*
            try
            {
                //do something
            }
            catch( Exception ex)
            {
                //Log(ex)
                throw;
            }

            try
            {
            }
            catch (ArgumentException ex)
            {
            }
            catch (AccessViolationException ex)
            {
            }
            finally
            { }

            string connstr = "Data Source = (local); Integrated Security = true";
            string sql = "SELECT COUNT(1) FROM sys.objects";
            SqlConnection conn = null; 
            */


        }
    }

    public class MyList
    {
        private int[] data = { 1, 2, 3, 4, 5, 6 };
        public IEnumerator GetEnumerator()
        {
            int i = 0; 
            while(i < data.Length)
            {
                yield return data[i];
                i++;
            }
        }
    }

    public class CSvar
    {
        public int globalVar;
        public const int MAX_VALUE = 1024;

        public void Method()
        {
            int localVar;
            localVar = 100;

            string strtemp = string.Format("{0}", globalVar);

            MessageBox.Show(strtemp);

        }
    }

    public class mymath
    {

        public int Calculate(int a, int b)
        {
            int abs_sum = System.Math.Abs(a) + Math.Abs(b);
            return abs_sum;
        }
    }
}
