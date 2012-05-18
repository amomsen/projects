
namespace toh
{
    public class Score
    {
        private string username { get; set; }
        private string movecount { get; set; }

        public Score(string username, string movecount)
        {
            this.username = username;
            this.movecount = movecount;
        }

        public string Username
        {
            get
            {
                return username;
            }
        }

        public string MoveCount
        {
            get
            {
                return movecount;
            }
        }

        public override string ToString()
        {
            return username + " : " + movecount;
        } 
    }
}