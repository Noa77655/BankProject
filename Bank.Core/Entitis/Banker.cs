namespace project.Entitis
{
    public class Banker
    {
        public string id { get; set; }
        public string phonNumber { get; set; }
        public bool isActive { get; set; }
        public List<Turn> turns { get; set; }
    }
}
