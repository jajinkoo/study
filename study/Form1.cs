﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using MyExtension;





namespace study
{
    delegate int Compare<T>(T a, T b);
    delegate void ThereIsAFire(string location);
    delegate int Calulate(int i, int j);
    delegate int Calulate2(int a, int b);
    delegate string Concatenate(string[] args);

    public partial class Form1 : Form
    {

        private void button7_Click(object sender, EventArgs e)
        {
            // Calulate2 calc2 = (a, b) => a + b;

            Concatenate concat = (arr) =>
            {
                string strtemp = "";
                foreach (string s in arr)
                    strtemp += s;
                return strtemp;
            };

            Func<int> func1 = () => 10;
            Func<int, int> func2 = (x) => x * 2;
            Func<double, double, double> func3 = (x, y) => x / y;

            // 확장 메소드 
            int ss = 3.squre();

        }




        void Call119(string location)
        {
            string strtemp = "119";
        }

        void ShotOut(string location)
        {
            string strtemp = "shot";
        }
        
        void Escape(string location)
        {
            string strtemp = "escape";
        }


        static int AscendCompare<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b);
            /*
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1; */
        }
        static int DescendCompare<T>(T a, T b) where T: IComparable<T>
        {
            return a.CompareTo(b) * -1;
            /*
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1; 
            */
        }

        static void BubbleSort<T>(T[] DataSet, Compare<T> compare)
        {
            int i = 0;
            int j = 0;
            T ntemp11;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = i + 1; j < DataSet.Length; j++)
                {
                    if(compare(DataSet[i], DataSet[j]) > 0)
                    {
                        ntemp11 = DataSet[j];
                        DataSet[j] = DataSet[i];
                        DataSet[i] = ntemp11;
                    }
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

            //delegate 1
            int[] a = { 3, 7, 4, 2, 10 };

            BubbleSort<int>(a, new Compare<int>(AscendCompare));

            double[] b = { 8, 4, 1, 0, 2 };

            BubbleSort<double>(b, new Compare<double>(DescendCompare));

            //람다식
            Calulate calc = (i, j) => i + j;
            Calulate calc2 = delegate (int i, int j)
            {
                return i + j;
            };

             //delegate 2
             ThereIsAFire fire = new ThereIsAFire(Call119);
            fire += new ThereIsAFire(ShotOut);
            fire += new ThereIsAFire(Escape);

            fire("my");


        }

        double d_sum = 0;
        DateTime _time;
        bool? _Selected;

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

            int kk = 0;
            double jj = 0;
            DateTime dt = new DateTime();
            bool? b = true;

            CheckInput(kk, jj, dt, b);

            //레퍼런스 
            int test1 = 0;
            int test2 = 1;

            int test3 = testRefFunc(ref test1, ref test2);

            //param
            int s = testparam(1, 2, 3, 4);
            int t = testparam(1, 2, 3, 4, 5, 6, 7);

            
        }
        public int testparam(params int[] values)
        {
            int sum = 0; 
            foreach(int a in values)
            {
                sum += a;
            }
            return sum; 
        }

        public int testRefFunc(ref int a, ref int b)
        {
            return a + b;
        }
        public void CheckInput( int? i, double? d, DateTime? time, bool? selected)
        {

            if (i.HasValue && d.HasValue)
                d_sum = (double)i.Value + (double)d.Value;

            if (!time.HasValue)
                throw new ArgumentException();
            else
                _time= time.Value;

            selected = selected ?? false;

        }
        void NullableTest()
        {
            int? a = null;
            int? b = 0;
            int result = Nullable.Compare<int>(a, b);

            double? c = 0.01;
            double? d = 0.0001;
            bool result2 = Nullable.Equals<double>(c, d);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //indexxer
            MyIndexer indexer = new MyIndexer();

            for(int i1 = 0; i1< 10; i1++)
            {
                indexer[i1] = i1; 
            }

            for (int i2 = 0; i2 < indexer.Length; i2++)
            {
                string temp = string.Format("size{0}", indexer[i2]);


            }

            //static 메서드 
            MyClass myClass = new MyClass();
            int i3 = myClass.InstRun();

            int j = MyClass.Run();

            /// static class
            string str = MyUtility.Convert(123);
            int i5 = MyUtility.ConvertBack(str);

            //as is

            MyClass1 c = new MyClass1();
            new Form1().Test(c);

            //제너렉 
            MyStack<int> numberStack = new MyStack<int>();
            MyStack<string> nameStack = new MyStack<string>();

            List<string> nameList = new List<string>();
            nameList.Add("1");

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic["1"] = 100; 

        }

        public void Test(object obj)
        {
            MyBase a = obj as MyBase;

            bool ok = obj is MyBase;

            MyBase b = (MyBase)obj;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            climateMonitor monitor = new climateMonitor(new FileLogger("Mylog.txt"));

            monitor.start();
        }




        private void button5_Click(object sender, EventArgs e)
        {
            int[] a = { 5, 53, 3, 7, 1 };
            MySort.CompareDelegate compDelegate = AscendingCompare;
            MySort.Sort(a, compDelegate);


            compDelegate = DescendingCompare;
            MySort.Sort(a, compDelegate);

        }

        int AscendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i2 - i1) > 0 ? 1 : -1;
        }

        int DescendingCompare(int i1, int i2)
        {
            if (i1 == i2) return 0;
            return (i1 - i2) > 0 ? 1 : -1;
        }


        async static private void MyMethodAsync(int count)
        {
            string strtemp = string.Format("c");

            MessageBox.Show(strtemp);

            strtemp = string.Format("d");
            MessageBox.Show(strtemp);

            await Task.Run(async () =>
            {
                for (int i = 0; i < count; i++)
                {
                    strtemp = string.Format("{0}", (double)i/(double)count);
                    MessageBox.Show(strtemp);
                    await Task.Delay(100);
                }
            }
            );
        }


        static void Caller()
        {
            string strtemp = string.Format("a");
            MessageBox.Show(strtemp);

            strtemp = string.Format("b");
            MessageBox.Show(strtemp);

            MyMethodAsync(3);

            strtemp = string.Format("e");
            MessageBox.Show(strtemp);

            strtemp = string.Format("f");
            MessageBox.Show(strtemp);

        }




        private void button8_Click(object sender, EventArgs e)
        {
            Caller();
        }

        static async Task<long> CopyAsync(string str1st, string str2nd)
        {

            using (var fromStream = new FileStream(str1st, FileMode.Open))
            {
                long totalcopy = 0;
                using (var ToStream = new FileStream(str2nd, FileMode.Open))
                {
                    byte[] buffer = new byte[1024];
                    int nRead = 0;
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        await ToStream.WriteAsync(buffer, 0, nRead);
                        totalcopy += nRead;
                    }
                }

                return totalcopy;
            }

           
        }


        static async void DoCopy(string str1st, string str2nd)
        {
            long totalcopy = await CopyAsync(str1st, str2nd);

            string strtemp = string.Format("{0}", totalcopy);
        }



        private void button9_Click(object sender, EventArgs e)
        {
            // async 비동기화 방식 이걸 사용하는 그림을 알고있어야함 
            string strfirst = string.Format("");
            string strsecond = string.Format("");

            DoCopy(strfirst, strsecond);
        }

        

        private void button10_Click(object sender, EventArgs e)
        {

            // 패턴 매칭 
            object[] data = { 1, null, 10, 20.1 };

            foreach (var item in data)
            {
                if (item is null)
                {
                    int x = 0; 
                }
                else if (item is 10)
                {
                    int x = 0;
                }
                else if (item is 20.1)
                {
                    int x = 0;
                }
            }

            //null able 
            int? a = null;

            if (a == null)
            {
                int x = a ?? 1;
            }
            else
            {

            }

            Rectangle r = new Rectangle();
            r.Height = 10;
            r.Width = 20;

            string strtemp = $"{{r.Height}} * {{r.Width}} = {(r.Height * r.Width)}";
            MessageBox.Show(strtemp);


            //dictionary 사용
            Hashtable ht = new Hashtable()
            {
                ["one"] = 1,
                ["Two"] = 2,
                ["Three"] = 3
            };

            Hashtable ht2 = new Hashtable()
            {
                {"one", 1 },
                {"two", 2 },
                {"three", 3 }
             };



        }


        (int count, int sum, double average) calculate1(List<int> data)
        {
            int cnt = 0, sum = 0;
            double avg = 0; 

            foreach(var i in data)
            {
                cnt++;
                sum += i;
            }

            avg = sum / cnt;
            return (cnt, sum, avg);
        }

        static string ToLowerString(string input)
        {
            var arr = input.ToCharArray(); // 스트링을 배열에 넣어주네 워...
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = ToLowerchar(i);
            }

            char ToLowerchar(int i)
            {
                if (arr[i] < 65 || arr[i] > 90)
                    return arr[i];
                else
                    return (char)(arr[i] + 32);
            }

            return new string(arr);

        }

        void Divide1(int a, int b, out double aa, out double bb)
        {
            aa = a / b;
            bb = a % b; 
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //tuble
            var list = new List<int> { 1, 2, 3, 4, 5 };

            var r = calculate1(list);
            (int cnt, int sum, double avg) = calculate1(list);

            //local function 

            string str1 = ToLowerString("Hello");

            //out
            double i, j;
 
            Divide1(10, 5, out i, out j);

            //긴 숫자 
            int 백만 = 1_000_000;



        }

        static GameData _gameData = new GameData(); 

        private void button12_Click(object sender, EventArgs e)
        {
            ref int score10 = ref _gameData.GetScore(10);

            score10 = 99;

            string line;

            using (StreamReader rdr = new StreamReader("data.txt"))
            {
                while((line = rdr.ReadLine()) != null)
                {
                    string stremp = line; 
                }
            }

            using (StreamReader rdr = new StreamReader("data.txt"))
            {
                int ch = rdr.Read();

                char[] buffer = new char[10];
                int nreadcount = rdr.Read(buffer, 0, 10); 
            }

            using (StreamWriter wr = new StreamWriter("temp.txt"))
            {
                wr.WriteLine("123");
                wr.WriteLine("456");

                char [] array = new char[4]  { 'a','b','c','d'};
                wr.WriteLine(array);
            }


        }

        private void button13_Click(object sender, EventArgs e)
        {
            Stream outStream = new FileStream("a.txt", FileMode.Create);

            outStream.Close();

           // using var outStream1 = new FileStream("a1.txt", FileMode.Create) ;

            using (var outstream2 = new FileStream("b1.txt", FileMode.Create)) ;

            using var reader = new StreamReader("c1.txt");

        }
    }


    class GameData
    {
        private int[] score = new int[100];
        public ref int GetScore(int id)
        {
            return ref score[id];
        }
    }


    class MySort
    {
        public delegate int CompareDelegate(int i1, int i2);

        public static void Sort(int[] arr, CompareDelegate comp)
        {
            if (arr.Length < 2) return;

            int nRet;
            for(int i = 0; i < arr.Length- 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    nRet = comp(arr[i], arr[j]);

                    if (nRet == -1)
                    {
                        int ntemp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = ntemp;
                    }
                }
                Display(arr);
            }
        }
        static void Display(int[] arr)
        {
            foreach(var i in arr)
            {
                string strtemp = string.Format("{0}", i);
                MessageBox.Show(strtemp);
            }
        }
    }

    interface ILoger
    {
        void WriteLog(string message);
    }

    class ConsolLoger : ILoger
    {
        public void WriteLog(string message)
        {
            string strtemp = string.Format("{0}", message);
            MessageBox.Show(strtemp);
        }
    }

    class FileLogger : ILoger
    {
        private StreamWriter writer;
        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string messsge)
        {
            string strtemp = string.Format("{0} {1}", DateTime.Now.ToShortTimeString(), messsge);
            MessageBox.Show(strtemp);
        }
    }

    class climateMonitor
    {
        private ILoger logger;

        public climateMonitor(ILoger logger)
        {
            this.logger = logger;
        }
        public void start()
        {
            for (int i = 0; i < 2; i++)
            {
                string strtemp = string.Format("{0}", i.ToString());
                logger.WriteLog("temperture" + strtemp);
            }
        }
    }


    class MyStack<T>
    {
        T[] _elements;
        int pos = 0;

        public MyStack()
        {
            _elements = new T[100];
        }

        public void Push(T element)
        {
            _elements[++pos] = element; 
        }
        public T Pop()
        {
            return _elements[pos--];
        }

    }

    class MyBase
    {
    }
    class MyClass1 : MyBase
    {
    }




    public abstract class PureBase
    {
        public abstract int GetFirst();
        public abstract int GetNext();
    }
    public class DrivedA : PureBase
    {
        private int no = 1;

        public override int GetFirst()
        {
            return no;
        }
        public override int GetNext()
        {
            return no++;
        }
    }

    public static class MyUtility
    {
        private static int ver; 

        static MyUtility()
        {
            ver = 1; 
        }

        public static string Convert(int i)
        {
            return i.ToString();
        }
        public static int ConvertBack(string s)
        {
            return int.Parse(s);
        }
    }

    public class MyClass
    {
        private int val = 1; 
        public int InstRun()
        {
            return val; 
        }
        public static int Run()
        {
            return 1; 
        }
    }

    public class MyIndexer
    {
        private int[] array; 
        public MyIndexer()
        {
            array = new int[5]; 
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);

                    string strtemp = string.Format("resize {0}", array.Length);
                    MessageBox.Show(strtemp);

                    array[index] = value; 
                }
            }
        }
        public int Length
        {
            get
            {
                return array.Length;
            }
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
namespace MyExtension
{
    public static class IntergerExtension
    {
        public static int squre(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponet)
        {
            int result = myInt;

            for (int i = 1; i < exponet; i++)
                result = result * myInt;

            return result;
        }
    }
}

