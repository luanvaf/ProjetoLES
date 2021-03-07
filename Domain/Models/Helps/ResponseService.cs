﻿using System.Net;

namespace Domain.Models.Helps
{
    public class ResponseService
    {
        public HttpStatusCode Status { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ResponseService<T> : ResponseService
    {
        public T Value { get; set; }
    }
}
