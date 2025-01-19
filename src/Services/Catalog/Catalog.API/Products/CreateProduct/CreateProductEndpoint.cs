namespace Catalog.API.Products.CreateProduct;

// Dto - indeholder data til at create et product (request object)
public record CreateProductRequest(
    string Name,
    List<string> Category,
    string Description,
    decimal Price
    );

// Dto - bruges til at returnere id når product er oprettet (response object)
public record CreateProductResponse(Guid Id);

// Handler - håndterer request og returnerer response
public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // Map request til command
                var command = request.Adapt<CreateProductCommand>();

                // Send command til MediatR
                var result = await sender.Send(command);

                // Map result til response der modtages
                var response = result.Adapt<CreateProductResponse>();

                // Returner response
                return Results.Created($"/products/{response.Id}", response);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create product");
    }


}