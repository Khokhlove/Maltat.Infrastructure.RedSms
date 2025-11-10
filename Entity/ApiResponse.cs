using System.Text.Json.Serialization;

namespace Maltat.Infrastructure.RedSms.Entity;

/// <summary>
/// Объект ответа от API RedSMS.
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// Массив элементов ответа с информацией об отправленных сообщениях.
    /// </summary>
    [JsonPropertyName("items")]
    public MessageResponseItem[] Items { get; set; } = [];

    /// <summary>
    /// Массив ошибок, возникших при выполнении запроса.
    /// </summary>
    [JsonPropertyName("errors")]
    public string[] Errors { get; set; } = [];

    /// <summary>
    /// Количество элементов в ответе.
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// Признак успешного выполнения запроса.
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }
}
