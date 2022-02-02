using webapp.Models;

namespace webapp.Services
{
    public static class CatService
    {
        static List<Cat> Cats { get; }
        static int nextId = 3;
        static CatService() {
            Cats = new List<Cat> {
                new Cat { Id = 1, Name = "Garfield", Age = 10 },
                new Cat { Id = 2, Name = "Tom", Age = 5 }
            };
        }

        public static List<Cat> GetAll => Cats;
        
        public static Cat? Get(int id) => Cats.FirstOrDefault(c => c.Id == id);

        public static void Add(Cat cat) {
            cat.Id = nextId++;
            Cats.Add(cat);
        }

        public static void Delete(int id) {
            var cat = Get(id);
            if (cat is null) return;

            Cats.Remove(cat);
        }

        public static void Update(Cat cat) {
            var index = Cats.FindIndex(c => c.Id == cat.Id);
            if (index < 0) return;

            Cats[index] = cat;
        }
    }
}