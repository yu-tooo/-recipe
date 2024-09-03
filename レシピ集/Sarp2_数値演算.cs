namespace レシピ集
{
    public interface ISarp2_数値演算
    {
        /// <summary>
        /// 小数点以下3桁で切り捨てをしたい(小数点2桁を残したい)場合は、100倍したのちにfloorメソッドを利用する
        /// </summary>
        void 指定した位置で切り捨て_切り上げをしたい();

        /// <summary>
        /// Round(対象の小数型, 何桁目か, 丸めモード)
        /// </summary>
        void 四捨五入したい();

        /// <summary>
        /// オーバーフローのチェックをするにはcheckedブロックもしくはchecked式を利用する
        /// </summary>
        void 数値演算時のオーバーフローを検知したい();

        /// <summary>
        /// 浮動小数点の比較は==ではなく、ふたつの小数点の差が非常に小さければ同じと判断する方法を用いる
        /// </summary>
        void ふたつの浮動小数点数が等しいか比較したい();

        /// <summary>
        /// 演算子を利用する
        /// </summary>
        void ビット演算をしたい();

        /// <summary>
        /// |と<<を利用する
        /// </summary>
        void Nビット目をOn_Offしたい();

        /// <summary>
        /// &と<<を利用する
        /// </summary>
        void Nビット目の状態を調べたい();
    }
    public class Sarp2_数値演算: ISarp2_数値演算
    {
        public void 指定した位置で切り捨て_切り上げをしたい()
        {
            var targetValue = 3.14159;

            //小数3桁目を切り捨て
            var expected3_14 = Math.Floor(targetValue * Math.Pow(10, 2)) / Math.Pow(10, 2);

            //小数5桁目を切り上げ
            var expected3_1416 = Math.Ceiling(targetValue * Math.Pow(10, 4)) / Math.Pow(10, 4);

            Console.WriteLine($"3.14 = {expected3_14}");
            Console.WriteLine($"3.1416 = {expected3_1416}");
        }
        
        public void 四捨五入したい()
        {
            var nums = new double[] { 2.13, 2.14, 2.15, 2.16, 2.23, 2.24, 2.25, 2.26 };

            foreach ( double num in nums ) 
            {
                var round1 = Math.Round(num, 1, MidpointRounding.AwayFromZero);
                var round2 = Math.Round(num, 1, MidpointRounding.ToEven);

                Console.WriteLine($"もとの数字は{num}で普通の四捨五入は{round1}, 銀行丸めは{round2}");
            }
        }

        public void 数値演算時のオーバーフローを検知したい()
        {
            //checkedブロックを利用する場合

            var num = int.MaxValue - 5;

            try
            {
                checked
                {
                    num += 6;
                }
                Console.WriteLine(num.ToString());

            } catch(OverflowException e) 
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                num = checked (num + 6);
                Console.WriteLine(num.ToString());
            } catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ふたつの浮動小数点数が等しいか比較したい()
        {
            //0.01を100回足して1をつくる
            var d = 0.0;

            for (int i = 0; i < 100; i ++)
            {
                d += 0.01;
            }

            // == で比較
            Console.WriteLine(d == 1.0 ? "等しい" : "等しくない");

            //作成したメソッドで比較
            Console.WriteLine(DoubleEquals(d, 1.0) ? "等しい" : "等しくない");
        }

        static bool DoubleEquals(double a, double b )
        {
            var difference = a * 1.0E-14;
            return Math.Abs(a - b) < difference;
        }

        public void ビット演算をしたい()
        {
            ushort num1 = 0b_0000_0000_1111_1000;
            ushort num2 = 0b_0000_0000_1001_1101;

            Console.WriteLine($"{nameof(num1)}: {num1}");
            Console.WriteLine($"{nameof(num2)}: {num2}");
        }

        public void Nビット目をOn_Offしたい()
        {

        }

        public void Nビット目の状態を調べたい()
        {

        }
    }
}
