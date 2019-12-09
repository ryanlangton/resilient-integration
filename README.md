# resilient-integration

This project is an example architecture for integrations. It uses Web API and message queueing to create a system completely resilient to any failures. Message handlers can be easily moved across workers, workers can be scaled up and/or out, and no attempts to run integration processing will ever be lost.

Architecture:

![architecture](images/architecture.png)

# Run instructions

- Install prerequisites Node.js, docker, docker-machine, powershell
- execute RebuildAllDockerImages.sh or .ps1
- execute .\kubernetes\start-all.sh or .ps1
- Run the API and workers locally, or in docker

# Monitoring

- RabbitMQ: http://localhost:15672/#/channels
- SEQ: http://localhost:5341/#/events