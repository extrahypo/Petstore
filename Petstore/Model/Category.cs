using System.Collections.Generic;

namespace Petstore.Model
{
    public class Category
    {
        public long Id;
        public string Name;

        public List<Pet> Pets;

        public Category(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddPet(Pet pet)
        {
            if (Pets == null)
                Pets = new List<Pet>();
            Pets.Add(pet);
        }
    }
}
