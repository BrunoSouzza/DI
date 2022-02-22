namespace DI
{
    public class Operation : IOperation
    {
        public Guid Id { get; set; }

        public Operation()
        {
           Id = Guid.NewGuid();
        }
    }

    public interface IOperation
    {
        Guid Id { get; set; }
    }
}
