using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "[START] Handling request={Request}-Response={Response} - RequestData={RequestData} ",
                typeof(TRequest).Name, typeof(TResponse).Name, request);

            var timer = Stopwatch.StartNew();
            timer.Start();

            var response = await next();
            timer.Stop();

            logger.LogInformation(
                "[END] Finished handling request={Request}-Response={Response} - Duration={Duration}ms",
                typeof(TRequest).Name, typeof(TResponse).Name, response, timer.ElapsedMilliseconds);

            return response;
        }
    }
}
