using System.Collections.ObjectModel;
using MongoDB.Driver;
using NinetySix.Server.Models.Enums;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Persistence.Seed.StandardObjects;

public class AccountObject : IStandardObject
{
    
    public static MetadataObject CreateStandardObject()
    {

        var metadataObject = new MetadataObject(true)
        {
            Name = "Account",
            ApiName = "Account",
            PluralName = "Accounts",
            Description = "Standard Object",
            Fields = [
                new MetadataObjectField(true)
                {
                    Name = "Id",
                    ApiName = "Id",
                    Type = FieldDataType.Text,
                    Description = "Id",
                },
                new MetadataObjectField(true)
                {
                    Name = "Name",
                    ApiName = "Name",
                    Type = FieldDataType.Text,
                    Description = "Name of the account",
                    IsRequired = true,
                },
                new MetadataObjectField(true)
                {
                    Name = "CreatedAt",
                    ApiName = "CreatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Created Date of the account",
                },
                new MetadataObjectField(true)
                {
                    Name = "UpdatedAt",
                    ApiName = "UpdatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Last Modified Date of the account",
                },
                new MetadataObjectField(true)
                {
                    Name = "Phone",
                    ApiName = "Phone",
                    Type = FieldDataType.Text,
                    Description = "Phone Number of the account",
                },
                new MetadataObjectField(true)
                {
                    Name = "Mobile",
                    ApiName = "Mobile",
                    Type = FieldDataType.Text,
                    Description = "Mobile Phone Number of the account",
                },
                new MetadataObjectField(true)
                {
                    Name = "Email",
                    ApiName = "Email",
                    Type = FieldDataType.Text,
                    Description = "Email of the account",
                },
            ]
        };
        
        return metadataObject;
    }
}