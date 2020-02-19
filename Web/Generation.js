tabConvoyeur[5]= new Convoyeur(965,400,1650,400,tabRouter[0],1);
tabFeu[0]= new Feu(920,385,1000,9000,tabConvoyeur[5],1);

tabConvoyeur[4]= new Convoyeur(800,400,900,400,tabFeu[0],2,1);
tabBatch[0]= new Batch(760,385,3,tabConvoyeur[4],1);

tabConvoyeur[3]= new Convoyeur(650,400,750,400,tabBatch[0],2);

tabMux[0]= new Mux(600,380,[1,1,0,1,1],tabConvoyeur[3],1);
tabConvoyeur[2]= new Convoyeur(250,500,550,500,tabMux[0],2);


tabConvoyeur[1]= new Convoyeur(420,300,570,300,tabMux[0],1);
tabMachine[0]= new Machine(400,240,10,tabConvoyeur[1],1);
tabConvoyeur[0]= new Convoyeur(250,300,400,300,tabMachine[0],1);


tabRouter[0] = new Router(150,365,[0,1,0,1,1],tabConvoyeur[0],tabConvoyeur[2],1);

tabArriveeManuelle[0] = new ArriveeManuelle(70,400,"tabArriveeManuelle[0]",tabRouter[0],1);

tabElem.push(tabConvoyeur,tabStock,tabMux,tabRouter,tabUnBatch,tabArriveeManuelle,tabRouter,tabMachine,tabMerge,tabBatch,tabFeu);


drawCanvas();