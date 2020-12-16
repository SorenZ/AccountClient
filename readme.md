Positive points:
- Good commit timeline
- Persisted to continue to finish the task


Negative points:
- Missing tests and TDD approach (for example mocking webhook to test observable design)
- User experience flow to authorize Xero was not clear
	A) having a link that user click to redirect to authorize http://localhost:5000/xero
- Missing readme on how to run/start project , many exceptions occured durring start-up
- Hard coded Xero client Secret in code
	injected IOptions<XeroConfiguration> XeroConfig; but never used.
- Ignored most Rider warnings
- Not followed naming conventions
- SMEE.io not used



### Exception 1:
```
Now listening on: http://127.0.0.1:27995
Application started. Press Ctrl+C to shut down.
fail: Microsoft.AspNetCore.Server.Kestrel[13]
      Connection id "0HM2IAAK6K9TC", Request id "0HM2IAAK6K9TC:00000001": An unhandled exception was thrown by the application.
System.ArgumentException: Offset and length were out of bounds for the array or count is greater than the number of elements from index to the end of the source collection.
   at System.Buffer.BlockCopy(Array src, Int32 srcOffset, Array dst, Int32 dstOffset, Int32 count)
   at System.IO.MemoryStream.Write(Byte[] buffer, Int32 offset, Int32 count)
   at System.IO.StreamWriter.Flush(Boolean flushStream, Boolean flushEncoder)
   at System.IO.StreamWriter.Write(String value)
   at Microsoft.AspNetCore.Hosting.Views.ErrorPage.ExecuteAsync()
   at Microsoft.Extensions.RazorViews.BaseView.ExecuteAsync(HttpContext context)
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
```
   
   
### Exception 2:
```
System.Threading.Tasks.TaskCanceledException: The operation was canceled.
 ---> System.IO.IOException: Unable to read data from the transport connection: The I/O operation has been aborted because of either a thread exit or an application request..
 ---> System.Net.Sockets.SocketException (995): The I/O operation has been aborted because of either a thread exit or an application request.
   --- End of inner exception stack trace ---
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.GetResult(Int16 token)
   at System.Net.Http.HttpConnection.FillAsync()
   at System.Net.Http.HttpConnection.ReadNextResponseHeaderLineAsync(Boolean foldedHeadersAllowed)
   at System.Net.Http.HttpConnection.SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at System.Net.Http.HttpConnection.SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithNtConnectionAuthAsync(HttpConnection connection, HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.DiagnosticsHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.FinishSendAsyncUnbuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.PerformProxyRequest(HttpContext context)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
fail: Microsoft.AspNetCore.Server.Kestrel[13]
      Connection id "0HM2IAS96S163", Request id "0HM2IAS96S163:00000003": An unhandled exception was thrown by the application.
System.Threading.Tasks.TaskCanceledException: The operation was canceled.
 ---> System.IO.IOException: Unable to read data from the transport connection: The I/O operation has been aborted because of either a thread exit or an application request..
 ---> System.Net.Sockets.SocketException (995): The I/O operation has been aborted because of either a thread exit or an application request.
   --- End of inner exception stack trace ---
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.ThrowException(SocketError error, CancellationToken cancellationToken)
   at System.Net.Sockets.Socket.AwaitableSocketAsyncEventArgs.GetResult(Int16 token)
   at System.Net.Http.HttpConnection.FillAsync()
   at System.Net.Http.HttpConnection.ReadNextResponseHeaderLineAsync(Boolean foldedHeadersAllowed)
   at System.Net.Http.HttpConnection.SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
   --- End of inner exception stack trace ---
   at System.Net.Http.HttpConnection.SendAsyncCore(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithNtConnectionAuthAsync(HttpConnection connection, HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
   at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.DiagnosticsHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
   at System.Net.Http.HttpClient.FinishSendAsyncUnbuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.PerformProxyRequest(HttpContext context)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.SpaServices.Webpack.ConditionalProxyMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Authentication.AuthenticationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http.HttpProtocol.ProcessRequests[TContext](IHttpApplication`1 application)
fail: Microsoft.AspNetCore.Server.Kestrel[13]
      Connection id "0HM2IAS96S16A", Request id "0HM2IAS96S16A:00000009": An unhandled exception was thrown by the application.
System.Exception: invalid_grant
   at Xero.NetStandard.OAuth2.Client.XeroClient.RequestAccessTokenAsync(String code)
   at MyTemplate.Controllers.XeroController.CallBack(String code, String session_state) in D:\Works-HR\Hamed Zohrehvand\AccountClient\MyTemplate\Controllers\XeroController.cs:line 59
```