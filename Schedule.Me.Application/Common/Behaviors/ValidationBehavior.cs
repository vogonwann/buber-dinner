using ErrorOr;
using FluentValidation;
using MediatR;

namespace Schedule.Me.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : 
        IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
            where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid) 
            {
                return await next();
            }

            var errors = validationResult.Errors
                .ConvertAll(ValidationFailure => Error.Validation(
                    ValidationFailure.PropertyName,
                    ValidationFailure.ErrorMessage));
            
            return (dynamic)errors;        
        }
    }
}