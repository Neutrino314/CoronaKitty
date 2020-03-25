using System;
using System.Collections.Generic;

namespace CoronaKitty.Entities
{

    /*
        Player Class implementation

        The player will be able to move from room to room as well as interact with the room they're in

     */
    public class Player : Entity , Events.EventDispatcher, Events.EventReciever {

        private Dictionary<string, float> m_stats = new Dictionary<string, float>();
        private Dictionary<string, Tuple<int, Item>> m_inventory = new Dictionary<string, Tuple<int, Item>>(); 
        private World.Room m_currentRoom = null;

        private float m_orientation = 0;

        private Interaction.InteractionManager m_interactionManager;

        private int m_interactionFlag;

        public int hi = 0;

        public Player() : base() {

        }

        public Player(string desc, string name = "") : base(desc) {

            base.m_name = name;

        }

        public override void Describe() {

            base.Describe();

        }

        public void EnterRoom(World.Room room) {

            m_currentRoom = room;

            m_interactionManager = new Interaction.InteractionManager(m_currentRoom);

            m_currentRoom.Describe();

        }

        public override void Update(CoronaKitty.Application app) {

            m_interactionFlag = m_interactionManager.Update();

            if (m_interactionFlag != 0) {

                return;
    
            }

            switch (m_interactionManager.m_action.Item1) {

                case Interaction.Interaction.GO:

                    if (World.Navigation.cardinalAngles.ContainsKey(m_interactionManager.m_action.Item2.ToUpper())) {

                        move(m_interactionManager.m_action.Item2.ToUpper(), app);

                    } else {

                        Console.WriteLine(m_interactionManager.m_action.Item2);

                    }
                    break;

                default:

                    UI.TextOutput.Put("INVALID ACTION TYPE", ConsoleColor.Red, UI.TextOutput.CONSOLEBG);
                    break;

            }

        }

        private void move(string direction, CoronaKitty.Application app) {

            if (m_currentRoom.m_adjacentRooms.ContainsKey(direction) && !m_currentRoom.m_adjacentRooms[direction].Item2.Locked()) {

                EnterRoom(m_currentRoom.m_adjacentRooms[direction.ToUpper()].Item1);

            } else {

                if (m_currentRoom.m_adjacentRooms.ContainsKey(direction)) {

                    UI.TextOutput.Put("You try to move forward but the door seems to be locked", ConsoleColor.Red, UI.TextOutput.CONSOLEBG);

                } else {

                    UI.TextOutput.Put("Ummmm... there's not really anything in that direction", ConsoleColor.Red, UI.TextOutput.CONSOLEBG);
                }

            }
        }

        public void onEvent(Events.Event e) {


        }

    }
}