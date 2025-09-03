# Formal RPG

An RPG system with Blazor and .NET. \
Why? The challenge of doing something outside the box.

## Instructions

### Prerequisits

- [Docker](https://www.docker.com/products/docker-desktop/)
- [Visual Studio](https://visualstudio.microsoft.com/downloads/) (recommended)
- [DBeaver](https://dbeaver.io/download/) (recommended)

### Run docker database

- Compose the docker container

```cmd
docker compose -f docker-compose-db.yml up
```

### Install EF

- Necessary for data migration

```cmd
dotnet tool install --global dotnet-ef
```

### Add Ef Migration

- Move down into project solution

```cmd
cd ProjectManagementApp
```

- Add a migration to the project

```cmd
dotnet ef migrations add <migration name>
```

- Update the database (ensure the docker container is running)

```cmd
dotnet ef database update
```

### SQL Scripts

- Copy sql scripts from the local `/scripts` directory into the docker container. (Be sure to use the proper `file_name` for each `sql` file.)

```cmd
docker cp ./scripts/file_name.sql rpgdatabase:/docker-entrypoint-initdb.d/file_name.sql
```

- To run said scripts, use the `exec` command.

```cmd
docker exec -u postgres rpgdatabase psql postgres postgres -f /docker-entrypoint-initdb.d/file_name.sql
```

(See [reference](https://stackoverflow.com/questions/34688465/how-do-i-run-a-sql-file-of-inserts-through-docker-run) for more details).
