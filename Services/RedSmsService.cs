using Maltat.Hotel.Infrastructure.RedSms;
using Maltat.Infrastructure.RedSms.Entity;
using Maltat.Infrastructure.RedSms.Helpers;
using Maltat.Infrastructure.RedSms.Interfaces;
using Microsoft.Extensions.Options;
using Refit;

namespace Maltat.Infrastructure.RedSms.Services;

/// <summary>
/// Сервис для работы с API RedSMS.
/// </summary>
public class RedSmsService : IRedSmsService
{
    /// <summary>
    /// Настройки для работы с RedSMS API.
    /// </summary>
    private readonly RedSmsConfig _config;

    private readonly IRedSmsApi _api;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="RedSmsService"/>.
    /// </summary>
    /// <param name="config">Настройки RedSMS из конфигурации.</param>
    public RedSmsService(IOptions<RedSmsConfig> config)
    {
        _config = config?.Value ?? throw new ArgumentNullException(nameof(config));
        _config.Validate();

        _api = RestService.For<IRedSmsApi>(_config.BaseUrl);
    }

    /// <summary>
    /// Отправляет SMS-сообщение на указанный номер телефона.
    /// </summary>
    /// <param name="phone">Номер телефона получателя.</param>
    /// <param name="message">Текст сообщения.</param>
    /// <returns>Результат отправки SMS.</returns>
    public async Task<VerificationResponse> SendSmsAsync(string phone, string message)
    {
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Номер телефона не может быть пустым", nameof(phone));

        if (string.IsNullOrWhiteSpace(message))
            throw new ArgumentException("Текст сообщения не может быть пустым", nameof(message));

        try
        {
            var secret = GenerateSecret();
            var request = CreateSmsRequest(phone, message);
            var response = await _api.SendMessage(_config.Username, secret.Timestamp, secret.Hash, request);

            return CreateResponse(response.IsSuccessStatusCode);
        }
        catch (Exception ex)
        {
            return new VerificationResponse
            {
                Success = false,
                Message = $"Ошибка при отправке SMS: {ex.Message}"
            };
        }
    }

    /// <summary>
    /// Генерирует секретный хеш для аутентификации запроса.
    /// </summary>
    /// <returns>Временная метка и хеш для аутентификации.</returns>
    private (string Timestamp, string Hash) GenerateSecret()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
        var secretInput = $"{timestamp}{_config.ApiKey}";
        var hash = CryptoHelper.GetMd5Hash(secretInput)
            ?? throw new InvalidOperationException("Не удалось сгенерировать хеш");

        return (timestamp, hash);
    }

    /// <summary>
    /// Создает запрос на отправку SMS.
    /// </summary>
    /// <param name="phone">Номер телефона получателя.</param>
    /// <param name="message">Текст сообщения.</param>
    /// <returns>Объект запроса для отправки SMS.</returns>
    private SendMessageRequest CreateSmsRequest(string phone, string message)
    {
        return new SendMessageRequest
        {
            Route = "sms",
            From = _config.SenderName,
            To = phone,
            Text = message
        };
    }

    /// <summary>
    /// Создает ответ на основе результата отправки.
    /// </summary>
    /// <param name="isSuccess">Признак успешной отправки.</param>
    /// <returns>Объект ответа с результатом операции.</returns>
    private static VerificationResponse CreateResponse(bool isSuccess)
    {
        return new VerificationResponse
        {
            Success = isSuccess,
            Message = isSuccess ? "SMS успешно отправлено" : "Не удалось отправить SMS"
        };
    }
}
