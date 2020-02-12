tabMachine[0]= new Machine(600,240,10,);
tabConvoyeur[0]= new Convoyeur(250,300,300,20,tabMachine[0]);
tabArriveeManuelle[0] = new ArriveeManuelle(200,240,"tabArriveeManuelle[0]",tabConvoyeur[0]);

drawCanvas();