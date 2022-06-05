# Task_Tracker
Скачаь обрраз MSSQL сервера
docker pull mcr.microsoft.com/mssql/server

Запустить контейнер с параметрами - поменять пароль с учетом требований сервера - не меньше 8 символов
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourpassword" -p 1433:1433 -d mcr.microsoft.com/mssql/server

Поменять пароль в appsettings.json
Прогнать миграции
Запустить приложение в вижуал студии
