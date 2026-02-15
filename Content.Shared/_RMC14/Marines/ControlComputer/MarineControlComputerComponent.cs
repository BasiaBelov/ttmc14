using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Shared._RMC14.Marines.ControlComputer;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState, AutoGenerateComponentPause]
[Access(typeof(SharedMarineControlComputerSystem))]
public sealed partial class MarineControlComputerComponent : Component
{
    [DataField, AutoNetworkedField]
    public bool Evacuating;

    [DataField, AutoNetworkedField]
    public bool CanEvacuate;

    [DataField, AutoNetworkedField]
    public SoundSpecifier? EvacuationCancelledSound = new SoundPathSpecifier("/Audio/_MC/Announcements/Ares/evacuate_cancelled.ogg", AudioParams.Default.WithVolume(-5));

    [DataField, AutoNetworkedField]
    public TimeSpan ToggleCooldown = TimeSpan.FromSeconds(5);

    [DataField, AutoNetworkedField]
    public TimeSpan LastToggle;

    [DataField, AutoNetworkedField]
    public Dictionary<string, GibbedMarineInfo> GibbedMarines = new();

    [DataField(customTypeSerializer: typeof(TimeOffsetSerializer)), AutoNetworkedField, AutoPausedField]
    public TimeSpan? LastShipAnnouncement;

    [DataField, AutoNetworkedField]
    public TimeSpan ShipAnnouncementCooldown = TimeSpan.FromSeconds(30);
}

[Serializable, NetSerializable]
public sealed class GibbedMarineInfo
{
    public string Name = string.Empty;
    public string? LastPlayerId;
}
