﻿using System.Net;

namespace FotoVista.Domain.Exceptions;

public class AlreadyExistsExcaption : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;

    public string TitleMessage { get; protected set; } = String.Empty;
}
