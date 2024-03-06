namespace AuctionApp.Core.Resources
{
    public sealed record UserInformationResource(
        string username,
        string firstName,
        string lastName,
        DateOnly dateOfBirth,
        byte[] profileImage,
        string phoneNumber,
        string email
    );
}
