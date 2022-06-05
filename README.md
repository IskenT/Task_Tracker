# Task_Tracker
The project uses MSSQL(DBMS) and the MSSQL container in Docker.

To launch the application you need to do the following:
Download the MSSQL server image => docker pull mcr.microsoft.com/mssql/server
Run the container with parameters - change the password taking into account the server requirements - at least 8 characters => docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourpassword" -p 1433:1433 -d mcr.microsoft.com/mssql/server
After starting the database server, go to the database server and create the database with the name "TaskTrackerDB".
Change password in appsettings.json file.
On PM console on Visual Studio create migration (add-migration 'migration name') and update the database (update-database).
Run the application in Visual Studio.
