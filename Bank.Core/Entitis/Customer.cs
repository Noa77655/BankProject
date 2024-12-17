namespace project.Entitis
{
    public class Customer
    {
        public string id { get; set; }
        public string phonNumber { get; set; }
        public bool isActive { get; set; }
        public string TurnId { get; set; }
        public Turn Turn { get; set; }
    }
}
