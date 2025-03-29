namespace Personal_Finance_Tracker.Domin
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public virtual List<Transaction> transactions { get; set; }

        public User() 
        {
         Balance = 0;
        }
    }
}
