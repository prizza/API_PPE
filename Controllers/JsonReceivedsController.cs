using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_PPE.Models;
using API_PPE.Dto;
using Microsoft.Data.SqlClient;
using System.Data;

namespace API_PPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonReceivedsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<JsonReceivedsController> _logger;

        public JsonReceivedsController(AppDbContext context, IConfiguration configuration, ILogger<JsonReceivedsController> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> PostJsonReceived([FromBody] JsonReceivedDto dto)
        {
            var header = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrWhiteSpace(header) || !header.StartsWith("Bearer "))
                return Unauthorized("Authorization header missing.");

            var token = header["Bearer ".Length..].Trim();

            var client = await _context.Apiclients
                .FirstOrDefaultAsync(c => c.Apitoken == token && c.Isactive);

            if (client == null)
                return Unauthorized(new
                {
                    StatusCode = 401,
                    Message = "Invalid token."
                });

            if (string.IsNullOrWhiteSpace(dto.JsonName) || string.IsNullOrWhiteSpace(dto.JsonValue))
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "JsonName and JsonValue are required."
                });

            try
            {
                using SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                using SqlCommand cmd = new SqlCommand("SP_INSERT_JSON_RECEIVED", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@JsonName", dto.JsonName);
                cmd.Parameters.AddWithValue("@JsonValue", dto.JsonValue);
                cmd.Parameters.AddWithValue("@IsProcessed", 0);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                return StatusCode(200, new
                {
                    StatusCode = 200,
                    Message = "Data inserted successfully."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inserting JsonReceived.");
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = "Internal server error."
                });
            }
        }


    }
}
