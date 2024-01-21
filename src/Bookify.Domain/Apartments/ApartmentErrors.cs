using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Apartments;

public class ApartmentErrors
{
    public static Error NotFound = new(
        "Apartment.NotFound",
        "The apartment with the specified identifier was not found"
    );
}