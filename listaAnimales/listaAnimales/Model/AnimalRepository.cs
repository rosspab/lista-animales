using System;
using listaAnimales.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace listaAnimales.Model
{
	public class AnimalRepository
	{
        public IList<Animal> Animales { get; set; }

        public AnimalRepository()
        {
            Task.Run(async () =>
                       Animales = await App.DataBase.GetItemsAsync()).Wait();
        }

        public IList<Animal> GetAll()
        {
            return Animales;
        }

        public IList<Animal> GetAllByFirstLetter(string letter)
        {
            var query = from q in Animales
                        where q.Nombre.StartsWith(letter)
                        select q;

            return query.ToList();
        }

        public ObservableCollection<Grouping<string, Animal>> GetAllGrouped()
        {
            IEnumerable<Grouping<string, Animal>> sorted = new Grouping<string, Animal>[0];
            if (Animales != null)
            {
                sorted =
                    from f in Animales
                    orderby f.Nombre
                    group f by f.Nombre[0].ToString().ToUpper()
                    into theGroup
                    select
                    new Grouping<string, Animal>
                        (theGroup.Key, theGroup);
            }


            return new
                ObservableCollection
                <Grouping<string, Animal>>(sorted);
        }
    }
}

