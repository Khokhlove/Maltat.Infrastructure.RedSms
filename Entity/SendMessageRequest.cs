using System.Text.Json.Serialization;

namespace Maltat.Infrastructure.RedSms.Entity;

/// <summary>
/// Объект запроса на отправку сообщения.
/// </summary>
public class SendMessageRequest
{
    /// <summary>
    /// Маршрут отправки.
    /// </summary>
    [JsonPropertyName("route")]
    public string Route { get; set; } = string.Empty;

    /// <summary>
    /// От
    /// </summary>
    [JsonPropertyName("from")]
    public string From { get; set; } = string.Empty;

    /// <summary>
    /// Кому
    /// </summary>
    [JsonPropertyName("to")]
    public string To { get; set; } = string.Empty;

    /// <summary>
    /// Текст сообщения.
    /// </summary>
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
}
