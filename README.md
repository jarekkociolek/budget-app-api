# budget-app-api

# DOCKER
To build image(in root folder): docker build -t budget-app-api .
To run container: docker run -p 80:80 budget-app-api:latest

# KUBERNETES
To create pods in cluster(root folder): kubectl apply -f deploy-api.yml
To revert deployment: kubectl delete -f deploy-api.yml

Ingress installation: https://kubernetes.github.io/ingress-nginx/deploy

# HELM
Installation of components using helm chart: helm upgrade --install budget-app-api .
Uninstall helm chart: helm uninstall budget-app-api


# INGRESS
I was missing...
    ingressClassName: nginx