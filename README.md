# budget-app-api

# DOCKER
To build image(in root folder): docker build -t budget-app-api .
To run container: docker run -p 80:80 budget-app-api:latest

# KUBERNETES
To create pods in cluster(root folder): kubectl apply -f deploy-api.yml
To revert deployment: kubectl delete -f deploy-api.yml