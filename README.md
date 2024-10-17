 # App

## Getting Started

### Building and Running the Docker Containers

1. Ensure you are in the root directory of the repository.

2. Build the Docker image:
   
    ```bash
    docker build -t memo4me-image -f devops/Dockerfile .
    ```

3. Run the Docker container:

    ```bash
    docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development memo4me-image
    ```