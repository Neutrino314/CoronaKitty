using System;
using System.Collections.Generic;

namespace CoronaKitty.Entities
{
    public class Player : Entity {

        private Dictionary<string, float> m_stats {get; set;} = new Dictionary<string, float>();
        private string m_name {get; set;}
        private Dictionary<string, Tuple<int, Item>> m_inventory = new Dictionary<string, Tuple<int, Item>>(); 

        public Player() : base() {

        }

        public Player(string desc) : base(desc) {


        }

        public override void Describe() {

            base.Describe();

        }

    }
}