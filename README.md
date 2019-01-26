# GandiDns
Un Service Windows et des dll en asp core et asp standard pour accéder à l'api de gandi.net

Brute de décoffrage. Il suffit de reprendre la solution. 

Configurer dans l'app.config vos propriétés

Compiler le projet ServiceGandi. 

Ensuite se rendre dans le dossier de sortie.
Avec la console developper de visual studio lancez la commande 
  installutil.exe ServiceGandi.exe
  
Pour finir lancer le service.

Je vais ameliorer l'install mais ca fonctionne ca me suffit


# ApiGandi
Contient une couche pour attaquer l'api de gandi.net pour la manipulation des zones et des domaines
Fait en .Net core

# ApiGandiStandard
La meme mais en .Net standard. Probleme avec les commande http de type Patch. Du coup y une commande qui ne fonctionne pas dans l'api
Utiliser pour le services qui est en .Net 

# ApiTest
Permet de tester l'api en .Net core

# ServiceGandi
Contient le service qui s'appuie sur l'api
