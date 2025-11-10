using System.Text.Json.Serialization;

namespace Maltat.Infrastructure.RedSms.Entity;

public class MessageResponseItem
{
    /// <summary>
    /// Универсальный идентификатор.
    /// </summary>
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; } = string.Empty;

    /// <summary>
    /// Статус сообщения.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Временной интервал статуса.
    /// </summary>
    [JsonPropertyName("status_time")]
    public long Status_time { get; set; }

    /// <summary>
    /// Адресат.
    /// </summary>
    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;
}
