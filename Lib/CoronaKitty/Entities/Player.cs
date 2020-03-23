using System;
using System.Collections.Generic;

namespace CoronaKitty.Entities
{

    /*
        Player Class implementation

        The player will be able to move from room to room as well as interact with the room they're in

     */
    public class Player : Entity {

        private Dictionary<string, float> m_stats = new Dictionary<string, float>();
        private Dictionary<string, Tuple<int, Item>> m_inventory = new Dictionary<string, Tuple<int, Item>>(); 
        private World.Room m_currentRoom = null;

        private Interaction.InteractionManager m_interactionManager;

        private int m_interactionFlag;

        public int hi = 0;

        public Player() : base() {

        }

        public Player(string desc) : base(desc) {

            UI.TextOutput.Put(this.GetType().ToString(), ConsoleColor.White, ConsoleColor.Black);

        }

        public override void Describe() {

            base.Describe();

        }

        public void EnterRoom(World.Room room) {

            m_currentRoom = room;

            m_interactionManager = new Interaction.InteractionManager(m_currentRoom);

            m_currentRoom.Describe();

        }

        public override void Update() {

            m_interactionFlag = m_interactionManager.Update();

            if (m_interactionFlag != 0) {

                return;
    
            }

        }

    }
}