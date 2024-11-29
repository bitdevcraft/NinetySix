using NinetySix.Server.Models.Metadata;

namespace NinetySix.Server.Models.Repositories;

public interface IObjectRepository
{
    void AddObject(MetadataObject metadataObject);
    void AddObjectAsync(MetadataObject metadataObject);
    
    void RemoveObject(MetadataObject metadataObject);
    void RemoveObjectAsync(MetadataObject metadataObject);
    
    void ModifyObject(MetadataObject metadataObject);
    void ModifyObjectAsync(MetadataObject metadataObject);
}