tabConvoyeur[5]= new Convoyeur(965,400,100,20,tabRouter[0],2);
tabFeu[0]= new Feu(920,385,1000,9000,tabConvoyeur[5]);

tabConvoyeur[4]= new Convoyeur(800,400,100,20,tabFeu[0],2);
tabBatch[0]= new Batch(760,385,3,tabConvoyeur[4]);

tabConvoyeur[3]= new Convoyeur(650,400,100,20,tabBatch[0],2);

tabMerge[0]= new Merge(600,380,tabConvoyeur[3]);
tabConvoyeur[2]= new Convoyeur(250,500,300,20,tabMerge[0],2);


tabConvoyeur[1]= new Convoyeur(420,300,150,20,tabMerge[0],1);
tabMachine[0]= new Machine(400,240,10,tabConvoyeur[1]);
tabConvoyeur[0]= new Convoyeur(250,300,150,20,tabMachine[0]);


tabRouter[0] = new Router(150,365,[0,1,0,1,1],tabConvoyeur[0],tabConvoyeur[2]);

tabArriveeManuelle[0] = new ArriveeManuelle(70,400,"tabArriveeManuelle[0]",tabRouter[0]);



drawCanvas();