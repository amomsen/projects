namespace toh
{
    public class Configuration
    {
        public int startPole {get; set;}
        public int endPole { get; set; }
        public int amountOfDisks { get; set; }

        public Configuration(int startPole, int endPole, int amountOfDisks)
        {
            this.startPole = startPole;
            this.endPole = endPole;
            this.amountOfDisks = amountOfDisks;

        }

    }
}
