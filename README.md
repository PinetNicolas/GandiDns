# GandiDns
Un Service Windows et des dll en asp core et asp standard pour accéder à l'api de gandi.net

Brute de décoffrage. Il suffit de reprendre la solution. 

Configurer dans l'app.config vos propriétés
domain : contient une liste de domaine séparer par des virgules
apikey : contient votre clé d'api gandi. Pour la récupérer c'est par ici : https://account.gandi.net/fr/
		 Dans l'onglet sécurité

Compiler le projet ServiceGandi. 

Ensuite se rendre dans le dossier de sortie.
Avec la console developper de visual studio lancez la commande 
  installutil.exe ServiceGandi.exe
  
Pour finir lancer le service.

Je vais ameliorer l'install mais ca fonctionne ca me suffit

# ApiGandiStandard
La meme mais en .Net standard. Probleme avec les commande http de type Patch. Du coup y une commande qui ne fonctionne pas dans l'api
Utiliser pour le services qui est en .Net 

# ServiceGandi
Contient le service qui s'appuie sur l'api

# GandiDns
Contient une application console en dot net core pour tout les systems. A mettre dans un cron
se lance comme ceci:
	dotnet GandiDns.dll you_list_of_domain your_api_key