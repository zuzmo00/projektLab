
namespace teremKezelo.Entities
{
    /// <summary>
    /// Foglalható erőforrás típusa a specifikáció szerint.
    /// </summary>
    public enum ResourceType
    {
        Room = 1,
        Equipment = 2,
        Other = 3
    }

    /// <summary>
    /// Erőforrás üzleti állapota.
    /// </summary>
    public enum ResourceStatus
    {
        Available = 1,
        Inactive = 2,
        UnderMaintenance = 3
    }

    /// <summary>
    /// Foglalás életciklus státusza.
    /// </summary>
    public enum ReservationStatus
    {
        Pending = 1,
        Approved = 2,
        Active = 3,
        Cancelled = 4,
        Rejected = 5,
        Expired = 6
    }
}