using Maltat.Infrastructure.RedSms.Entity;

namespace Maltat.Infrastructure.RedSms.Interfaces;

/// <summary>
/// Интерфейс сервиса для отправки SMS через RedSMS API.
/// </summary>
public interface IRedSmsService
{
    /// <summary>
    /// Отправляет SMS-сообщение на указанный номер телефона.
    /// </summary>
    /// <param name="phone">Номер телефона получателя.</param>
    /// <param name="message">Текст сообщения для отправки.</param>
    /// <returns>Результат отправки SMS с информацией об успехе операции.</returns>
    Task<VerificationResponse> SendSmsAsync(string phone, string message);
}
