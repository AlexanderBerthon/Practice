using System;

namespace Practice {
    public class ChristmasShopping {
        static void Main(string[] args) {
            int money = 10;
            int[] prices = { 1, 2, 3, 4, 5 };

            //for testing efficiency
            Stopwatch sw = new Stopwatch();

            sw.Start();
            generousSanta(money, prices);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());

            sw.Reset();

            sw.Start();
            cheapSanta(money, prices);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
        }

        //I read the problem wrong, below answers a different question
        //"buy 2 items while maximizing the amount spent"
        static void generousSanta(int money, int[] prices) {
            int cost = 0;
            int[] gift = { 0, 0 };

            for (int i = 0; i < prices.Length - 1; i++) {
                for (int j = i + 1; j < prices.Length; j++) {
                    cost = prices[i] + prices[j];
                    if (cost <= money && cost > gift[0] + gift[1]) {
                        gift[0] = prices[i];
                        gift[1] = prices[j];
                    }
                }
            }

            if (gift[0] + gift[1] == 0) {
                Console.WriteLine("You cannot buy 2 items without going in debt, so we return {0}", money); //fancy string interpolation
            }
            else {
                Console.WriteLine("Purchase the items priced at {0} and {1} units respectively. You will have {3} - {2} = {4} units of money afterwards. Thus, we return {4}.",
                    gift[0], gift[1], (gift[0] + gift[1]), money, (money - (gift[0] + gift[1])));
            }
        }

        //buy 2 items while minimizing the amount spent
        //basically just find the 2 lowest values. if you can't afford the two lowest then you can't afford any other combination
        static void cheapSanta(int money, int[] prices) {

            //extra variables (might not be needed)
            int[] gift = { prices[0], prices[1] };

            //finds 2 lowest items      
            for (int i = 2; i < prices.Length; i++) {
                if (prices[i] < gift[0]) {
                    if (gift[0] < gift[1]) {
                        gift[1] = gift[0];
                    }
                    gift[0] = prices[i];
                }
                else if (prices[i] < gift[1]) {
                    gift[1] = prices[i];
                }
            }

            if (gift[0] + gift[1] > money) {
                Console.WriteLine("You cannot buy 2 items without going in debt, so we return {0}", money);
            }
            else {
                Console.WriteLine("Purchase the items priced at {0} and {1} units respectively. You will have {3} - {2} = {4} units of money afterwards. Thus, we return {4}.",
                    gift[0], gift[1], (gift[0] + gift[1]), money, (money - (gift[0] + gift[1])));
            }
        }
    }
}