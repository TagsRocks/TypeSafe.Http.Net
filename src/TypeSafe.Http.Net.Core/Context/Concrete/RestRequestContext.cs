﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TypeSafe.Http.Net
{
	public class RestRequestContext : IRestClientRequestContext
	{
		/// <inheritdoc />
		public string ActionPath { get; }

		/// <inheritdoc />
		public HttpMethod RequestMethod { get; }

		/// <inheritdoc />
		public IEnumerable<IRequestHeader> RequestHeaders { get; }

		/// <inheritdoc />
		public IRequestBodyContext BodyContext { get; }

		public RestRequestContext(HttpMethod requestMethod, string builtActionPath, IEnumerable<IRequestHeader> headers, IRequestBodyContext bodyContext)
		{
			if (requestMethod == null) throw new ArgumentNullException(nameof(requestMethod));
			if (headers == null) throw new ArgumentNullException(nameof(headers));
			if (bodyContext == null) throw new ArgumentNullException(nameof(bodyContext));
			if (string.IsNullOrWhiteSpace(builtActionPath)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(builtActionPath));

			ActionPath = builtActionPath;
			RequestHeaders = headers;
			BodyContext = bodyContext;
			RequestMethod = requestMethod;
		}
	}
}
