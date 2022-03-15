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

                var query = $"  Select p.Pregunta, p.id from preguntas p where  p.Base='{jbase}' and libro like'{libro}%'";
                var reades = await conn.QueryFirstOrDefaultAsync<Preguntas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades;
            }
        }

        public async Task<List<Respuestas>> GetRespuesta(int id)
        {

            using (var conn = _connection.GetConnection())
            {

                var query = $"Select respuesta, isCorrect from Respuesta where IdPreguntasId = {id}";
                var reades = await conn.QueryAsync<Respuestas>(
                    sql: query,
                    commandType: System.Data.CommandType.Text
                    );


                return reades.ToList();
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



    }


}
