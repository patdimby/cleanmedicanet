using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace server.Models;

[Index(nameof(Name), IsUnique = true, Name = "Unique_Name")]
[Table("Titles")]
[JsonSerializable(typeof(Title))]
public class Title
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [Column("Position")]
    [JsonPropertyName("position")]
    public bool Position { get; set; } = false;

    [JsonPropertyName("name")]
    [Required, MaxLength(20, ErrorMessage = "Menu name cannot exceed 20 characters")]
    [DataType(DataType.Text)]
    [Column("Name")]
    public string Name { get; set; } = string.Empty;
}