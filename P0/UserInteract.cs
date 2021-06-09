namespace P0
{
    public class UserInteract : IWrite, IRead
    {
        Write write = new Write();
        Read read = new Read();

        public void PutLine(string message)
        {
            write.PutLine(message);
        }

        public double GetNumber()
        {
            return read.GetNumber();
        }
        public string GetString()
        {
            return read.GetString();
        }
    }
}