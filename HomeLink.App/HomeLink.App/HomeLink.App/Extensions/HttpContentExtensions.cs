using System.Net.Http;

namespace HomeLink.App.Extensions {
    internal static class HttpContentExtensions {
        internal static string GetFileName(this HttpContent httpContent) => 
            httpContent
                ?.Headers
                ?.ContentDisposition
                ?.FileName
                ?.Replace("\"", string.Empty) ?? string.Empty;
    }
}