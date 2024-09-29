using ErrorOr;
using Lubricentro.Application.BranchMediator.Common;
using Lubricentro.Application.Common.Interfaces.Persistence.LubricentroDb;
using Lubricentro.Domain.AddressAggregate;
using Lubricentro.Domain.Common.Errors;
using Lubricentro.Domain.CompanyAggregate.Entities;
using Lubricentro.Domain.CompanyAggregate.ValueObjects;
using Lubricentro.Domain.ProductAggregate;
using MediatR;

namespace Lubricentro.Application.BranchMediator.Commands.Create;

public class CreateBranchCommandHandler(IProductRepository productRepository, ICompanyRepository companyRepository, IBranchRepository branchRepository , IUnitOfWork unitOfWork) : IRequestHandler<CreateBranchCommand, ErrorOr<BranchResult>>
{
    public async Task<ErrorOr<BranchResult>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        //CHECK IF EXISTS
        if(await branchRepository.AlreadyExists(request.PointOfSale))
        {
            return Errors.Branches.DuplicatedPointOfSale;
        }

        //FETCH THE COMPANY
        var company = await companyRepository.GetByIdAsync(CompanyId.Create(request.CompanyId));

        //CHECK IF FOUND
        if(company is null)
        {
            return Errors.Companies.NotFound;
        }

        //CREATE NEW BRANCH
        Address address = Address.Create(request.Country, request.State, request.City, request.Street, request.PostalCode);
        Stock stock = Stock.Create();

        foreach (Product product in await productRepository.GetAllAsync())
        {
            stock.AddItem(StockItem.Create(product, StockItemLocation.Create("0", "0", "0")));
        }

        Branch newBranch = Branch.Create(request.Name, request.PointOfSale, address, stock);

        company.AddBranch(newBranch);

        companyRepository.Update(company);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new BranchResult(newBranch.Id.Value.ToString(),
                                newBranch.Name,
                                newBranch.PointOfSale,
                                newBranch.Address.Country,
                                newBranch.Address.State,
                                newBranch.Address.City,
                                newBranch.Address.Street,
                                newBranch.Address.PostalCode);
    }
}
