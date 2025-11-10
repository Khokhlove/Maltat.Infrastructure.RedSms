# Maltat.Hotel.Infrastructure.RedSms

Библиотека для работы с API RedSMS для отправки SMS-сообщений в .NET приложениях.

## Описание

Maltat.Hotel.Infrastructure.RedSms - это NuGet пакет, предоставляющий простой и удобный интерфейс для интеграции с API RedSMS. Библиотека поддерживает стандартные паттерны .NET, включая Dependency Injection и Options Pattern.

## Возможности

- ✅ Отправка SMS-сообщений через RedSMS API
- ✅ Поддержка Dependency Injection
- ✅ Конфигурация через appsettings.json или программно
- ✅ Типизированный HttpClient для оптимального управления соединениями
- ✅ Полная XML-документация
- ✅ Поддержка .NET 8.0

## Установка

## Через NuGet Package Manager

dotnet add package Maltat.Hotel.Infrastructure.RedSms

## Через NuGet Package Manager

Install-Package Maltat.Hotel.Infrastructure.RedSms

## Быстрый старт

1. Добавьте настройки в appsettings.json
{
  "RedSms": {
    "Username": "your_username",
    "ApiKey": "your_api_key",
    "SenderName": "YourSender",
    "BaseUrl": "https://cp.redsms.ru"
  }
}
2. Зарегистрируйте сервис в Program.cs
3. Используйте сервис через Dependency Injection