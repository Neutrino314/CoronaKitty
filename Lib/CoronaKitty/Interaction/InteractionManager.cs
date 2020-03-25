using System;
using System.Collections.Generic;

namespace CoronaKitty.Interaction
{

    public enum Interaction //enum containing types of interactions
    {

        LOOK = 0,
        TAKE,
        DROP,
        TALK,
        GO,
        CHECK,
        USE

    }


    public class InteractionManager
    {


        public UI.TextData m_inputStyle {get; set;} = new UI.TextData("", ConsoleColor.White, ConsoleColor.Black);

        public static string[] interactions {get;} = {"look", "take", "drop", "talk", "go", "check", "use"};

        private Stack<Entities.Entity> m_entityStack = new Stack<Entities.Entity>(); //helps handle nested interactions

        public InteractionManager(Entities.Entity entity) {

            m_entityStack.Push(entity);

        }

        public ValueTuple<Interaction, string, string> m_action; //action type, action,

        private string m_rawAction;
        private Interaction m_actionType;

        private void getAction() {

            UI.TextOutput.PutInline(">", m_inputStyle.FG, m_inputStyle.BG);

            Console.ForegroundColor = m_inputStyle.FG;
            Console.BackgroundColor = m_inputStyle.BG;

            m_rawAction = Console.ReadLine();

            UI.TextOutput.Put("\n\n", m_inputStyle.FG, UI.TextOutput.CONSOLEBG);

        }

        private bool processAction() {

            for (int i = 0; i < interactions.Length; i++) {

                if (m_rawAction.StartsWith(interactions[i])) {

                    m_actionType = (Interaction)i;
                    m_action.Item1 = m_actionType;

                    m_rawAction += ' ';

                    m_rawAction = m_rawAction.Remove(0, interactions[i].Length + 1);

                    var action = m_rawAction.Split(new char[] {' '}, 2);

                    m_action.Item2 = action[0];

                    if (action.Length == 2)
                        m_action.Item3 = action[1];

                    return true;

                }

            }

            return false;
        }

        public int Update() {

            getAction();

            if (!processAction()) {

                UI.TextOutput.Put("Error!!! Unrecognised action!!!", ConsoleColor.Red, m_inputStyle.BG);
                return 1;

            }

            return 0;

        }

    }
}