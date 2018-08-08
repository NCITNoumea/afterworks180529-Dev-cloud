# Welcome to Afterworks Happy Face Demo

This project is not intended to be use in production. This is a demonstration application uses during Julien Chable (https://julien.chable.net) sessions to spread happinness to people :)
It will evolve overtime.

#Docker support
##Build HappyFaceDemo image
1. Run *docker-build.bat* script tp generate the container image

##Run HappyFaceDemo container
1. Run *docker-run.ps1* script to run a HappyFaceDemo image

##Deploy to Azure Container Instance
1. Run *azure-container-instance-create.ps1* script

###Prerequisites
Make sure your Azure Vault secrets are setup with values for keys :
-ConnectionString : connection string to the database
-OcpApimSubscriptionKey : Azure Cogntive Services subscription key 
-msafterworks-pull-user : Azure Registry username
-msafterworks-pull-pwd : Azure Registry password

##Ideas (Future)

- Add SignalR update
- Add push notification for bad comments to notify commercial support to make the user happy :)
- Integration with O365 and Teams
- Generate a URL Tag to make people scan the app
- Make it a PWA
- Add an Angular frontend UI