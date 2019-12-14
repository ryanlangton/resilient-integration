# If started without argument, the solution is started without service-mesh. 
# If started with argument -istio, the solution is started with the Istio service-mesh.
# If started with argument -linkerd, the solution is started with the Linkerd service-mesh.

param (
    [switch]$istio = $false,
    [switch]$linkerd = $false
)

if ($istio -and $linkerd) {
    echo "Error: You can specify only 1 mesh implementation."
    return
}

$meshPostfix = ''
if ($istio) {
    $meshPostfix = '-istio'
}
if ($linkerd) {
    $meshPostfix = '-linkerd'
}

kubectl apply `
    -f ./rabbitmq.yaml `
    -f ./logserver.yaml