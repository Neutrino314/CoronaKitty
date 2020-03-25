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

        ~Item() {


        }

        public override void Describe() {

            base.Describe();

        }

        public override void Update(Application app) {}

        public void Use(Entity entity) {

            method(entity);

        }

    }
}