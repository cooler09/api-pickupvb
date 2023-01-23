# Create migration scripts
dotnet ef migrations add Init --project api-pickupvb.data/api-pickupvb.data.csproj --startup-project api-pickupvb/api-pickupvb.csproj

# Updates
dotnet ef database update --project api-pickupvb.data/api-pickupvb.data.csproj --startup-project api-pickupvb/api-pickupvb.csproj