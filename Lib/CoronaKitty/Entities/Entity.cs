using System;

namespace CoronaKitty.Entities
{
    public class Entity
    {

        static public UI.TextData entityDescriptionStyle = new UI.TextData("", ConsoleColor.White, ConsoleColor.Black);
        public string m_description {get; set;} = "";

        public Entity() {}
        
        public Entity(string description) {

            m_description = description;

        }

        public virtual void Describe() {

            UI.TextOutput.Put(m_description, entityDescriptionStyle.FG, entityDescriptionStyle.BG);

        }

    }
}