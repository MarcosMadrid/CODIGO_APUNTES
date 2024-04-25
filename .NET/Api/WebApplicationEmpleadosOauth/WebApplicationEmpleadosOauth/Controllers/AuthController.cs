﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;
using WebApplicationEmpleadosOauth.Helpers;
using WebApplicationEmpleadosOauth.Models;
using WebApplicationEmpleadosOauth.Repositories;

namespace WebApplicationEmpleadosOauth.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryHospital repositoryHospital;
        private HelperActionServicesOauth helperOauth;

        public AuthController(RepositoryHospital repositoryHospital, HelperActionServicesOauth servicesOauth)
        {
            this.repositoryHospital = repositoryHospital;
            this.helperOauth = servicesOauth;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            Empleado? empleado = await repositoryHospital.LogInEmp(int.Parse(model.Password), model.UserName);
            if (empleado == null)
            {
                return Unauthorized();
            }
            else
            {
                string jsonEmp = JsonConvert.SerializeObject(empleado);
                Claim[] claims = new[]
                {
                    new Claim("UserData", jsonEmp)
                };
                SigningCredentials credentials = new SigningCredentials(this.helperOauth.GetKeyToken(), SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    issuer: helperOauth.Issuer,
                    audience: helperOauth.Audience,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    notBefore: DateTime.UtcNow
                );

                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }
    }
}