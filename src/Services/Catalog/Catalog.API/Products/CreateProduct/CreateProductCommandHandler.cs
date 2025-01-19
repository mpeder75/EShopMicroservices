using Catalog.API.Models;
using SharedKernel.CQRS;

namespace Catalog.API.Products.CreateProduct;

// Dto - indeholder data til at oprette et product (request object)
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : ICommand<CreateProductResult>;

// Dto - bruges til at returnere id når product er oprettet (response object)
public record CreateProductResult(Guid Id);

// Command handler der håndtere CreateProductCommand
internal class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        // 1. Create Product entity from command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // 2. Save Product entity to database

        // 3. Return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}