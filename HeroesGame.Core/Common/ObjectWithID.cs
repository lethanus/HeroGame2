using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesGame.Common
{
    public enum FactOperation { ADD, REMOVE}
    public class ObjectWithID
    {
        public string ID { get; set; }
        public FactOperation FactOperation { get; set; }
        public DateTime FactTime { get; set; }
        public int Amount { get; set; }
        public string Identyficator { get; set; }
    }
}
