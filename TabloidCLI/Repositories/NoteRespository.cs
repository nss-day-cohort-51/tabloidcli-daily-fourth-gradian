using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.Repositories
{
    public class NoteRepository : DatabaseConnector, IRepository<Note>
    {
        public NoteRepository(string connectionString) : base(connectionString) { }

        public List<Note> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                                Content,
                                                CreateDatetime
                                          FROM Note";

                    List<Note> notes = new List<Note>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Note note = new Note()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Title")),
                            CreationDate = reader.GetDateTime((reader.GetOrdinal("CreateDatetime")))
                        };
                        notes.Add(note);
                    }

                    reader.Close();

                    return notes;
                }
            }
        }

        public Note Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT b.Id,
                                               b.Title,
                                               b.Url,
                                               t.Id as TagId,
                                               t.Name
                                          FROM Blog b
                                               LEFT JOIN BlogTag bt ON b.Id = bt.BlogId
                                               LEFT JOIN Tag t ON t.Id = bt.TagId
                                         WHERE b.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    Note note = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (note == null)
                        {
                            note = new Note()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Content = reader.GetString(reader.GetOrdinal("Content")),
                                CreationDate = reader.GetDateTime((reader.GetOrdinal("CreateDateTime")))
                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            //note.Add(new Note()
                            //{
                            //    Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                            //    Name = reader.GetString(reader.GetOrdinal("Name")),
                            //});
                        }

                    }

                    reader.Close();

                    return note;
                }
            }
        }

        public void Insert(Note note)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Note (Title,Text, Content,CreateDateTime,PostId )
                                                     VALUES (@Title,Text, @Content,@DateTime,@PostId)";
                    cmd.Parameters.AddWithValue("@Title", note.Title);
                    cmd.Parameters.AddWithValue("@Text", note.Text);
                    cmd.Parameters.AddWithValue("@Content", note.Content);
                    cmd.Parameters.AddWithValue("@DateTime", note.CreationDate);
                    cmd.Parameters.AddWithValue("@PostId", note.Post.Id);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Note blog)
        {
            //using (SqlConnection conn = Connection)
            //{
            //    conn.Open();
            //    using (SqlCommand cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = @"UPDATE Blog 
            //                               SET Title = @Title,
            //                                   Url = @url
            //                             WHERE id = @id";

            //        cmd.Parameters.AddWithValue("@Title", blog.Title);
            //        cmd.Parameters.AddWithValue("@url", blog.Url);
            //        cmd.Parameters.AddWithValue("@id", blog.Id);


            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Note WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertTag(Blog blog, Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO BlogTag (BlogId, TagId)
                                                       VALUES (@blogId, @tagId)";
                    cmd.Parameters.AddWithValue("@blogId", blog.Id);
                    cmd.Parameters.AddWithValue("@tagId", tag.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTag(int blogId, int tagId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM BlogTAg 
                                         WHERE BlogId = @blogid AND 
                                               TagId = @tagId";
                    cmd.Parameters.AddWithValue("@blogId", blogId);
                    cmd.Parameters.AddWithValue("@tagId", tagId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}