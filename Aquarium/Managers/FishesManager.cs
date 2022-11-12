using Aquarium.Models;

namespace Aquarium.Managers
{
    public class FishesManager
    {
        private static int _nextId = 1;
        private static readonly List<Fish> Data = new List<Fish>
        {
            new Fish() {Id=_nextId++, Length=100, Name="Maria", Species="Carp"},
            new Fish() {Id=_nextId++, Length=10, Name="Digna", Species="Sealion"},
            new Fish() {Id=_nextId++, Length=230, Name="Selchuk", Species="Dory"},
            new Fish() {Id=_nextId++, Length=1000, Name="Dilnaz", Species="Clownfish"}
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
        };

        public List<Fish> GetAll()
        {
            return new List<Fish>(Data);
        }

        public Fish GetById(int id)
        {
            return Data.Find(fish => fish.Id == id);
        }

        public Fish Add(Fish newFish)
        {
            newFish.Id = _nextId++;
            Data.Add(newFish);
            return newFish;
        }

        public Fish Delete(int id)
        {
            Fish fish = Data.Find(fish1 => fish1.Id == id);
            if (fish == null) return null;
            Data.Remove(fish);
            return fish;
        }

        public Fish Update(int id, Fish updates)
        {
            Fish fish = Data.Find(player1 => player1.Id == id);
            if (fish == null) return null;
            fish.Name = updates.Name;
            fish.Length= updates.Length;
            fish.Species = updates.Species;
            return fish;
        }
    }
}
