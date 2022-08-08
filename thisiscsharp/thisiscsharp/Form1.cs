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
using System.Threading;

// 2020test
namespace thisiscsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyClass obj = new MyClass();
            // obj.SetMyField(1);
            // int nRet = obj.GetMyField();

            //obj.MyField = 3;
            int nRet = obj.MyField;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //기본적인 클래스내의 변수 가져오고 셑 하는 방식이 아래와 같다. 

            BirthdayInfo birth = new BirthdayInfo();
            birth.Name = "space";

            birth.datetime = new DateTime(1, 2, 3);

            string strname = birth.Name;
            DateTime dt = birth.datetime;

            int nAge = birth.Age;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 좀더 개선된 방식의 프로퍼티 
            BirthdayInfo2 binfo = new BirthdayInfo2();

            string name = binfo.Name;
            DateTime dt = binfo.datetime;


            binfo.Name = "space";
            binfo.datetime = new DateTime(1, 1, 1);


            // 프로퍼티 초기화 방법 
            BirthdayInfo2 binfo2 = new BirthdayInfo2()
            {
                Name = "aa",
                datetime = new DateTime(1, 2, 3)
            };

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // 흠.. 이게 사용하기 편하다고?? 무르겠음 
            var a = new { Name = "a", Age = 1 };

            var b = new { Subject = "math", Score = new int[] { 1, 2, 3, 4 } };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // 인터페이스 초기화 방식 
            NmaedValue name = new NmaedValue()
            {
                Name = "a",
                Value = "1"
            };

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Product project1 = new MyProject()
            {
                ProductDate = new DateTime(1, 1, 1)
            };
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // linkq 기본 형태, 데이터 베이스를 처리하기위한 문법임 

            int[] numbers = { 6, 4, 8, 3, 4, 1, 9, 0 };

            var result = from n in numbers
                         where n % 2 == 0
                         orderby n
                         select n;

            foreach (int n in result)
            {
                int t = n;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Profile[] arrProifle =
            {
                new Profile(){ Name = "AA",Height = 190},
                new Profile(){ Name = "BB",Height = 150},
                new Profile(){ Name = "CC",Height = 160}
            };

            var profiles = from profile in arrProifle
                           where profile.Height > 170
                           orderby profile.Height
                           select new
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 3.93
                           };

            foreach (var profile in profiles)
            {
                string strtemp = profile.Name;
                double dHeight = profile.InchHeight;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Class[] arrClass =
            {
                new Class() { Name = "a", Score = new int[] {98, 24, 11, 25} },
                new Class() { Name = "b", Score = new int[] { 11, 44, 98, 11 } },
                new Class() { Name = "c", Score = new int[] { 99, 98, 95, 100 } }
            };


            var classes = from c in arrClass
                          from s in c.Score
                          where s < 60
                          orderby s
                          select new
                          {
                              c.Name,
                              Lowest = s
                          };


            foreach (var c in classes)
            {
                string strtemp = c.Name;
                int number = c.Lowest;
            }



        }

        private void button11_Click(object sender, EventArgs e)
        {
            Profile[] arrProifle =
            {
                new Profile(){ Name = "AA",Height = 190},
                new Profile(){ Name = "BB",Height = 150},
                new Profile(){ Name = "CC",Height = 160}
            };

            var listprofile = from profile in arrProifle
                              group profile by profile.Height < 160 into g
                              select new
                              {
                                  GroupKey = g.Key,
                                  profile = g
                              };



            foreach (var Group in listprofile)
            {
                if (Group.GroupKey)
                {
                    foreach (var profile in Group.profile)
                    {
                        string name = profile.Name;
                        int Height = profile.Height;
                    }
                }
            }
        }

        private static void Print(int nValue)
        {
            Console.WriteLine(nValue.ToString());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int[] score = new int[] { 22, 55, 88, 555, 2, 3, 66, 1, 5 };

            foreach (int nData in score)
            {
                // string strtemp = string.Format("{ 0}", nData);
            }

            Array.Sort(score);

            // 배열내부의 인자를 동일 행동을 하게 한다. 
            Array.ForEach<int>(score, new Action<int>(Print));

            // 배열의 차원을 표시한다. 
            Console.WriteLine(score.Rank);

            Console.WriteLine(Array.BinarySearch<int>(score, 88));

            Console.WriteLine(Array.IndexOf(score, 88));

            //배열 초기화 
            Array.Clear(score, 0, score.Length);

            Array.Clear(score, 0, score.Length);




        }

        static void PrintArray(System.Array array)
        {
            foreach (var e in array)
                Console.Write(e);
            Console.WriteLine();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            char[] array = new char['Z' - 'A' + 1];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (char)('A' + i);
            }

            // PrintArray(array[..]); 이러면 전체 데이터 
            //PrintArray(array[1..]); 이러면 1부터 끝까지 

        }

        private void button14_Click(object sender, EventArgs e)
        {
            int[,] array = new int[2, 3];

            int[,,] array1 = new int[2, 3, 1];

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int[][] array = new int[3][];
            array[0] = new int[5] { 1, 2, 3, 4, 5 };
            array[1] = new int[] { 11, 22, 33 };
            array[2] = new int[] { 111, 222 };

            foreach (int[] arr in array)
            {
                foreach (int eㅌ in arr)
                {
                    //이차원으로 사용 방법 
                }
            }

            int[][] array2 = new int[2][]
            {
                new int[] { 1,2},
                new int[4] {1,2,3,4}
            };

            foreach (int[] arr in array2)
            {
                foreach (int ee in arr)
                {
                    //2차원 가변 배열 사용법 
                }
            }



        }

        private void button16_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 5; i++)
                list.Add(i);

            foreach (object obj in list)
                Console.WriteLine(obj.ToString());

            list.Remove(1);

            foreach (object obj in list)
                Console.WriteLine(obj.ToString());

            list.Insert(1, "test");

            foreach (object obj in list)
                Console.WriteLine(obj.ToString());

        }

        private void button17_Click(object sender, EventArgs e)
        {
            Queue qu = new Queue();

            qu.Enqueue(1);
            qu.Enqueue("11");


            while (qu.Count > 0)
                Console.WriteLine(qu.Dequeue());




        }

        private void button18_Click(object sender, EventArgs e)
        {
            Stack stack = new Stack();

            stack.Push(1);
            stack.Push("222");

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();

            ht["1"] = "2";
            ht[2] = "3";


            Console.WriteLine(ht[2]);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ArrayList ar = new ArrayList() { 1, 2, 3, 4 };

            Queue que = new Queue();

            foreach (object obj in ar)
                que.Enqueue(obj);

            Stack stack = new Stack();

            foreach (object obj in stack)
                stack.Push(obj);

            Hashtable ht = new Hashtable()
            {
                ["1"] = 1,
                ["2"] = 2
            };
        }




        private void button21_Click(object sender, EventArgs e)
        {

            MyList list = new MyList();

            for (int i = 0; i < 5; i++)
                list[i] = i;

            for (int i = 0; i < 5; i++)
                Console.WriteLine(list[i].ToString());
        }

        static void CopyArray<T>(T[] source, T[] target)
        {
            for (int i = 0; i < source.Length; i++)
                target[i] = source[i];
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int[] source = { 1, 2, 3, 4, 5 };
            int[] target = new int[source.Length];

            CopyArray<int>(source, target);


            object[] source1 = { 1, 2, 3, "1" };
            object[] target1 = new object[source1.Length];

            CopyArray<object>(source1, target1);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MyList1<string> str_list = new MyList1<string>();

            str_list[0] = "11";
            str_list[5] = "55";

            MyList1<int> int_list = new MyList1<int>();

            int_list[0] = 1;
            int_list[4] = 5;
        }


        public static T CreateInstance<T>() where T : new()
        {
            return new T();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            StructArray<int> a = new StructArray<int>(3);

            a.Array[0] = 1;
            a.Array[1] = 2;


            // 배열을 인자로 가지고 있는 방식 
            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);

            b.Array[0] = new StructArray<double>(4);
            b.Array[1] = new StructArray<double>(3);


        }

        private void button25_Click(object sender, EventArgs e)
        {
            int[] arr = { 1, 2, 3 };

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(arr[i]);
                }
            }
            catch (Exception aa)
            {
                Console.WriteLine(aa.Message);
            }

        }

        static void DoSomething(int arg)
        {
            if (arg < 10)
                Console.WriteLine($"arg: {arg}");
            else
                throw new Exception("over arg");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                DoSomething(1);
                DoSomething(11);
                DoSomething(13);
                DoSomething(14);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 식으로 표현되는 방식 
            try
            {
                int? a = null;
                int b = a ?? throw new ArgumentNullException();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int[] array = new[] { 1, 2, 3 };

                int index = 4;
                int value = array[index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()];

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        static uint MergeARGB(uint alpha, uint red, uint gree, uint blue)
        {

            uint[] args = new uint[] { alpha, red, gree, blue };

            foreach (uint arg in args)
            {
                if (arg > 255)
                {
                    throw new InvalidArgumentException()
                    {
                        Argument = arg,
                        Range = "0  ~ 255"
                    };
                }
            }

            return (alpha << 24 & 0xFF000000)|
                (red << 16 & 0x00FF0000)|
                 (gree << 8 & 0x0000FF00)|
                 (blue & 0x000000ff);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("0x{0:x}", MergeARGB(255, 111, 111, 111));
            }
            catch (InvalidArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Endof");
            }
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            Console.WriteLine("starting thread...");
            t1.Start();

            Thread.Sleep(100);

            Console.WriteLine("Aborting thread..");
            t1.Abort();

            Console.WriteLine("Waiting until thread stops..");
            t1.Join();

            Console.WriteLine();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Counter counter = new Counter();


            Thread incThread = new Thread(new ThreadStart(counter.Increase));
            Thread decThread = new Thread(new ThreadStart(counter.Decrease));

            incThread.Start();
            decThread.Start();

            incThread.Join();
            decThread.Join();

            Console.WriteLine(counter.Count);

        }
    }


    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        private int count; 
        public int Count
        {
            get { return count; }
        }

        public Counter()
        {
            thisLock = new object();
            count = 0; 
        }

        public void Increase()
        {
            int nLoopCount = LOOP_COUNT;

            while (nLoopCount-- > 0)
            {
                /*
                lock (thisLock)
                {
                    count++;
                }
                */
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                    Console.WriteLine(count);
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }

        public void Decrease()
        {
            int nLoopCount = LOOP_COUNT;
            while (nLoopCount-- > 0)
            {
                /*
                lock (thisLock)
                {
                    count--; 
                }
                */
                Monitor.Enter(thisLock);
                try 
                {
                    count--;
                    Console.WriteLine(count);
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
    }
    class SideTask
    {
        int count;

        public SideTask(int count1)
        {
            this.count = count1;
        }

        public void KeepAlive()
        {
            try
            {
                while (count > 0)
                {
                    Console.WriteLine($"{count--} Left");
                    Thread.Sleep(10);
                }
                Console.WriteLine("Count : 0");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine(e);
                Thread.ResetAbort();
            }
            finally 
            {
                Console.WriteLine("Clearing resource..");
            }

        }
    }

    class InvalidArgumentException : Exception
    {
        public InvalidArgumentException()
        {
            
        }
        public InvalidArgumentException(string message) : base(message)
        {

        }

        public object Argument
        {
            get;
            set;
        }

        public string Range
        {
            get;
            set;
        }

    }

    class StructArray<T> where T : struct
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base {}
    class Derived : Base { }
    class BaseArray<U> where U : Base 
    {
        public U[] Array { get; set; }
        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] Source) where T : U
        {
            Source.CopyTo(Array, 0);
        }
    }


    class MyList1<T>
    {
        private T[] array;

        public MyList1()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get { return array[index]; }
            set 
            {
                if (index >= array.Length)
                    Array.Resize<T>(ref array, index + 1);

                array[index] = value;
            }
        }
        public int Length
        {
            get { return array.Length; }
        }

    }

    class MyList
    {
        private int[] array;
        public MyList()
        {
            array = new int[3];
        }

        public int this[int index]
        {
            get 
            {
                return array[index];
            }

            set 
            {
                if (index >= array.Length)
                {
                    Array.Resize<int>(ref array, index + 1);
                }

                array[index] = value; 
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

    class Class
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }

    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }



    abstract class Product
    {
        private static int serial = 0; 
        public string SerialID
        {
            get { return String.Format("{0}", serial++); }
        }
        abstract public DateTime ProductDate
        { get; set; }
    }

    class MyProject : Product
    {
        public override DateTime ProductDate
        {
            get; set;
        }
    }


    interface INamedValue
    {
        string Name{ get; set; }
        string Value { get; set; }

    }

    class NmaedValue : INamedValue
    {
        //상속 받은 인터페이스 프로퍼티를 재 구현 해주어야한다.
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }
    }



    class InitOnly
    {
        // 초기화 방식은데 이 컴파일러는 init 명령을 지원 안하내 
        /*
        public string From { get; init; }
        public string To { get; init; }

        public int Amount { get; init; }

        public override string ToString()
        {
            return $"{From,-10} ->{To,-10}: $(Amount)";
        }
        */
    }





    class BirthdayInfo2
    {
        public string Name { get; set; } = "unknow";
        public DateTime datetime { get; set; } = new DateTime(0, 0, 0);

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(datetime).Ticks).Year;
            }
        }
    }

    class BirthdayInfo
    {
        private string name;
        private DateTime birthday; 

        public string Name
        {
            get { return name; }

            set { name = value;  }
        }

        public DateTime datetime
        {
            get { return birthday; }

            set { birthday = value; }
        }

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
            }
        }
    }




    class MyClass
    {
        private int myField;
        //기본 방식 
        public int GetMyField()
        {
            return myField;
        }
        public void SetMyField(int set)
        {
            myField = set;
        }

        //프로퍼티 방식 
        public int MyField
        {
            get
            {
                return myField;
            }
             // 이렇게 하면 읽기 전용이 된다. 
            set
            {
                myField = value;
            }
            
        }
           
    }
}

