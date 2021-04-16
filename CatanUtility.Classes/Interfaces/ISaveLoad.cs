using CatanUtility.Models;

namespace CatanUtility.Interfaces
{
    public interface ISaveLoad
    {
        bool SaveGame(Game game);
        Game LoadGame();
    }
}
