 # App

## Getting Started

### Building and Running the Docker Containers

1. Ensure you are in the root directory of the repository.

2. Build the UI Docker image:

    ```bash
    docker build -t memo4me-ui-image -f devops/UI.Dockerfile .
    ```

   Build the API Docker image:

   ```bash
    docker build -t memo4me-api-image -f devops/API.Dockerfile .
    ```

3. Run the Docker containers:

   Run the UI container:
    ```bash
    docker run -d -p 5160:8080 -e ASPNETCORE_ENVIRONMENT=Development memo4me-ui-image
    ```

    Run the API container:
    ```bash
    docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development memo4me-api-image
    ```