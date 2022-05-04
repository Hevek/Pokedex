using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poke.Models;

namespace Poke.Controllers
{
    public class PokemonController : Controller
    {
        private readonly Poke.Data.AppContext _appContext;
        public PokemonController(Poke.Data.AppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IActionResult> Home1()
        {
            var trainers = await _appContext.PokesM.ToListAsync();
            return View(trainers);
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create (TrainerM trainer, IList<IFormFile> Img)
        {
            //Verificar tamanho da imagem
            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if(Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                trainer.Picture = ms.ToArray();
            }
            _appContext.TrainersM.Add(trainer);
           await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateP()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateP (PokeM pokemon, IList<IFormFile> ImgP)
        {
            IFormFile uploadedImage = ImgP.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (ImgP.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                pokemon.PictureP = ms.ToArray();
            }
            _appContext.PokesM.Add(pokemon);
           await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsTrainer (Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var trainers = await _appContext.TrainersM.FindAsync(id);

            if(trainers == null)
            {
                return BadRequest();
            }

            return View(trainers);

        }

        [HttpGet]
        public async Task<IActionResult> DetailsPokemon (Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poke = await _appContext.PokesM.FindAsync(id);

            if (poke == null)
            {
                return BadRequest();
            }
            return View(poke);
        }

        [HttpGet]
        public async Task<IActionResult> EditTrainers (Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainers = await _appContext.TrainersM.FindAsync(id);

            if (trainers == null)
            {
                return BadRequest();
            }

            return View(trainers);

        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTrainers(Guid? id, TrainerM trainer, IList<IFormFile> Img)
        {
            if(id == null)
            {
                return NotFound();
            }

            var Olddata = _appContext.TrainersM.AsNoTracking().FirstOrDefault(t => t.IdT == id);

            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                trainer.Picture = ms.ToArray();
            }
            else
            {
                trainer.Picture = Olddata.Picture;
            }
            if (ModelState.IsValid)
            {
                _appContext.Update(trainer);
                await _appContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainer);
        }

        [HttpGet]
        public async Task<IActionResult> EditPokemon(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poke = await _appContext.PokesM.FindAsync(id);

            if (poke == null)
            {
                return BadRequest();
            }

            return View(poke);

        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPokemon(Guid? id, PokeM pokemon, IList<IFormFile> ImgP)
        {
            if (id == null)
            {
                return NotFound();
            }

            var OlddataP = _appContext.PokesM.AsNoTracking().FirstOrDefault(p => p.IdP == id);

            IFormFile uploadedImage = ImgP.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (ImgP.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                pokemon.PictureP = ms.ToArray();
            }
            else
            {
                pokemon.PictureP = OlddataP.PictureP;
            }
            if (ModelState.IsValid)
            {
                _appContext.Update(pokemon);
                await _appContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemon);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTrainer (Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainerD = await _appContext.TrainersM.FindAsync(id);
            if (trainerD == null)
            {
                return BadRequest();
            }
            return View(trainerD);

        }

        [HttpPost, ActionName("Delete Trainer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedT(Guid? id)
        {
            var trainerDel = await _appContext.TrainersM.FindAsync(id);
            _appContext.TrainersM.Remove(trainerDel);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> DeletePokemon(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var pokemonD = await _appContext.PokesM.FindAsync(id);
            if(pokemonD == null)
            {
                return BadRequest();
            }
            return View(pokemonD);
        }
        [HttpPost,ActionName("DeletePokemon")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedP(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var pokemonDel = await _appContext.PokesM.FindAsync(id);
            if (pokemonDel == null)
            {
                return BadRequest();
            }
            _appContext.PokesM.Remove(pokemonDel);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //var pokemonDel = await _appContext.PokesM.FindAsync(id);
        //_appContext.PokesM.Remove(pokemonDel);
        //await _appContext.SaveChangesAsync();
        //return RedirectToAction("Index");
    }
}