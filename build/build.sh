#! /bin/bash
if ! hash jq
then
    sudo apt-get install jq
fi

version=$(jq -r .Version ../appsettings.json)

sudo docker build -t cooler09/api-pickupvb:$version -t cooler09/api-pickupvb:latest ../.
sudo docker push cooler09/api-pickupvb:$version
sudo docker push cooler09/api-pickupvb:latest