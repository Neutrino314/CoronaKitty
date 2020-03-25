using System;
using System.Collections.Generic;

using CoronaKitty.Entities;

namespace CoronaKitty.World
{
    public class Room : Entity, Events.EventDispatcher, Events.EventReciever
    {
        
        public Dictionary<string, ValueTuple<Room, Doorway>> m_adjacentRooms = new Dictionary<string, (Room, Doorway)>(); //list containing adjacent rooms and whether they are enterable

        public Room() : base() {


        }

        public Room(string description) : base(description) {


        }

        public void AddAdjacent(Room room, Doorway doorway, string cardinal) {

            if (m_adjacentRooms.ContainsKey(cardinal)) {

                UI.TextOutput.Put("Error!!! Room already exists at that direction", ConsoleColor.Red, UI.TextOutput.CONSOLEBG);

            }

            m_adjacentRooms[cardinal] = (room, doorway);

            var angle = Math.Abs(Navigation.cardinalAngles[cardinal] - 180 + 360);

            if (angle >= 360) {

                angle -= 360;

            }

            foreach (var pair in Navigation.cardinalAngles)
            {
                
                if (pair.Value == angle) {

                    room.m_adjacentRooms[pair.Key] = (this, doorway);

                }
            }

        }

        public override void Describe() {

            base.Describe();

        }

        public void onEvent(Events.Event e) {

            if (e.eventType == "Player Entered Room") {

                string playerName = ((Player)e.dispatcher).m_name;

                UI.TextOutput.Put(playerName, ConsoleColor.Green, ConsoleColor.Black);

            }
        }

    }
}