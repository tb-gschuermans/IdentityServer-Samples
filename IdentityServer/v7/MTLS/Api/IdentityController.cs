﻿using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("identity")]
public class IdentityController : ControllerBase
{
    private readonly ILogger<IdentityController> _logger;

    public IdentityController(ILogger<IdentityController> logger)
    {
        _logger = logger;
    }

    // this action simply echoes the claims back to the client
    [HttpGet]
    public ActionResult Get()
    {
        var claims = User.Claims.Select(c => new { c.Type, c.Value });
        _logger.LogInformation("claims: {claims}", claims);

        return new JsonResult(claims);
    }
}