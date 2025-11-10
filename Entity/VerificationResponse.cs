namespace Maltat.Infrastructure.RedSms.Entity;

/// <summary>
/// Ответ на запрос верификации SMS-кода.
/// </summary>
public class VerificationResponse
{
    /// <summary>
    /// Признак успешной верификации.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Сообщение с результатом верификации или описанием ошибки.
    /// </summary>
    public string? Message { get; set; }
}
