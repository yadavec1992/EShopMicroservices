namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);
    public record DeleteProductResponse(bool IsDeleted);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(id));
                return Results.Ok(new DeleteProductResponse(result.IsDeleted));
            }).WithDescription("Deletes an existing product.")
            .WithName("DeleteProduct")
            .WithSummary("Deletes an existing product.")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
