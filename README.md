


# Redis for .NET Developers

## Introduction

Welcome! This is the course repository for the Redis for .NET Developers.

To take this course you'll need the following.

1. The [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).
2. Clone this git repository from GitHub.
3. Get a [Redis Stack](https://redis.io/docs/stack/) instance running locally in docker.


## Clone the Course Git Repository

```
git clone https://github.com/nobleprog-inkaso-redis
```

## Redis Setup

This course uses the Redis Stack Docker container. You can download and start it with the course Docker Compose as follows:

```bash
docker-compose up -d
```

You can check the status of the container with the following command:

```bash
docker ps
```

You should see an output that looks something like the following:

```
CONTAINER ID   IMAGE                      COMMAND            CREATED         STATUS        PORTS                   
                         NAMES
13eb07093f67   redis/redis-stack:latest   "/entrypoint.sh"   10 seconds ago   Up 1 second   0.0.0.0:6379->6379/tcp, 0.0.0.0:8001->8001/tcp   redis-dotnet
```

Leave this container running for now. When you want to stop it, use this command:

```bash
docker-compose down
```

## Connect to Redis

### Option 1: Use the redis-cli
```bash
docker exec -it redis-dotnet redis-cli
```

You can check the status of connection with the following command:

```bash
PING
```

Leave this server:
```bash
EXIT
```


### Option 2: Use the Web Interface

Open browser at `http://localhost:8001/`



## Redis Cluster Setup

- Create Redis Cluster:
```bash
docker-compose -f docker-compose-redis-cluster.yml up -d
```

- Connect to master

```bash
docker exec -it redis_1 redis-cli --cluster
```
note: remember about -c parameter!

- When you want to remove cluster, use this command:

```bash
docker-compose -f docker-compose-redis-cluster.yml down
```
