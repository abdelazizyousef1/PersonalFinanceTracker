namespace Personal_Finance_Tracker.Domin
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


        public int UserId { get; set; }
        public virtual User User { get; set; }


        public int ReceiverId { get; set; }
        public virtual User Receiver { get; set; }




        public void ValidateAmount()
        {
            if (Amount <= 0) throw new Exception("amount must be positive");
        }
        
    }
}
