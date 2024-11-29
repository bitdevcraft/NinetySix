using NinetySix.Server.Models.Enums;
using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Persistence.Seed.CustomObjects;

public class CustomObject 
{
    
    public static MetadataObject CreateStandardObject(MetadataObject newObject)
    {

        var metadataObject = new MetadataObject
        {
            Name = newObject.Name,
            ApiName = newObject.ApiName,
            PluralName = newObject.PluralName,
            Description = newObject.Description,
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
                    Description = "Name",
                    IsRequired = true,
                },
                new MetadataObjectField(true)
                {
                    Name = "CreatedAt",
                    ApiName = "CreatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Created Date",
                },
                new MetadataObjectField(true)
                {
                    Name = "UpdatedAt",
                    ApiName = "UpdatedAt",
                    Type = FieldDataType.DateTime,
                    Description = "Last Modified Date",
                }
            ]
        };
        
        return metadataObject;
    }
}