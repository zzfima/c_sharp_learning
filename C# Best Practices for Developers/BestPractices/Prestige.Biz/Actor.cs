namespace Prestige.Biz
{
    public class Actor
    {
        private const string occupation = "Actor";

        /// <summary>
        /// Will return title
        /// </summary>
        /// <returns></returns>
        public string GetOccupation() => occupation;

        private string jobTitle;

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

    }
}