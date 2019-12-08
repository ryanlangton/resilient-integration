#!/bin/bash

# If started without argument, the solution is started without service-mesh. 
# If started with argument --istio, the solution is started with the Istio service-mesh.
# If started with argument --linkerd, the solution is started with the Linkerd service-mesh.

MESHPOSTFIX=''

if [ "$1" = "--istio" ]
then
    MESHPOSTFIX='-istio'
fi

if [ "$1" = "--linkerd" ]
then
    MESHPOSTFIX='-linkerd'
fi

kubectl apply \
    -f ./logserver.yaml \
    -f ./rabbitmq.yaml \
    -f ./sqlserver.yaml \
