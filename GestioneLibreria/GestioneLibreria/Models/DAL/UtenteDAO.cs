using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models.DAL
{
    internal class UtenteDAO : IDaoInserimento<Utente>, IDaoLettura<Utente>
    {
        #region Singleton
        private static UtenteDAO? instance;
        public static UtenteDAO GetInstance() 
        {
            if(instance == null)
                instance = new UtenteDAO();
            return instance;
        }
        private UtenteDAO() { }
        #endregion
        #region DELETE BY CODICE
        public bool Delete(string codice)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "DELETE FROM Utente WHERE codiceUtente = @varCodice";
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
                cmd.CommandText = "DELETE FROM Utente WHERE utenteID = @varCodice";
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
        #region GET ALL
        public List<Utente> GetAll()
        {
            List<Utente> risultato = new List<Utente>();

            using (SqlConnection connessione = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT utenteID, codiceUtente, nome, cognome, email FROM Utente";
                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Utente temp = new Utente()
                        {
                            UtenteID = reader.GetInt32(0),
                            CodiceUtente = reader.GetString(1),
                            Nome = reader.GetString(2),
                            Cognome = reader.GetString(3),
                            Email = reader.GetString(4)
                        };
                        risultato.Add(temp);
                        Console.WriteLine(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CHIAMANTE: UtenteDAO GetALL\n" +
                        $"Messaggio:{ex.Message}");
                }
            }

            return risultato;
        }
        #endregion
        #region GET BY CODICE
        public Utente GetByCodice(string codice)
        {
            Utente? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT utenteId, codiceUtente, nome, cognome, email FROM Utente WHERE codiceUtente = @varCodice";
                cmd.Parameters.AddWithValue("@varCodice", codice);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Utente()
                            {
                                UtenteID = reader.GetInt32(0),
                                CodiceUtente = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Cognome = reader.GetString(3),
                                Email = reader.GetString(4)
                            };
                        }
                        Console.WriteLine(risultato.StampaDettaglioUtente());
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
        public Utente GetById(int codiceId)
        {
            Utente? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT utenteId, codiceUtente, nome, cognome, email FROM Utente WHERE utenteId = @varCodiceId";
                cmd.Parameters.AddWithValue("@varCodiceId", codiceId);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Utente()
                            {
                                UtenteID = reader.GetInt32(0),
                                CodiceUtente = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Cognome = reader.GetString(3),
                                Email = reader.GetString(4)
                            };
                        }
                        Console.WriteLine(risultato.StampaDettaglioUtente());
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
        public bool Insert(Utente obj)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO Utente (nome, cognome, email) VALUES " +
                    "(@nome, @cognome, @email)";
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@cognome", obj.Cognome);
                cmd.Parameters.AddWithValue("@email", obj.Email);

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
                    Console.WriteLine($"CHIAMANTE: UtenteDAO Insert, Messaggio: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return risultato;
        }
        #endregion
        public bool Update(Utente obj)
        {
            throw new NotImplementedException();
        }
    }
}
