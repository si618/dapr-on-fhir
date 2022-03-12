# Dapr with FHIR!

An experiment in building microservices. Uses [Dapr](dapr.io) and the [FHIR](https://hl7.org/fhir/) data exchange standard in a containerized environment.

## Goals

- Learn by experimenting with RabbitMQ, Redis, and Elastic for an upcoming job
- Build a proof of concept system using a microservice architecture
- Learn the [virtual actor pattern](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/actors) to see if it's a good fit for this experiment
- Delve more deeply into Dapr, Docker, and Kubernetes

## Overview

Implements a simplified version of a patient workflow system in a healthcare setting.

TODO: Add diagrams showing [architecture](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/media/the-world-is-distributed/distributed-design.png) and workflow [sequence](https://docs.microsoft.com/en-us/dotnet/architecture/dapr-for-net-developers/media/sample-application/sequence.png).

### Microservices

- `PasService` - Simulated patient administration system for admitting patients to hospital
- `LabService` - Simulated laboratory system for analysing pathology results
- `AlertService` - Service for generating events based upon specific adverse pathology results

### Applications

- A website showing current inpatients with real-time alerting as laboratory results are available
- Benchmarking to test the performance of the microservices as they work and interact with each other

## Tech stack
- Microservices written in C# 10 / .NET 6
- [dapr](https://docs.dapr.io/concepts/overview/) as the distributed application runtime
- [Redis](https://docs.dapr.io/reference/components-reference/supported-state-stores/setup-redis/) as the state store for patient and lab data
- [RabbitMQ](https://docs.dapr.io/reference/components-reference/supported-pubsub/setup-rabbitmq/) as the pub/sub broker for patient admissions and alerting
- [Elastic](https://docs.dapr.io/operations/monitoring/logging/fluentd/) for searching all event logs generated in the system and collected by [fluentd](https://www.fluentd.org/)
- [Docker](https://docs.dapr.io/operations/hosting/self-hosted/self-hosted-with-docker/) containers orchestrated by [Kubernetes](https://docs.dapr.io/operations/hosting/kubernetes/kubernetes-overview/) using Linux servers managed by [Rancher](https://rancher.com/why-rancher)

## Building

TODO: Describe the process to clone and build all services with the necessary tooling installed 

## Running

TODO: Describe how to start each service as well as run the benchmark performance tests
