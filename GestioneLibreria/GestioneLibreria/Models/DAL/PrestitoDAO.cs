using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibreria.Models.DAL
{
    internal class PrestitoDAO : IDaoLettura<Prestito>, IDaoInserimento<Prestito>
    {
        #region SINGLETON
        private static PrestitoDAO? instance;
        public static PrestitoDAO GetInstance()
        {
            if (instance == null)
                instance = new PrestitoDAO();
            return instance;
        }
        private PrestitoDAO() { }
        #endregion
        #region GET ALL
        public List<Prestito> GetAll()
        {
            List<Prestito> risultato = new List<Prestito>();

            using (SqlConnection connessione = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connessione;
                cmd.CommandText = "SELECT prestitoID, codicePrestito, data_inizio, data_fine, utenteRIF, libroRIF FROM Prestito";
                try
                {
                    connessione.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prestito temp = new Prestito()
                        {
                            PrestitoID = reader.GetInt32(0),
                            CodicePrestito = reader.GetString(1),
                            DataInizio = reader.GetDateTime(2),
                            DataFine = reader.GetDateTime(3),
                            UtenteRIF = reader.GetInt32(4),
                            LibroRIF = reader.GetInt32(5)
                        };
                        risultato.Add(temp);
                        Console.WriteLine(temp);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"CHIAMANTE: PrestitoDAO GetALL\n" +
                        $"Messaggio:{ex.Message}");
                }
            }

            return risultato;
        }
        #endregion
        #region GET BY CODICE
        public Prestito GetByCodice(string codice)
        {
            Prestito? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT prestitoID, codicePrestito, data_inizio, data_fine, utenteRIF, libroRIF FROM Prestito WHERE codicePrestito = @varCodice";
                cmd.Parameters.AddWithValue("@varCodice", codice);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Prestito()
                            {
                                PrestitoID = reader.GetInt32(0),
                                CodicePrestito = reader.GetString(1),
                                DataInizio = reader.GetDateTime(2),
                                DataFine = reader.GetDateTime(3),
                                UtenteRIF = reader.GetInt32(4),
                                LibroRIF = reader.GetInt32(5)
                            };
                        }
                        Console.WriteLine(risultato);
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
        public Prestito GetById(int codiceId)
        {
            Prestito? risultato = null!;

            using (SqlConnection con = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT prestitoID, codicePrestito, data_inizio, data_fine, utenteRIF, libroRIF FROM Libro WHERE libroId = @varCodiceId";
                cmd.Parameters.AddWithValue("@varCodiceId", codiceId);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        {
                            risultato = new Prestito()
                            {
                                PrestitoID = reader.GetInt32(0),
                                CodicePrestito = reader.GetString(1),
                                DataInizio = reader.GetDateTime(2),
                                DataFine = reader.GetDateTime(3),
                                UtenteRIF = reader.GetInt32(4),
                                LibroRIF = reader.GetInt32(5)
                            };
                        }
                        Console.WriteLine(risultato);
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
        public bool Insert(Prestito obj)
        {
            bool risultato = false;

            using (SqlConnection connection = new SqlConnection(Config.credenziali))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                cmd.CommandText = "INSERT INTO Prestito (data_inizio, data_fine, utenteRIF, libroRIF) VALUES " +
                    "(@dataInizio, @dataFine, @utenteRIF, @libroRIF)";
                cmd.Parameters.AddWithValue("@dataInizio", obj.DataInizio);
                cmd.Parameters.AddWithValue("@dataFine", obj.DataFine);
                cmd.Parameters.AddWithValue("@utenteRIF", obj.UtenteRIF);
                cmd.Parameters.AddWithValue("@libroRIF", obj.LibroRIF);

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
                    Console.WriteLine($"CHIAMANTE: PrestitoDAO Insert, Messaggio: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return risultato;
        }
        #endregion
        public bool Update(Prestito obj)
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
                cmd.CommandText = "DELETE FROM Prestito WHERE codicePrestito = @varCodice";
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
                cmd.CommandText = "DELETE FROM Prestito WHERE prestitoID = @varCodice";
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
    }
}
