using System.ComponentModel.DataAnnotations.Schema;

public class Device
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Uid { get; set; }

    public string Name { get; set; }

    [ForeignKey("DeviceType")]
    public int DeviceTypeId { get; set; }

    public virtual DeviceType DeviceType { get; set; }
}