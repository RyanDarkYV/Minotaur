using System.Threading.Tasks;

namespace Minotaur.CommonParts.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}