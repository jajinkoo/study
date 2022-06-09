using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            birth.datetime = new DateTime(1,2,3);

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
