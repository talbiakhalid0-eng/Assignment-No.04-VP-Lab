using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace Assignment_No._04_VP_LAB.Application_08
{
    public class TodoDatabaseService
    {
		private readonly string _connectionString =
			"Server=localhost;Database=AirUniversityDB;Trusted_Connection=True;TrustServerCertificate=True;Application Name='Assignment No.04 VP LAB';";

		public List<TodoTaskDataModel> FetchTasks()
		{
			var tasks = new List<TodoTaskDataModel>();

			using (var connection = new SqlConnection(_connectionString))
			{
				using (var command = new SqlCommand("SELECT TaskId, TaskDescription FROM TodoRegistry ORDER BY TaskId DESC", connection))
				{
					connection.Open();
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							tasks.Add(new TodoTaskDataModel
							{
								TaskId = reader.GetInt32(0),
								TaskDescription = reader.GetString(1)
							});
						}
					}
				}
			}
			return tasks;
		}

		public void InsertTask(string description)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var command = new SqlCommand("INSERT INTO TodoRegistry (TaskDescription) VALUES (@desc)", connection))
				{
					command.Parameters.AddWithValue("@desc", description);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}

		public void DeleteTask(int id)
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var command = new SqlCommand("DELETE FROM TodoRegistry WHERE TaskId = @id", connection))
				{
					command.Parameters.AddWithValue("@id", id);
					connection.Open();
					command.ExecuteNonQuery();
				}
			}
		}
	}
}
