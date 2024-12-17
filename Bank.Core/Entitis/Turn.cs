namespace project.Entitis
{
    public class Turn
    {
        public string id { get; set; }
        public string day { get; set; }
        public string hour { get; set; }
        public Banker banker { get; set; }
        public Customer customer { get; set; }
    }
}
