# App

## Getting Started

### Building and Running the Docker Containers

1. Navigate to the `App` directory

2. Build the Docker image:
   
    docker build -t memo4me-image -f devops/Dockerfile .

3. Run the Docker container:
    docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development memo4me-image