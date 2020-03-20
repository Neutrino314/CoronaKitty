namespace CoronaKitty.Entities
{

    public delegate void itemFunction(Entity entity);
    public class Item : Entity
    {

        public itemFunction method {get; set;}

        public Item(string description) : base(description) {


        }

        public Item() : base() {


        }

        public override void Describe() {

            base.Describe();

        }

        public void Use(Entity entity) {

            method(entity);

        }

    }
}