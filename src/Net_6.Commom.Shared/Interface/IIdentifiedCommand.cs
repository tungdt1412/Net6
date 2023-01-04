namespace Net_6.Common.Shared.Interface
{
    public interface IIdentifiedCommand
    {
        string? RequestId { get; set; }
        string? IpAddress { get; set; }
        string? UserName { get; set; }

    }
}
