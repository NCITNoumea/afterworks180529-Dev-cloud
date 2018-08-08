docker stop happyfacedemo
docker rm happyfacedemo

Write-Output "Get environment values from Az Vault ..."
$AKV_NAME="msafterworks"
$ConnectionString=$(az keyvault secret show --vault-name $AKV_NAME -n ConnectionString --query value -o tsv)
$OcpApimSubscriptionKey=$(az keyvault secret show --vault-name $AKV_NAME -n OcpApimSubscriptionKey --query value -o tsv)

if ($ConnectionString -and $OcpApimSubscriptionKey)
{
    Write-Output "Lancement du conteneur ..."
    docker run -d --name happyfacedemo -p 80:80 -e ConnectionStrings:DefaultConnection=$ConnectionString -e Ocp-Apim-Subscription-Key=$OcpApimSubscriptionKey -t msafterworks.azurecr.io/happyfacedemo:latest
}
else
{
    Write-Error "Les variables d'environnement ne semble pas correctes. Arrêt du lancement du conteneur".
}