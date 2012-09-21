﻿using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }
    }

    public class expressions
    {
      public static ExpressionBuilder<T> targeting<T>()
      {
        return new ExpressionBuilder<T>();
      }

      public class ExpressionBuilder<T>
      {
        public ConstructorInfo ctor_pointed_at_by(Expression<Func<T>> ctor)
        {
          return ctor.Body.downcast_to<NewExpression>().Constructor;
        }
      }
    }
  }
}