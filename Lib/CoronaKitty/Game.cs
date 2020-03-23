using System;
using System.Collections.Generic;
using CoronaKitty.Entities;

namespace CoronaKitty
{
    public class Game
    {

        private Player m_player = new Player("Generic player object");

        private World.Room m_rootRoom = null;

        public Game() {


        }

        public Game(World.Room room) {

            m_rootRoom = room;

        }

        public void Run() {

            m_player.EnterRoom(m_rootRoom);

            while (true) {

                m_player.Update();

            }

        }

    }
}