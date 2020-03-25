using System;

namespace CoronaKitty.Entities
{
    public class Entity
    {

        static public UI.TextData entityDescriptionStyle = new UI.TextData("", ConsoleColor.White, ConsoleColor.Black);
        public string m_description {get; set;} = "";
        public string m_name {get; set;} = "";

        public Entity() {}

        public Entity(string description) {

            m_description = description;

        }

         ~Entity() {


        }

        public virtual void Describe() {

            UI.TextOutput.Put(m_description, entityDescriptionStyle.FG, entityDescriptionStyle.BG);

        }

        public virtual void Update(CoronaKitty.Application app) {}

        public static T EntityTo<T>(Entity ent) where T : Entity { //method convertng boxed entity to its original type

            return (T)ent;

        }


    }
}