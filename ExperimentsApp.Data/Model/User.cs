using System.Collections.Generic;

namespace ExperimentsApp.Data.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username{ get; set; }
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public IList<Experiment> Experiments { get; set; }
    }
}

