# Installation Guide
> Docker Engine is available on a variety of Linux platforms, Mac and Windows through Docker Desktop, Windows Server, and as a static binary installation. Please visit 
[Docker Installation](https://docs.docker.com/install/) for more information.

# Basic commands
For more information about Docker commands, please visit [Docker Documentation](https://docs.docker.com/engine/reference/commandline/docker/).

For more information about list of available Docker Base Images, please visit [Docker Hub](https://hub.docker.com/).

## Running Docker Containers

> Run a command in a new container:

```
docker run [options] [image:tag] [command]
```

- `docker run --rm [image]` - removes a container after it exits
- `docker run -d [image]` - starts a container and keeps it running in background
- `docker run -it [image]` - starts a container and running in an interactive bash shell for this container
- `docker run -v ~/Desktop:/src [image]` - start a container and mount your current folder on the host machine to `src` folder in the container.
- `docker run -p 80:8080 [image]` - start a container and port mapping from port `80` on host machine to port `8080` in the container.
- `docker run --name my_image_name [image]` - start a container and make the container name as `my_image_name`.

For examples:
> starts a container with python version 3.0 image and running in an interactive bash shell for this container, will remove this container after it exits
```
docker run -it --rm --name my_ubuntu ubuntu:latest
```

## Execute command to a running Docker Containers
```
docker exec [options] [container] [command]
```
- `docker exec -it [container] /bin/bash` - execute and running in an interactive base shell for this container.

## Docker Commands for Container and Image Information
> List running containers:
```
docker ps
```

> List all images that are locally stored with the docker engine
```
docker image ls
```

> List the logs from a running container:
```
docker logs [container]
```

## Manage Containers
> Start a container
```
docker start [container]
```
>Stop a running container
```
docker stop [container]
```
>Delete a container (if it is not running)
```
docker rm [container]
```

## Docker Image Commands
### Build/Create an Image
> Create an image from a Dockerfile:
```
docker build [path/Dockerfile]
```
- `docker build -t` - builds an image from a Dockerfile in the current directory and tags the image

### Create/build from Dockerfile
> Create an empty file named `Dockerfile` inside a directory and copy and paste the text below.
```
FROM ubuntu:latest

RUN apt-get update && apt-get -y install fortune cowsay lolcat

CMD /usr/games/fortune | /usr/games/cowsay | /usr/games/lolcat
```

Then, build a Docker image named `ubuntu_fun` from the Dockerfile above
```
docker build -t ubuntu_fun .
```
Run the `ubuntu_fun` image in interactive bash shell and remove after it exited.
```
docker run -it --rm ubuntu_fun
```

### List of Docker images
> list out docker images on your environment.
```
docker image ls
```

### Delete an Docker Image
> delete an docker image by image id or image name.
```
docker image rm [image]
```

# Docker Compose
> For more information about Docker Compose, please visit [Docker Compose command-line reference](https://docs.docker.com/compose/reference/).


## docker-compose.yml
This quick-start guide demonstrates how to use Compose to set up and run containers. Before starting, make sure you have [Compose installed](https://docs.docker.com/compose/install/).

### Example 1: Ubuntu Fun
> This is an example of docker-compose.yml file for creating and run container for Ubuntu fun using Dockfile.

```
version: '3.3'

services:
    ubuntu_fun:
        build: .
        restart: always
```

### Example 2: WordPress website
> In this example, you can use Docker Compose to easily run WordPress in an isolated environment built with Docker containers.

```
version: '3.3'

services:
   db:
     image: mysql:5.7
     volumes:
       - db_data:/var/lib/mysql
     restart: always
     environment:
       MYSQL_ROOT_PASSWORD: somewordpress
       MYSQL_DATABASE: wordpress
       MYSQL_USER: wordpress
       MYSQL_PASSWORD: wordpress

   wordpress:
     depends_on:
       - db
     image: wordpress:latest
     ports:
       - "8000:80"
     restart: always
     environment:
       WORDPRESS_DB_HOST: db:3306
       WORDPRESS_DB_USER: wordpress
       WORDPRESS_DB_PASSWORD: wordpress
       WORDPRESS_DB_NAME: wordpress
volumes:
    db_data: {}
```

### Start a word press website using docker compose
> Run this command below to create and start wordpress and mysql-db containers.
```
docker-compose up -d
```

> If you are using Docker Desktop for Mac or Docker Desktop for Windows. you can use `http://localhost:8080` in a web browser.

### Shutdown and cleanup

To removes the containers and default network, but preserves your WordPress database.
```
docker-compose down
```

To removes the containers, default network, and the WordPress database.
```
docker-compose down --volumes
```

## Push a new image to your repository in Docker Hub
### Create a new repository space in Docker hub

Go to [Create repository page](https://hub.docker.com/repository/create) in docker hub.

### login to your docker hub account
```
docker login
```

### tag your local image to remote repo
```
docker tag local-image:tagname new-repo:tagname
```

For example:
```
docker tag ubuntu_fun:1.0 wingchanibsa/ubuntu_fun:1.0
```

### push docker image to remote repo
```
docker push new-repo:tagname
```

For example:
```
docker push wingchanibsa/ubuntu_fun:1.0
```

### pull remote image down to your local machine
```
docker pull repo-name/image-name:tagname
```

For example:
```
docker pull wingchanibsa/ubuntu_fun:1.0
```