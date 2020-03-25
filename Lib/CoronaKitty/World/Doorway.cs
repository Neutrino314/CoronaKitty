using System;

namespace CoronaKitty.World
{
    public class Doorway
    {
        
        private bool locked {get; set;} = true;

        private string Key;

        public bool Locked() {return locked;}

        public Doorway(bool Lock, string key) {

            locked = Lock;
            Key = key;

        }

        public void Unlock(string key) {

            if (locked) {

                if (Key == key) {

                    locked = false;

                } else {

                    UI.TextOutput.Put("It doesn't fit!!", ConsoleColor.White, ConsoleColor.Black);

                }
            }
        }

    }
}