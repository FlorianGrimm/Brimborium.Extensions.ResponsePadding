using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;

namespace Brimborium.Extensions.ResponsePadding;

/// <summary>
/// Enable HTTP response compression.
/// </summary>
public class ResponsePaddingMiddleware {
    private readonly RequestDelegate _next;

    /// <summary>
    /// ResponsePaddingMiddleware.
    /// </summary>
    /// <param name="next">The delegate representing the remaining middleware in the request pipeline.</param>
    public ResponsePaddingMiddleware(RequestDelegate next) {
        ArgumentNullException.ThrowIfNull(next);

        _next = next;
    }

    /// <summary>
    /// Invoke the middleware.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/>.</param>
    /// <returns>A task that represents the execution of this middleware.</returns>
    public Task Invoke(HttpContext context) {
        return _next(context);
    }
}
