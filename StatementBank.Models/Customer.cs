namespace StatementBank.Models
{
    public class Customer
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // public Account Account { get; set; }
        public Customer(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }


    }
}
