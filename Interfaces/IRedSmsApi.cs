using Maltat.Infrastructure.RedSms.Entity;
using Refit;

namespace Maltat.Infrastructure.RedSms.Interfaces;

/// <summary>
/// Интерфейс для работы с API RedSMS через Refit.
/// </summary>
public interface IRedSmsApi
{
    /// <summary>
    /// Отправляет SMS-сообщение через API RedSMS.
    /// </summary>
    /// <param name="login">Логин пользователя для аутентификации.</param>
    /// <param name="timestamp">Временная метка Unix для генерации подписи запроса.</param>
    /// <param name="secret">Секретный хеш для аутентификации (MD5 от timestamp + apiKey).</param>
    /// <param name="body">Тело запроса с параметрами отправки сообщения.</param>
    /// <returns>Ответ от API с результатом отправки сообщения.</returns>
    [Post("/api/message")]
    Task<ApiResponse<ApiResponse>> SendMessage(
        [Header("login")] string login,
        [Header("ts")] string timestamp,
        [Header("secret")] string secret,
        [Body] SendMessageRequest body);
}
