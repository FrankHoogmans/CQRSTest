using System.ComponentModel.DataAnnotations.Schema;

public class DeviceType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }

    public string SecureContent { get; set; }

    public Configuration TechnicalConfiguration { get; set; }

    public Configuration FunctionalConfiguration { get; set; }
}

public enum Configuration
{
    NotSupported = 0,
    Optional = 1,
    Required = 2
}