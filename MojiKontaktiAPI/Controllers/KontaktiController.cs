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
            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll(
                    orderBy: k => k.OrderBy(k => k.Ime),
                    includes: new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContacts)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get all contacts that contain keyword in the name @api/kontakti/po-imenu/{keyword}
        [HttpGet("po-imenu/{keyword}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetContactsByName(string keyword)
        {
            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll(
                    expression: k => k.Ime.Contains(keyword),
                    orderBy: k => k.OrderBy(k => k.Ime),
                    includes: new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContactsByName)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get all contacts that contain keyword in the surname @api/kontakti/po-prezimenu/{keyword}
        [HttpGet("po-prezimenu/{keyword}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetContactsBySurname(string keyword)
        {
            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll(
                    expression: k => k.Prezime.Contains(keyword),
                    orderBy: k => k.OrderBy(k => k.Ime),
                    includes: new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContactsBySurname)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get all contacts that contain keyword in the tags @api/kontakti/po-tagu/{keyword}
        [HttpGet("po-tagu/{keyword}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetContactsByTag(string keyword)
        {
            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll(
                    expression: k => k.Tagovi.Any(tag => tag.Naziv.Contains(keyword)),
                    orderBy: k => k.OrderBy(k => k.Ime),
                    includes: new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContactsByTag)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get all contacts that are favorited @api/kontakti/samo-favoriti
        [HttpGet("samo-favoriti")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Kontakt>>> GetFavoritedContacts()
        {
            try
            {
                var kontakti = await _unitOfWork.Kontakti.GetAll(
                    expression: k => k.Bookmarkiran,
                    orderBy: k => k.OrderBy(k => k.Ime),
                    includes: new List<string> { "EmailAdrese", "BrojeviTelefona", "Tagovi" });
                var rezultati = _mapper.Map<IList<KontaktDTO>>(kontakti);
                return Ok(rezultati);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetFavoritedContacts)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Get contact by id @api/kontakti/{id}
        [HttpGet("{id:int}", Name = "GetContact")]
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
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetContact)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

        // Create contact @api/kontakti
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateContact([FromBody] KontaktIzradaDTO kontaktDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateContact)}");
                return BadRequest(ModelState);
            }

            try
            {
                var kontakt = _mapper.Map<Kontakt>(kontaktDTO);
                await _unitOfWork.Kontakti.Insert(kontakt);
                await _unitOfWork.Save();
                //return CreatedAtAction("GetContact", kontakt);
                return CreatedAtRoute("GetContact", new { id = kontakt.KontaktID }, kontakt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateContact)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Update contact @api/kontakti/{id}
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] KontaktIzmjenaDTO kontaktDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateContact)}");
                return BadRequest(ModelState);
            }

            try
            {
                var kontakt = await _unitOfWork.Kontakti.Get(k => k.KontaktID == id);
                if (kontakt == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateContact)}");
                    return BadRequest("Submitted data is invalid.");
                }

                _mapper.Map(kontaktDTO, kontakt);
                //_mapper.Map(kontaktDTO.EmailAdrese, kontakt.EmailAdrese);
                //_mapper.Map(kontaktDTO.BrojeviTelefona, kontakt.BrojeviTelefona);
                //_mapper.Map(kontaktDTO.Tagovi, kontakt.Tagovi);
                kontakt.EmailAdrese = _mapper.Map<IList<EmailAdresa>>(kontaktDTO.EmailAdrese);
                kontakt.BrojeviTelefona = _mapper.Map<IList<BrojTelefona>>(kontaktDTO.BrojeviTelefona);
                kontakt.Tagovi = _mapper.Map<IList<Tag>>(kontaktDTO.Tagovi);

                _unitOfWork.Kontakti.Update(kontakt);

                foreach (var email in kontakt.EmailAdrese)
                {
                    if(email.EmailAdresaID != 0)
                    { 
                        _unitOfWork.EmailAdrese.Update(email);
                    }
                }

                foreach (var broj in kontakt.BrojeviTelefona)
                {
                    if (broj.BrojTelefonaID != 0)
                    {
                        _unitOfWork.BrojeviTelefona.Update(broj);
                    }
                }

                foreach (var tag in kontakt.Tagovi)
                {
                    if (tag.TagID != 0)
                    {
                        _unitOfWork.Tagovi.Update(tag);
                    }
                }

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateContact)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        // Delete contact @api/kontakti/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteContact)}");
                return BadRequest();
            }

            try
            {
                var kontakt = await _unitOfWork.Kontakti.Get(k => k.KontaktID == id);
                if (kontakt == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteContact)}");
                    return BadRequest("Submitted data is invalid.");
                }

                await _unitOfWork.Kontakti.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteContact)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
