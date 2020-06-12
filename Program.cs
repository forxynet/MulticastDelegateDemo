using System;

namespace MulticastDelegateDemo {
    public delegate void RectangelDegate(double Width, double Height);
    public delegate void MathDelegate(int x, int y);
    public delegate int SampleDelegate(int x);
    public class program {           
        public void GetArea(double Width, double Height) {
            Console.WriteLine($"Area is {Width * Height}");
        }
        public void GetPerimeter(double Width, double Height) {
            Console.WriteLine($"Perimeter is {2 * (Width + Height)}");
            Console.WriteLine();
        }
        public static void Add(int x, int y) { //toplama
            Console.WriteLine($"The sum {x} + {y} is: {x + y}");
        }
        public static void Sub(int x, int y) {//çıkartma
            Console.WriteLine($"The sub {x} - {y}  is: {x - y}");
        }
        public void Mul(int x, int y) {//çarpma
            Console.WriteLine($"The mul {x} * {y}  is: {x * y}");
        }
        public void Div(int x, int y) { //bölme
            Console.WriteLine($"The div {x} / {y}  is: {x / y}");
        }
        private static void Rectange() {
            program rect = new program();
            RectangelDegate rectDelegate = new RectangelDegate(rect.GetArea);

            rectDelegate += rect.GetPerimeter;
            rectDelegate(23.45, 67.89);

            rectDelegate.Invoke(13.45, 76.89);

            //Removing a method from delegate object
            rectDelegate -= rect.GetPerimeter;

            rectDelegate.Invoke(13.45, 76.89);
        }
        public static int MethodOne(int x) {
            return x * 10;
        }
        public static int MethodTwo(int x) {
            return x * 2;
        }
        static void Main(string[] args) {
            //Rectange();
            program p = new program();

            #region MathDelegate
            //MathDelegate del1 = new MathDelegate(Add);
            //MathDelegate del2 = new MathDelegate(program.Sub);
            //MathDelegate del3 = p.Mul;
            //MathDelegate del4 = new MathDelegate(p.Div);

            //MathDelegate del5 = del1 + del2 + del3 + del4;

            //del5.Invoke(20, 5);
            //Console.WriteLine();

            //del5 -= del3;

            //del5(22, 7);
            #endregion

            SampleDelegate sampleDelegate = new SampleDelegate(MethodOne);
            sampleDelegate += MethodTwo;

            int ValueReturnedByDelegate = sampleDelegate.Invoke(2);

            Console.WriteLine($"Returned Value is {ValueReturnedByDelegate}");

            Console.ReadKey();
        }
    }
}