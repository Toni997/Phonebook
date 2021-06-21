using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MojiKontaktiAPI.DTOs;
using MojiKontaktiAPI.IRepository;
using MojiKontaktiAPI.Models;

namespace MojiKontaktiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KontaktiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<KontaktiController> _logger;
        //private readonly MojiKontaktiDbContext _context;

        public KontaktiController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<KontaktiController> logger
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // Get all contacts @api/kontakti
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetContacts()
        {
            //return await context.Kontakti
            //                                .Include(k => k.EmailAdrese)
            //                                .Include(k => k.BrojeviTelefona)
            //                                .Include(k => k.Tagovi)
            //                                .OrderBy(k => k.Ime)
            //                                .ToListAsync();

            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll();
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somethign went wrong in the {nameof(GetContacts)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get all contacts that contain keyword in the name @api/kontakti/po-imenu/{keyword}
        //[HttpGet("po-imenu/{keyword}")]
        //public async Task<ActionResult<IEnumerable<Kontakt>>> GetByName(string keyword)
        //{
        //    return await context.Kontakti.Where(kontakt => kontakt.Ime.Contains(keyword))
        //                                    .Include(k => k.EmailAdrese)
        //                                    .Include(k => k.BrojeviTelefona)
        //                                    .Include(k => k.Tagovi)
        //                                    .OrderBy(k => k.Ime)
        //                                    .ToListAsync();


        //}

        //// Get all contacts that contain keyword in the surname @api/kontakti/po-prezimenu/{keyword}
        //[HttpGet("po-prezimenu/{keyword}")]
        //public async Task<ActionResult<IEnumerable<Kontakt>>> GetBySurname(string keyword)
        //{
        //    return await context.Kontakti.Where(kontakt => kontakt.Prezime.Contains(keyword))
        //                                    .Include(k => k.EmailAdrese)
        //                                    .Include(k => k.BrojeviTelefona)
        //                                    .Include(k => k.Tagovi)
        //                                    .OrderBy(k => k.Ime)
        //                                    .ToListAsync();
        //}

        //// Get all contacts that contain keyword in the tags @api/kontakti/po-tagu/{keyword}
        //[HttpGet("po-tagu/{keyword}")]
        //public async Task<ActionResult<IEnumerable<Kontakt>>> GetByTag(string keyword)
        //{
        //    return await context.Kontakti
        //                                    .Include(k => k.EmailAdrese)
        //                                    .Include(k => k.BrojeviTelefona)
        //                                    .Include(k => k.Tagovi)
        //                                    .Where(kontakt => kontakt.Tagovi.Any(tag => tag.Naziv.Contains(keyword)))
        //                                    .OrderBy(k => k.Ime)
        //                                    .ToListAsync();
        //}

        //// Get all contacts that are favorited @api/kontakti/samo-favoriti
        //[HttpGet("samo-favoriti")]
        //public async Task<ActionResult<IEnumerable<Kontakt>>> GetFavorites()
        //{
        //    return await context.Kontakti.Where(kontakt => kontakt.Bookmarkiran)
        //                                    .Include(k => k.EmailAdrese)
        //                                    .Include(k => k.BrojeviTelefona)
        //                                    .Include(k => k.Tagovi)
        //                                    .OrderBy(k => k.Ime)
        //                                    .ToListAsync();
        //}

        // Get contact by id @api/kontakti/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Kontakt>> GetContact(int id)
        {
            try
            {
                var kontakt = await _unitOfWork.Kontakti.Get(k => k.KontaktID == id,
                    new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                
                if (kontakt == null)
                {
                    return NotFound();
                }

                var rezultat = _mapper.Map<KontaktDTO>(kontakt);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Somethign went wrong in the {nameof(GetContact)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

        //// Create contact @api/kontakti
        //[HttpPost]
        //public async Task<ActionResult<Kontakt>> Post([FromBody] KontaktIzradaDTO kontaktIzradaDTO)
        //{
        //    var kontakt = mapper.Map<Kontakt>(kontaktIzradaDTO);
        //    context.Add(kontakt);
        //    await context.SaveChangesAsync();

        //    return await Task.FromResult(kontakt);
        //}

        //// Update contact @api/kontakti/{id}
        //[HttpPut("{id:int}")]
        //public async Task<ActionResult> Put(int id, [FromBody] KontaktIzradaDTO kontaktIzradaDTO)
        //{
        //    // needs a better solution
        //    var kontakt = context.Kontakti
        //                                    .Include(k => k.EmailAdrese)
        //                                    .Include(k => k.BrojeviTelefona)
        //                                    .Include(k => k.Tagovi)
        //                                    .FirstOrDefaultAsync(k => k.KontaktID == id);
        //    if (kontakt == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Kontakti.Attach(kontakt.Result);
        //    context.Kontakti.Update(kontakt.Result);

        //    kontakt.Result.Ime = kontaktIzradaDTO.Ime;
        //    kontakt.Result.Prezime = kontaktIzradaDTO.Prezime;
        //    kontakt.Result.Nadimak = kontaktIzradaDTO.Nadimak;
        //    kontakt.Result.Adresa = kontaktIzradaDTO.Adresa;
        //    kontakt.Result.Bookmarkiran = kontaktIzradaDTO.Bookmarkiran;
        //    kontakt.Result.EmailAdrese = mapper.Map<IList<EmailAdresa>>(kontaktIzradaDTO.EmailAdrese);
        //    kontakt.Result.BrojeviTelefona = mapper.Map<IList<BrojTelefona>>(kontaktIzradaDTO.BrojeviTelefona);
        //    kontakt.Result.Tagovi = mapper.Map<IList<Tag>>(kontaktIzradaDTO.Tagovi);

        //    await context.SaveChangesAsync();
        //    return NoContent();
        //}

        //// Delete contact @api/kontakti/{id}
        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult<Kontakt>> Delete(int id)
        //{
        //    Kontakt kontakt = await context.Kontakti
        //                                    .FirstOrDefaultAsync(kontakt => kontakt.KontaktID == id);

        //    if (kontakt == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Kontakti.Remove(kontakt);
        //    await context.SaveChangesAsync();

        //    return kontakt;
        //}
    }
}
