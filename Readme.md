#Let's go Biking

L'objectif de ce projet est de créer toutes les parties d'une application qui permettraient à l'utilisateur de trouver son chemin de n'importe quel endroit
à n'importe quel autre endroit (dans une même ville pour une première version) en utilisant autant que possible les vélos proposés par JC Decaux.

##Elements constitutifs

* *JcDecauxService* :
le service distant de JcDecaux pour la gestion des ses stations et de ses velos.

* *OpenRouteService* : Service distant permettante recuperer les itineraires open streetMap à partir des coordonnées de deux points

* *WebProxyService* : Service WCF permettant de recuperer les informations d'une station en cominiquant avec jcdecauxService
et permettant de le mettre en cache

* *Routing* : service WCF communicant avec *JcDecauxService*, *OpenRouteService* et *WebProxyService* et implementant les algorithmes
de calcule de distance et de determination du meilleur chemin pour un client

* *HeavyClient* : Client lourd WindowsForm communiquant avec *Routing* à travers des requetes SOAP

* *Light* Client légé Angular11 communiquant avec *Routing* à travers des requetes REST

* *RoutingHost* : Client console Self Hosted de *Routing*

* *WebProxyServiceHost* : Client console Self Hosted de *WebProxyService*

##Sequence de lancement du projet
* Lancer :  *Projet/LetsGoBiking/WebProxyServiceHost/bin/Debug/WebProxyServiceHost.exe*
* Lancer :  *Projet/LetsGoBiking/RoutingHost/bin/Debug/RoutingHost.exe*
* Lancer :  *Projet/LetsGoBiking/HeavyClient/bin/Debug/HeavyClient.exe*
* Aller sur :   https://let-sgobiking.web.app/


