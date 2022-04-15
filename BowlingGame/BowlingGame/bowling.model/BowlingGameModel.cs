using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.bowling.model
{
    public class BowlingGameModel
    {
        private string id;
        private string name;
        private Frame frame;

        public BowlingGameModel() { }

        public BowlingGameModel(string id, string name, Frame frame)
        {
            this.Id = id;
            this.Name = name;
            this.Frame = frame;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Frame Frame { get => frame; set => frame = value; }
    }
}
