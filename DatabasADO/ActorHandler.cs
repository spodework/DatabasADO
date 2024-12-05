using DatabasADO;

public class ActorHandler
{
    private readonly DatabaseHandler _databaseHandler;

    public ActorHandler(DatabaseHandler databaseHandler)
    {
        _databaseHandler = databaseHandler;
    }

    public void PrintFilms(Actor actor)
    {
        var films = _databaseHandler.GetFilmsForActor(actor.FirstName, actor.LastName);
       
        if (films.Count == 0)
        {
            Console.WriteLine($"No films found for {actor.FirstName} {actor.LastName}");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{actor.FirstName} {actor.LastName} has been in following films:");

        StringFormattingHelper.PrintTitlesWithIndex(films);
    }
}
