# Iot Server
The server for this application uses the ASP.NET Core MVC framework.
It serves two purposes:
1. Receives data from the client through Kafka.
2. Processes data.
3. Stores data into the SQL Server database.
4. Exposes REST API for the front-end to grab the required data

# Components
## API
`/api/latest-data/`

The api to retrieve the latest data from the database.

## Pull data from kafka Service
Periodically pull data from the kafka