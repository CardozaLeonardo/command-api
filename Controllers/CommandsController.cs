using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Commander.Controllers
{
    [ApiController]
    [Route("api/commands")]
    public class CommandsController: ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;


        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAppCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetCommand")]
        public ActionResult<CommandReadDto> GetCommand(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommand), new {Id = commandReadDto.Id}, commandReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdate)
        {
            var commandModel = _repository.GetCommandById(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdate, commandModel);
            
            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDocument)
        {
            var commandModel = _repository.GetCommandById(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModel);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModel);
            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            if (commandItem == null)
            {
                return NotFound();
            }
            
            _repository.DeleteCommand(commandItem);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}