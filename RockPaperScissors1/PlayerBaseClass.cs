namespace RockPaperScissors1
{
    public class PlayerBaseClass
    {
        public PlayerBaseClass()
        {
            _name = "Computer";
            _score = 0;
        }
        public PlayerBaseClass(string fname)
        {
            _name = fname;
            _score = 0;
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private int _score;
        public int Score
        {
            get
            {
                return _score;
            }
        }
        public bool incrementScore()
        {
            _score++;
            return true;
        }

        public bool reset()
        {
            _score = 0;
            return true;
        }
        public bool wonItAll()
        {
            return _score < 2;
        }
    }
}