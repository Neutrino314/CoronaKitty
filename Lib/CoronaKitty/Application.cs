using System;
using System.Collections.Generic;
using CoronaKitty.Entities;

namespace CoronaKitty
{
    public class Application
    {

        private Queue<Events.Event> m_eventQueue = new Queue<Events.Event>();

        private Player m_player = new Player("Generic player object", "Bosc");

        private World.Room m_rootRoom = null;

        public Application() {


        }

        public Application(World.Room room) {

            m_rootRoom = room;

        }

        public void Run() {

            m_player.EnterRoom(m_rootRoom);
            processEvents();

            while (true) {

                m_player.Update(this);

                processEvents();

            }

        }

        public void AddEvent(Events.Event e) {

            m_eventQueue.Enqueue(e);

        }

        private void processEvents() {

            

            while (m_eventQueue.Count > 0)
            {

                Events.Event e = m_eventQueue.Dequeue();

                Events.EventReciever reciever = e.reciever;

                if (reciever != null) {

                    reciever.onEvent(e);

                } else {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error!!! Event reciever was invalid, event skipped");

                }

            }
        }

    }
}