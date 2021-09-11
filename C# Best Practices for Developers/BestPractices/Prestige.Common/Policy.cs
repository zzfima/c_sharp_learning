namespace Prestige.Common
{
    public class Policy
    {
        static private Policy _instance;
        private string _level;

        public string Level
        {
            get => _level;
            set
            {
                _level = "Level is: " + value;
            }
        }

        private Policy()
        {

        }

        static public Policy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Policy();

                return _instance;
            }
        }

    }
}
