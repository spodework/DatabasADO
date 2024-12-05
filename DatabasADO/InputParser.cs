
namespace DatabasADO
{
    // Reads input string, expects <firstname lastname>, splits in firstname lastname (actor format)
    public class InputParser
    {
        public Actor? ParseActorInput(string input)
        {
            var nameParts = input.ToUpper().Split(' ');

            if (nameParts.Length != 2)
            {
                Console.WriteLine("Please enter in format <firstname> <lastname>");
                return null;
            }

            return new Actor
            {
                FirstName = nameParts[0],
                LastName = nameParts[1]
            };
        }
    }

}
