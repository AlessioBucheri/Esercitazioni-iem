using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models.DAL
{
    internal class LibroDAO : IDaoLettura<Libro>, IDaoInserimento<Libro>
    {
        #region SINGLETON
        private static LibroDAO? instance;
        public static LibroDAO GetInstance()
        {
            if (instance == null)
                instance = new LibroDAO();
            return instance;
        }
        private LibroDAO() { }
        #endregion
        #region GET ALL
        public List<Libro> GetAll()
        {
            List<Libro> risultato = new List<Libro>();

            using (SqlConnection connessione = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT libroID, titolo, anno_pubblicazione, isDisponibile FROM Libro";
                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Libro temp = new Libro()
                        {
                            LibroID = reader.GetInt32(0),
                            Titolo = reader.GetString(1),
                            AnnoPubblicazione = reader.GetString(2),
                            IsDisp = reader.GetBoolean(3)
                        };
                        risultato.Add(temp);
                        Console.WriteLine(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CHIAMANTE: LibroDAO GetALL\n" +
                        $"Messaggio:{ex.Message}");
                }
            }

            return risultato;
        }
        #endregion
        #region GET BY CODICE
        public Libro GetByCodice(string codice)
        {
            Libro? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT libroId, codiceLibro, titolo, anno_pubblicazione, isDisponibile FROM Libro WHERE codiceLibro = @varCodice";
                cmd.Parameters.AddWithValue("@varCodice", codice);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Libro()
                            {
                                LibroID = reader.GetInt32(0),
                                CodiceLibro = reader.GetString(1),
                                Titolo = reader.GetString(2),
                                AnnoPubblicazione = reader.GetString(3),
                                IsDisp = reader.GetBoolean(4)
                            };
                        }
                        Console.WriteLine(risultato.StampaDettaglioLibro());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }
        }
        #endregion
        #region GET BY ID
        public Libro GetById(int codiceId)
        {
            Libro? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT libroId, codiceLibro, titolo, anno_pubblicazione, isDisponibile FROM Libro WHERE libroId = @varCodiceId";
                cmd.Parameters.AddWithValue("@varCodiceId", codiceId);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Libro()
                            {
                                LibroID = reader.GetInt32(0),
                                CodiceLibro = reader.GetString(1),
                                Titolo = reader.GetString(2),
                                AnnoPubblicazione = reader.GetString(3),
                                IsDisp = reader.GetBoolean(4)
                            };
                        }
                        Console.WriteLine(risultato.StampaDettaglioLibro());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return risultato;
            }
        }
        #endregion
        #region INSERT
        public bool Insert(Libro obj)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO Libro (titolo, anno_pubblicazione, isDisponibile) VALUES " +
                    "(@titolo, @annoPubblicazione, @isDisp)";
                cmd.Parameters.AddWithValue("@titolo", obj.Titolo);
                cmd.Parameters.AddWithValue("@annoPubblicazione", obj.AnnoPubblicazione);
                cmd.Parameters.AddWithValue("@isDisp", obj.IsDisp);

                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        risultato = true;
                    else
                        Console.WriteLine("ERRORE");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CHIAMANTE: LibroDAO Insert, Messaggio: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return risultato;
        }
        #endregion
        public bool Update(Libro obj)
        {
            throw new NotImplementedException();

        }
        #region DELETE BY CODICE
        public bool Delete(string codice)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Libro WHERE codiceLibro = @varCodice";
                cmd.Parameters.AddWithValue("@varCodice", codice);
                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        Console.WriteLine("Cancellazione Effettuata!");
                    else
                        Console.WriteLine("ERRORE");
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
        #endregion
        #region DELETE BY ID
        public bool Delete(int id)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Libro WHERE libroID = @varCodice";
                cmd.Parameters.AddWithValue("@varCodice", id);
                try
                {
                    connection.Open();
                    int affRows = cmd.ExecuteNonQuery();
                    if (affRows > 0)
                        Console.WriteLine("Cancellazione Effettuata!");
                    else
                        Console.WriteLine("ERRORE");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return risultato;
        }
        #endregion
        #region GET ALL DISPONIBILI
        public List<Libro> GetAllDisponibile()
        {
            List<Libro> risultato = new List<Libro>();

            using (SqlConnection connessione = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT libroID, titolo, anno_pubblicazione, isDisponibile FROM Libro WHERE isDisponibile = 1";
                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Libro temp = new Libro()
                        {
                            LibroID = reader.GetInt32(0),
                            Titolo = reader.GetString(1),
                            AnnoPubblicazione = reader.GetString(2),
                            IsDisp = reader.GetBoolean(3)
                        };
                        risultato.Add(temp);
                        Console.WriteLine(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CHIAMANTE: LibroDAO GetALL\n" +
                        $"Messaggio:{ex.Message}");
                }
            }

            return risultato;
        }
        #endregion
    }
}
