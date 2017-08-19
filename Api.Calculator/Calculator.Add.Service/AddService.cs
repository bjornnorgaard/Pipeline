using Calculator.Add.Interface;

namespace Calculator.Add.Service
{
    public class AddService : IAddService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
