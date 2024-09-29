using ErrorOr;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Application.ProductMediator.Common;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.ProductAggregate;
using Lubricentro.Domain.ProductAggregate.ValueObjects;
using MediatR;

namespace Lubricentro.Application.ProductMediator.Command.Delete;

internal class DeleteProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, ErrorOr<ProductResult>>
{
    public async Task<ErrorOr<ProductResult>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (productRepository.GetById(ProductId.Create(request.Id)) is not Product product)
        {
            return Errors.Products.NotFound;
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new ProductResult(product);
    }
}
