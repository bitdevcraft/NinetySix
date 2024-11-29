using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Models.Repositories;

public interface IObjectFieldRepository
{
    void AddObjectField(MetadataObjectField objectField);
    void AddObjectFieldAsync(MetadataObjectField objectField);
    
    void ModifyObjectField(MetadataObjectField objectField);
    void ModifyObjectFieldAsync(MetadataObjectField objectField);
    
    void DeleteObjectField(MetadataObjectField objectField);
    void DeleteObjectFieldAsync(MetadataObjectField objectField);
}