using System;
using System.Collections.Generic;

using CoronaKitty.Entities;

namespace CoronaKitty.World
{
    public class Room : Entity
    {
        
        public List<Tuple<Room, bool>> m_adjacentRooms = new List<Tuple<Room, bool>>(); //list containing adjacent rooms and whether they are enterable
        public List<Entity> m_entities = new List<Entity>(); //list of entities in the room

        public Room() : base() {


        }

        public Room(string description) : base(description) {


        }

        public override void Describe() {

            base.Describe();

        }

    }
}