namespace DatabasADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter film actor in format <firstname> <lastname>: ");
            var input = Console.ReadLine() ?? "";

            InputParser parser = new InputParser();
            Actor actor = parser.ParseActorInput(input);

            if (actor != null)
            {
                DatabaseHandler databaseHandler = new DatabaseHandler();
                ActorHandler actorHandler = new ActorHandler(databaseHandler);
                actorHandler.PrintFilms(actor);
            }
        }
    }
}
