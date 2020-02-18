# Installation Guide
> Docker Engine is available on a variety of Linux platforms, Mac and Windows through Docker Desktop, Windows Server, and as a static binary installation. Here is the 
[Docker Installation Page](https://docs.docker.com/install/)

# Basic commands
For more information about Docker commands, please visit [Docker Documentation](https://docs.docker.com/engine/reference/commandline/docker/).

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