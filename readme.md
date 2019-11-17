# BusinessTrips

A project to enable users to track business trips.

## Prerequisites

- docker installed 

## How to run

- run a SQL Server instance with docker by executing: 

```docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=P@ssw0rd' -p 1433:1433 --name sql1 -d microsoft/mssql-server-linux:2017-latest```

