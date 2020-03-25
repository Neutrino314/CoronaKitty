namespace CoronaKitty.Events
{
    public class Event //event class that will be used to send messages between system components
    //this will allow for the decoupling of the quest and interaction systems later on down the line
    {

        public EventDispatcher dispatcher {get; set;} = null;
        public EventReciever reciever {get; set;} = null;

        public object message {get; set;} = null;

        public string eventType {get; set;} = "";

        public Event() {


        }

        public Event(EventDispatcher dispatch, EventReciever recieve, object msg, string evType) {

            dispatcher = dispatch;
            reciever = recieve;
            message = msg;
            eventType = evType;

        }

    }
}