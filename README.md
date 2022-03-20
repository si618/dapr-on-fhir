# Dapr on FHIR 🔥

An experiment in building microservices using [Dapr](dapr.io) and the [FHIR](https://hl7.org/fhir/) data exchange standard.

## Goals

- Learn by experimenting with RabbitMQ, Redis, and Elastic for an upcoming job
- Build a proof of concept system using a microservice architecture based on [domain driven design](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice) and [command query responsibility segregation](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/apply-simplified-microservice-cqrs-ddd-patterns)
- Learn and implement the [virtual actor pattern](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/actors) to see if it's a good fit for this experiment
- Delve more deeply into Dapr, Docker, and Kubernetes

## Overview

Implement a simplified version of a patient workflow system in a healthcare setting.

TODO: Add diagrams showing [architecture](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/media/the-world-is-distributed/distributed-design.png) and workflow [sequence](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/media/sample-application/sequence.png).

### Microservices

- `AdtService` - Simulated patient administration system for admitting/discharging patients to/from hospital
- `LabService` - Simulated laboratory system for requesting and returning pathology results
- `AlertService` - Publishes events when adverse pathology results are returned

### Applications

- A website showing current inpatients with real-time alerting as laboratory results are available
- Benchmarking to test the performance of the microservices as they work and interact with each other

## Tech stack
- Microservices are written in C# 10 / .NET 6
- [Dapr](https://docs.dapr.io/concepts/overview/) as the distributed application runtime providing cloud abstraction and observability
- [gRPC](https://docs.dapr.io/operations/configuration/grpc/) for communication between services and applications
- [Firely Server]() as the FHIR server
- [MongoDB]() as the database storing data in the FHIR server
- [Redis](https://docs.dapr.io/reference/components-reference/supported-state-stores/setup-redis/) as the state stores for patient and lab data
- [RabbitMQ](https://docs.dapr.io/reference/components-reference/supported-pubsub/setup-rabbitmq/) as the pubsub broker for patient admissions/discharges, lab requests/results, and alerts
- [Elastic](https://docs.dapr.io/operations/monitoring/logging/fluentd/) for searching all event logs generated in the system, collected by [Fluentd](https://www.fluentd.org/)
- [Docker](https://docs.dapr.io/operations/hosting/self-hosted/self-hosted-with-docker/) containers running on Linux servers orchestrated by [Kubernetes](https://docs.dapr.io/operations/hosting/kubernetes/kubernetes-overview/) via [Minikube](https://docs.dapr.io/operations/hosting/kubernetes/cluster/setup-minikube/)

## Building

### Installing

Assumes Linux or Windows 10+ with WSL 2 enabled with the following tools and source code at specified version or higher.

<details>
  <summary>Install from powershell prompt</summary>

```powershell
> $PSVersionTable.PSVersion
Major  Minor  Patch  PreReleaseLabel BuildLabel
-----  -----  -----  --------------- ----------
7      2      1

> dotnet --list-sdks
6.0.201 ...

> java --version
java 17.0.2 2022-01-18 LTS

> git --version
git version 2.35.1.windows.2

> git clone https://github.com/si618/dapr-on-fhir.git
Cloning into 'dapr-on-fhir'...

> cd ./dapr-on-fhir/src

> dapr --version
CLI version: 1.6.0
Runtime version: 1.6.0

> docker --version
Docker version 19.03.12, build 0ed913b8-

> minikube version
minikube version: v1.8.2

> dotnet tool install --global VonkLoader
You can invoke the tool using the following command: vonkloader
Tool 'vonkloader' (version '2.1.0') was successfully installed.
```
</details>


### Compiling

TODO: Describe how to compile each service and application (create powershell script to build all?)


## Running

### Acquire Firely FHIR server

Obtain a free [community license](https://docs.fire.ly/projects/Firely-Server/en/latest/deployment/docker.html) for running a local SQLite instance of the Firely server and save it in `src/docker` directory.

```powershell
> cd ./firelyserver
> docker-compose up -d
> docker ps
CONTAINER ID  IMAGE          COMMAND                 CREATED            STATUS         PORTS                   NAMES
2b9b32caed3f  firely/server  "dotnet Firely.Serve…"  About an hour ago  Up 15 minutes  0.0.0.0:8080->4080/tcp  firelyserver-vonk-web-1
```

TODO: Add Firely server to k8s cluster and dcproj?

### Seed patient data using [Synthea](https://synthetichealth.github.io/synthea/)

Generate realistic (but not real) patient data. Seed service expects the `synthea` repository to exist at the directory level as the `dapr-on-fire` repository. Feel free to experiment by adding more data (-p) or a different seed (-s).

```powershell
> cd ../../
> git clone https://github.com/synthetichealth/synthea.git
> cd ./synthea
> ./run_synthea -s 618 -p 1000 Alabama, Allgood
```

### Load patient data into FHIR server

```powershell
> cd ./output/
> Compress-Archive -Path ./fhir/ -DestinationPath ./fhir.zip
> vonkloader -file:./fhir.zip -server:http://localhost:8080
```

### Run tests and benchmarks 

### Spin up microservices

TODO:

### Start web app and dashboard

TODO:
