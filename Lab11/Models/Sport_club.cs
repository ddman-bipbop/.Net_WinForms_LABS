using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Lab11.Models
{
    public class Sport_club
    {
        private static readonly string _selectSportClubCommand = @"SELECT [id_club],[id_kind],[Name_club],[Text_club],[CreateDate_club] FROM [DotNet].[dbo].[Sport_club]";
        private static readonly string _insertSportClubCommand = @"INSERT INTO [DotNet].[dbo].[Sport_club] ([id_kind],[Name_club],[Text_club],[CreateDate_club]) VALUES (@id_kind, @Name_club,@Text_club,@CreateDate_club)";
        private static readonly string _updateSportClubCommand = @"UPDATE [DotNet].[dbo].[Sport_club] SET [id_kind] = @id_kind, [Name_club] = @Name_club,[Text_club] = @Text_club,[CreateDate_club] = @CreateDate_club  WHERE [id_club] = @id_club";
        private static readonly string _deleteSportClubCommand = @"DELETE FROM [DotNet].[dbo].[Sport_club] WHERE [id_club] = @id_club";

        public int IdClub { get; set; }
        public int IdKind { get; set; }
        public string NameClub { get; set; }
        public string TextClub { get; set; }
        public DateTime CreateDateClub { get; set; } = DateTime.Now;

        public static List<Sport_club> List(SqlConnection connection)
        {
            List<Sport_club> users = new List<Sport_club>();
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _selectSportClubCommand;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Sport_club user = new Sport_club
                        {
                            IdClub = (int)reader["id_club"],
                            IdKind = (int)reader["id_kind"],                         
                            NameClub = (string)reader["Name_club"],
                            TextClub = (string)reader["Text_club"],
                            CreateDateClub = (DateTime)reader["CreateDate_club"]                        
                        };
                        users.Add(user);
                    }

                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
            return users;
        }

        public static void Insert(SqlConnection connection, Sport_club user)
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _insertSportClubCommand;
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add("@id_kind", SqlDbType.Int,32).Value = user.IdKind;
                    command.Parameters.Add("@Name_club", SqlDbType.NVarChar, 32).Value = user.NameClub;
                    command.Parameters.Add("@Text_club", SqlDbType.NVarChar, 32).Value = user.TextClub;
                    command.Parameters.Add("@CreateDate_club", SqlDbType.NVarChar, 32).Value = user.CreateDateClub;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static void Update(SqlConnection connection, Sport_club user)
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _updateSportClubCommand;
                    command.CommandType = CommandType.Text;

                    command.Parameters.Add("@id_kind", SqlDbType.Int,32).Value = user.IdKind;
                    command.Parameters.Add("@Name_club", SqlDbType.NVarChar, 32).Value = user.NameClub;
                    command.Parameters.Add("@Text_club", SqlDbType.NVarChar, 32).Value = user.TextClub;
                    command.Parameters.Add("@CreateDate_club", SqlDbType.NVarChar, 32).Value = user.CreateDateClub;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static void Delete(SqlConnection connection, int userId)
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _deleteSportClubCommand;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id_club", SqlDbType.Int,32).Value = userId;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }
    }
}
