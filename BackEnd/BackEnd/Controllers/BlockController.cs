﻿using BackEnd.Services;
using BackEnd.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {

        public MemPoolService _memPollService;
        public BlockService _BlockService;
        public ConfigurationService  _configurationService;
        public BlockChain nodo;
        public BlockController(BlockService blockService, MemPoolService memPollService,
            ConfigurationService configurationService)
        {
            _BlockService = blockService;
            _memPollService = memPollService;
            _configurationService = configurationService;
            //_memPollService =  _BlockService.Mempoll(_memPollService);

        }
        // GET api/<BlockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    /*  [HttpGet]
      public ActionResult<int> Getd()
      {
          return Ok(_BlockService.getLastBlock());
      }*/

      [HttpGet]
      public ActionResult Minar()
      {
          
            


            int numberOfFilesPerBlock =int.Parse((_configurationService.numeroBloque("bloque")[0].CantidadBloques));

            

            int sizeMempool = _memPollService.getSizeMempool();

            int sizeBlock =0;

            int idBlock = 0;

           // return Ok(_BlockService.getLastBlock()[0]);

             string previousHash = "0000000000000000000000000000000000000000000000000000000000000000";

            if (sizeMempool < numberOfFilesPerBlock)
            {
                return Ok("0");
            }
            else
            {
                nodo = new BlockChain();

                while (sizeMempool >= numberOfFilesPerBlock)
                {
                   
                    List<MemPool> listMepool = _memPollService.mineList(numberOfFilesPerBlock);

                    sizeBlock = _BlockService.getSizeBlocks();
                   
                    if (sizeBlock > 0)
                    {
                        idBlock = (_BlockService.getLastBlock()[0].IdBlock);
                        previousHash = (_BlockService.getLastBlock()[0].Hash);
                      
                        System.Diagnostics.Debug.WriteLine(idBlock);
                        System.Diagnostics.Debug.WriteLine(previousHash);

                    }
                    listMepool.ForEach((file) => {
                        nodo.NewTransaccion(file.Base64,file.TypeOfFile,file.Name);
                    });
                    nodo.NewBlokc(previousHash, idBlock);
                   
                    Block block = nodo.Blocks[0];
                    

                    _BlockService.CreateBlock(block);
            
                    deleteMultiple(listMepool);

                    sizeMempool = _memPollService.getSizeMempool();
                   
                }

            }
            return Ok("1"); ;
        }

        public void deleteMultiple(List<MemPool> listMepool) {
            listMepool.ForEach((file) => {
                _memPollService.Delete(file.Id);
            });
        }

        /* [HttpGet]
           public ActionResult<List<Block>> Get()
           {
               return Ok(_BlockService.getAllBlock());
           }*/

        /*  [HttpGet]
          public ActionResult<List<MemPool>> Get()
          {
              return Ok(_memPollService.AllConfiguration());
          }*/


        // POST api/<BlockController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BlockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BlockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}