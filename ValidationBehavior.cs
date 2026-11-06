using System;
using MediatR;

namespace BuildingBlocks.Behaviors
{

    internal class ValidationBehavior<TRequest,TResponse>
        (IEnumerable<IValidator<TRequest>> validators)
        :IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TRequest>
    {
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = new ValidationBehaviorValidator<TRequest>();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }
            return next();
        }
    }
}