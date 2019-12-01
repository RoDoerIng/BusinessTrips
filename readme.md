# BusinessTrips

A project to enable users to track business trips.

## What's next

- [ ] Add all required fields to new trip page at `/trips/create`
- [ ] Replace `Edit`, `Details`, `Remove` links on persons and trips index page with meaningful icons
- [ ] List all trips on home page
- [ ] Add more descriptive headers to all pages

## Prerequisites

- docker installed

## How to run

### Standalone Docker SQL Server

`docker run -e "ACCEPT_EULA=y" -e "MSSQL_SA_PASSWORD=P@ssw0rd" -p 1433:1433 --name sql1 -d microsoft/mssql-server-linux:2017-latest`

### SQL Server and web APP with docker compose

- `docker-compose up`

## How to connect

### To running SQL server

- Connection String: `Server=127.0.0.1,1433;Database=master;User Id=sa;Password=P@ssw0rd`

### To running container

- `docker exec -it [CONTAINER-ID] bash`
