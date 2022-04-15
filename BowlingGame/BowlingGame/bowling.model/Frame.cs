using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.bowling.model
{
    public class Frame
    {
        private string frame_id;
        private int pins_knocked_down;

        public Frame() { }

        public Frame(string frame_id, int pins_knocked_down)
        {
            this.Frame_id = frame_id;
            this.Pins_knocked_down = pins_knocked_down;
        }

        public string Frame_id { get => frame_id; set => frame_id = value; }
        public int Pins_knocked_down { get => pins_knocked_down; set => pins_knocked_down = value; }
    }
}
