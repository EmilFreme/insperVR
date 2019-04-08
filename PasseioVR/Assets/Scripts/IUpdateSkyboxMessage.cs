using UnityEngine.EventSystems;

public interface IUpdateSkyboxMessage : IEventSystemHandler
{
    void SkyboxUpdated();
}
