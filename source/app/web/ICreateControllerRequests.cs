﻿using System.Web;

namespace app.web
{
  public interface ICreateControllerRequests
  {
    object create_request_from(HttpContext an_context);
  }
}