using System.Collections.ObjectModel;
using MongoDB.Driver;
using NinetySix.Server.Models.Enums;
using NinetySix.Server.Models.Interfaces;
using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Persistence.Seed.StandardObjects;

public class LeadObject : IStandardObject
{
    public static MetadataObject CreateStandardObject()
    {

        var metadataObject = new MetadataObject(true)
        {
            Name = "Lead",
            ApiName = "Lead",
            PluralName = "Leads",
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
                    Description = "Name of the lead",
                    IsRequired = true,
                },
                new MetadataObjectField(true)
                {
                    Name = "First Name",
                    ApiName = "FirstName",
                    Type = FieldDataType.Text,
                    Description = "FirstName of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "Middle Name",
                    ApiName = "MiddleName",
                    Type = FieldDataType.Text,
                    Description = "Middle Name of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "Last Name",
                    ApiName = "LastName",
                    Type = FieldDataType.Text,
                    Description = "Last Name of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "CreatedAt",
                    ApiName = "CreatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Created Date of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "UpdatedAt",
                    ApiName = "UpdatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Last Modified Date of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "Phone",
                    ApiName = "Phone",
                    Type = FieldDataType.Text,
                    Description = "Phone Number of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "Mobile",
                    ApiName = "Mobile",
                    Type = FieldDataType.Text,
                    Description = "Mobile Phone Number of the lead",
                },
                new MetadataObjectField(true)
                {
                    Name = "Email",
                    ApiName = "Email",
                    Type = FieldDataType.Text,
                    Description = "Email of the lead",
                },
            ]
        };
        
        return metadataObject;
    }
}