using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pokedex.Datos
{
    public class D_Pokemon
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public List<Pokemon> ObtenerTodos()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                List<Pokemon> lista = new List<Pokemon>();
                conexion.Open();

                string query = "SELECT idPokemon, nombre, tipo, generacion, evoluciones, obtenido,numeroPokemon " +
                    "FROM Pokemones";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Pokemon objPokemon = new Pokemon();
                    objPokemon.idPokemon = Convert.ToInt32(reader["idPokemon"]);
                    objPokemon.nombre = reader["nombre"].ToString();
                    objPokemon.tipo = reader["tipo"].ToString();
                    objPokemon.generacion = Convert.ToInt32(reader["generacion"]);
                    objPokemon.evoluciones = Convert.ToInt32(reader["evoluciones"]);
                    objPokemon.obtenido = Convert.ToBoolean(reader["obtenido"]);
                    objPokemon.numeroPokemon = reader["numeroPokemon"].ToString();
                    lista.Add(objPokemon);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void AgregarPokemon(Pokemon pokemon)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                string query = "INSERT INTO Pokemones (nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon) " +
                    "VALUES(@parametro1, @parametro2, @parametro3, @parametro4, @parametro5, @parametro6);";

                SqlCommand comando = new SqlCommand(query, conexion);

                //Asignando valores a los parametros del query
                comando.Parameters.AddWithValue("@parametro1", pokemon.nombre);
                comando.Parameters.AddWithValue("@parametro2", pokemon.tipo);
                comando.Parameters.AddWithValue("@parametro3", pokemon.generacion);
                comando.Parameters.AddWithValue("@parametro4", pokemon.evoluciones);
                comando.Parameters.AddWithValue("@parametro5", pokemon.obtenido);
                comando.Parameters.AddWithValue("@parametro6", pokemon.numeroPokemon);

                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }

        }

        public  Pokemon ObtenerPokemonPorId(int idPokemon)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                string query = "SELECT idPokemon, nombre, tipo, generacion, evoluciones, obtenido, numeroPokemon " +
                    "FROM Pokemones WHERE idPokemon = @parametro1;";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@parametro1", idPokemon);

                SqlDataReader reader = comando.ExecuteReader();

                reader.Read();

                //Creando un empleado
                Pokemon objPokemon = new Pokemon();
                objPokemon.idPokemon = Convert.ToInt32(reader["idPokemon"]);
                objPokemon.nombre = reader["nombre"].ToString();
                objPokemon.tipo = reader["tipo"].ToString();
                objPokemon.generacion = Convert.ToInt32(reader["generacion"]);
                objPokemon.evoluciones = Convert.ToInt32(reader["evoluciones"]);
                objPokemon.obtenido = Convert.ToBoolean(reader["obtenido"]);
                objPokemon.numeroPokemon = reader["numeroPokemon"].ToString();


                conexion.Close();
                return objPokemon;

            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }
        }

        public void EditarPokemon(Pokemon pokemon)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                string query = "UPDATE Pokemones SET nombre = @parametro1, tipo = @parametro2, generacion = @parametro3, evoluciones = @parametro4, obtenido = @parametro5, numeroPokemon = @parametro6 " +
                    "WHERE idPokemon = @parametro7;";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@parametro1", pokemon.nombre);
                comando.Parameters.AddWithValue("@parametro2", pokemon.tipo);
                comando.Parameters.AddWithValue("@parametro3", pokemon.generacion);
                comando.Parameters.AddWithValue("@parametro4", pokemon.evoluciones);
                comando.Parameters.AddWithValue("@parametro5", pokemon.obtenido);
                comando.Parameters.AddWithValue("@parametro6", pokemon.numeroPokemon);
                comando.Parameters.AddWithValue("@parametro7", pokemon.idPokemon);

                comando.ExecuteNonQuery();

                conexion.Close();


            }
            catch (Exception ex)
            {
                conexion.Close();
                throw ex;
            }

        }

        public void EliminarOtroPokemon(int idPokemon)
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            try
            {
                conexion.Open();

                string query = "DELETE Pokemones WHERE idPokemon = @parametro1;";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@parametro1", idPokemon);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

    }
}