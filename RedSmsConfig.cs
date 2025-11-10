namespace Maltat.Infrastructure.RedSms;

/// <summary>
/// Настройки для работы с API RedSMS.
/// </summary>
public class RedSmsConfig
{
    /// <summary>
    /// Имя секции конфигурации в appsettings.json.
    /// </summary>
    public const string SectionName = "RedSms";

    /// <summary>
    /// Имя пользователя для аутентификации в API RedSMS.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// API ключ для аутентификации в RedSMS.
    /// </summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>
    /// Имя отправителя, которое будет отображаться в SMS.
    /// </summary>
    public string SenderName { get; set; } = string.Empty;

    /// <summary>
    /// Базовый URL API RedSMS.
    /// </summary>
    public string BaseUrl { get; set; } = "https://cp.redsms.ru";

    /// <summary>
    /// Проверяет корректность настроек.
    /// </summary>
    /// <exception cref="InvalidOperationException">Выбрасывается, если настройки некорректны.</exception>
    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Username))
            throw new InvalidOperationException("RedSms:Username не может быть пустым");

        if (string.IsNullOrWhiteSpace(ApiKey))
            throw new InvalidOperationException("RedSms:ApiKey не может быть пустым");

        if (string.IsNullOrWhiteSpace(SenderName))
            throw new InvalidOperationException("RedSms:SenderName не может быть пустым");
    }
}
