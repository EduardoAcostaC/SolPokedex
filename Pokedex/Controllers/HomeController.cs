using Pokedex.Datos;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Pokemon> listaPokemon = new List<Pokemon>();
            try
            {
                D_Pokemon pokemon = new D_Pokemon();
                listaPokemon = pokemon.ObtenerTodos();
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View("VistaPrincipal", listaPokemon);
        }

        public ActionResult IrFormulario()
        {
            return View("VistaFormulario");
        }

        public ActionResult FormularioPOST(Pokemon objPokemon)
        {
            try
            {
                D_Pokemon datos = new D_Pokemon();
                datos.AgregarPokemon(objPokemon);
                TempData["mensaje"] = $"El pokemon {objPokemon.nombre} has sido agregado con éxito a la Pokédex";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }

        }

        public ActionResult Editar(int id)
        {
            try
            {
                D_Pokemon datos = new D_Pokemon();
                Pokemon objPokemon = datos.ObtenerPokemonPorId(id);
                return View("VistaEditar", objPokemon);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult EditarPOST(Pokemon pokemon)
        {
            try
            {
                D_Pokemon datos = new D_Pokemon();
                datos.EditarPokemon(pokemon);
                TempData["mensaje"] = $"El pokémon {pokemon.nombre} ha sido actualizado correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                D_Pokemon datos = new D_Pokemon();
                Pokemon objPokemon = datos.ObtenerPokemonPorId(id);
                return View("VistaEliminar", objPokemon);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }
        }

        public ActionResult EliminarPokemon(int id)
        {
            try
            {
                D_Pokemon datos = new D_Pokemon();
                datos.EliminarOtroPokemon(id);

                TempData["mensaje"] = $"El pokémon ha sido eliminado de la Pokédex";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}