using System.ComponentModel.DataAnnotations.Schema;

public class DeviceType {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
}