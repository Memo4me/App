 # App

## Getting Started

### Building and Running the Docker Containers

1. Navigate to the Infra Repository
   Since docker-compose.yml is located in the Infra repository, make sure you navigate there first:

    ```bash
    cd ../Infra
    ```

2. Build and start the Docker containers using docker-compose:
   
    ```bash
    docker-compose up -d --build
    ```

3. To stop the containers, use:

    ```bash
    docker-compose down
    ```

### Rebuilding and Restarting Containers

To rebuild the images and restart the containers after making changes, run:

    ```bash
    docker-compose up -d --build
    ```