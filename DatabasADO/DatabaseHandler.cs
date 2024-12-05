using DatabasADO;
using Microsoft.Data.SqlClient;

// Class for connecting to SQL database and finding movies for input actor
public class DatabaseHandler
{
    private readonly string _connectionString =
        "Data Source=(localdb)\\MSSQLLocalDB;" +
        "Initial Catalog=Sakila;" +
        "Integrated Security=True;" +
        "Connect Timeout=30;" +
        "Encrypt=False;" +
        "Trust Server Certificate=False;" +
        "Application Intent=ReadWrite;" +
        "Multi Subnet Failover=False";

    private const string _sqlQuery = @"select actor.actor_id, actor.first_name, actor.last_name, film.title
                FROM actor
                INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
                INNER JOIN film ON film_actor.film_id = film.film_id
                WHERE actor.first_name = @FirstName AND actor.last_name = @LastName";

    // Connects to database and adds found films to films list
    public List<Film> GetFilmsForActor(string firstName, string lastName)
    {
        var films = new List<Film>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(_sqlQuery, connection))
            {
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine($"Error! SQL query returned nothing for: {firstName} {lastName}");
                        return films;
                    }

                    while (reader.Read())
                    {
                        string actorId = reader["actor_id"].ToString() ?? "";
                        string title = reader["title"].ToString() ?? "";

                        films.Add(new Film
                        {
                            Title = title,
                        });
                    }
                }
            }
        }

        return films;
    }
}
