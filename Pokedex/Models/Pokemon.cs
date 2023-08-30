using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Security.Policy;


namespace Pokedex.Models
{
    public class Pokemon
    {
        public int idPokemon { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public int generacion { get; set; }
        public int evoluciones { get; set; }
        public bool obtenido { get; set; }
        public string numeroPokemon { get; set; }

        public string pokemonObtenido
        {
            get
            {
                if (obtenido)
                    return "Si";
                else
                    return "No";
            }
        }
        
        public string imgPokemon
        {
            get
            {
                if (numeroPokemon.Length <= 3)
                {
                    int longitudDeseada = 3; // Longitud total deseada, incluyendo los ceros de relleno
                    char caracterRelleno = '0'; // Carácter de relleno (cero)
                    string numeroFormateado = numeroPokemon.PadLeft(longitudDeseada, caracterRelleno);
                    string imageUrl = $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{numeroFormateado}.png";
                    return imageUrl;
                }
                else
                {
                    string imageUrl = $"https://assets.pokemon.com/assets/cms2/img/pokedex/full/{numeroPokemon}.png";
                    return imageUrl;
                }
                
            }
        }
    }
}