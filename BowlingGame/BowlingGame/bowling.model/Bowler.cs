using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.bowling.model
{
    public class Bowler
    {
        private string id;
        private string name;

        public Bowler() { }

        public Bowler(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
