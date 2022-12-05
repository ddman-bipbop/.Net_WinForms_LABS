using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Lab11.Models
{
    public class Kind_sport
    {
        private static readonly string _selectKindSportCommand = @"SELECT [id_kind],[Name_kind],[Group_kind] FROM [DotNet].[dbo].[Kind_sport]";
        private static readonly string _insertKindSportCommand = @"INSERT INTO [DotNet].[dbo].[Kind_sport] ([Name_kind],[Group_kind]) VALUES (@Name_kind, @Group_kind)";
        private static readonly string _updateKindSportCommand = @"UPDATE [DotNet].[dbo].[Kind_sport] SET [Name_kind] = @Name_kind, [Group_kind] = @Group_kind WHERE [id_kind] = @id_kind";
        private static readonly string _deleteKindSportCommand = @"DELETE FROM [DotNet].[dbo].[Kind_sport] WHERE [id_kind] = @id_kind";

        public int IdKind { get; set; }
        public string NameKind { get; set; }
        public string GroupKind { get; set; }

        public static List<Kind_sport> List(SqlConnection connection)
        {
            List<Kind_sport> users = new List<Kind_sport>();
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _selectKindSportCommand;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Kind_sport user = new Kind_sport
                        {

                            GroupKind = (string)reader["Group_kind"],
                            NameKind = (string)reader["Name_kind"],
                            IdKind = (int)reader["id_kind"]
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

        public static void Insert(SqlConnection connection, Kind_sport user)
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _insertKindSportCommand;
                    command.CommandType = CommandType.Text;
                    
                    command.Parameters.Add("@Group_kind", SqlDbType.NVarChar, 32).Value = user.GroupKind;
                    command.Parameters.Add("@Name_kind", SqlDbType.NVarChar, 32).Value = user.NameKind;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public static void Update(SqlConnection connection, Kind_sport user)
        {
            using (SqlCommand command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _updateKindSportCommand;
                    command.CommandType = CommandType.Text;
                 
                    command.Parameters.Add("@Group_kind", SqlDbType.NVarChar, 32).Value = user.GroupKind;
                    command.Parameters.Add("@Name_kind", SqlDbType.NVarChar, 32).Value = user.NameKind;
                    command.Parameters.Add("@id_kind", SqlDbType.Int).Value = user.IdKind;
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
                    command.CommandText = _deleteKindSportCommand;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("@id_kind", SqlDbType.Int).Value = userId;
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
