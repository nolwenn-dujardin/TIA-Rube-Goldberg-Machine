# Concept initial :
- Faire une machine de rube goldberg

# Application développée :
- Machine de rube goldberg
- Une descente autour d'une tour + animation de fin
- 4 objets à placer (angle, 2 planche, plaque bondissante), chacun a son image target, règlage de la position et rotation
- Convoyeur activable par le passage la balle du joueur
- Interface de démarrage/remise à zéro, de placement d'objet, de fin de partie (temps de jeu, nombre d'objets utilisé)

# Manuel utilisateur :
Objectif de ce jeu :
- Compléter le parcours afin de mener la balle rouge à l'intérieur de la tour centrale.
- Deux modes de jeu disponibles :
    - Facile : les emplacements des objets à placer sont indiqués en jaune transparant
    - Difficile : les emplacements des objets à placer ne sont pas indiqués

Aides :
- Bouton ``Start`` pour démarrer la partie
- Bouton ``Reset`` pour recommencer la partie
- Pour poser un objet :
    - Positionner au préalable une image target visible à travers la caméra """"""INDIQUER LES IMAGES TARGET""""""
    - Sélectionner l'objet virtuel visible sur l'image target
    - Sélectionner le mode de placement avec le bouton central en haut: ``Rotate`` (rotater), ``Move`` (positionner). Le mode en cours est indiqué en dessous du bouton
    - Appuyer sur ``Add`` pour fixer l'objet à son emplacement actuel
    - Appuyer sur la croix pour annuler la sélection de l'objet