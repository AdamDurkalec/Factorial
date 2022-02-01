namespace Factorial.Services
{
    public class FactorialService
    {
        private int _funds = 0;
        public FactorialService()
        {
            _funds = 5;
        }
        public int Funds => _funds;
        public int GetFactorial(int n)
        {
            if (n < 0 || n > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            };
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            _funds--;
            return result;
        }

        public void AddFunds(int v)
        {
            _funds += v;
        }
    }
}
