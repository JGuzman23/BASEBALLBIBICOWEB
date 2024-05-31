using BASEBALLBIBICOWEB.Core.Contract;
using BASEBALLBIBICOWEB.Data;
using BASEBALLBIBICOWEB.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BASEBALLBIBICOWEB.Core.Repository
{
    public class JuegoRepository : IJuegoRepository
    {

        private readonly IConnection _connection;
        readonly IConfiguration _configuration;

        public JuegoRepository(IConnection connection, IConfiguration configuration)
        {
            _connection=connection;
            _configuration=configuration;
        }

        public async Task<Preguntas> GetPreguntas(string jbase,string level, string libro)
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"  Select p.Pregunta, p.id from preguntas p where  p.Base='{jbase}' and p.Vista= 0 ORDER BY NEWID()";
                var reades = await conn.QueryFirstOrDefaultAsync<Preguntas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades;
            }
        }

        public async Task<List<Respuestas>> GetRespuestas(int id)
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"Select respuesta, isCorrect from Respuesta where IdPreguntasId = {id} ORDER BY NEWID()";
                var reades = await conn.QueryAsync<Respuestas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades.ToList();
            }
        }
        public async Task<Respuestas> GetRespuestaCorrecta(int id)
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"select Respuesta from Respuesta where IsCorrect=1 and IdPreguntasId= {id}";
                var reades = await conn.QueryFirstOrDefaultAsync<Respuestas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades;
            }
        }
        public async Task<Respuestas> MarcarPregunta(int id)
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"  UPDATE Preguntas SET Vista = 1 where Id={id}";
                var reades = await conn.QuerySingleAsync(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades;
            }
        }

        public async Task<List<Preguntas>> GetLibros()
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"Select libro from Preguntas";
                var reades = await conn.QueryAsync<Preguntas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades.ToList();
            }
        }

        public async Task<Respuestas> ReiniciarJuego()
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"UPDATE Preguntas SET Vista = 0";
                var reades = await conn.QuerySingleAsync(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );

                return reades;
            }
        }

    }
    

    
}
