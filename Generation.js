tabConvoyeur[5]= new Convoyeur(965,400,100,20,null,2);
tabUnBatch[0]= new UnBatch(920,385,3,tabConvoyeur[5]);

tabConvoyeur[4]= new Convoyeur(800,400,100,20,tabUnBatch[0],2);
tabBatch[0]= new Batch(760,385,3,tabConvoyeur[4]);

tabConvoyeur[3]= new Convoyeur(650,400,100,20,tabBatch[0],2);

tabMatch[0]= new Match(600,380,tabConvoyeur[3]);
tabConvoyeur[2]= new Convoyeur(250,500,300,20,tabMatch[0],2);
tabArriveeManuelle[1] = new ArriveeManuelle(200,440,"tabArriveeManuelle[1]",tabConvoyeur[2]);

tabConvoyeur[1]= new Convoyeur(420,300,150,20,tabMatch[0],1);
tabMachine[0]= new Machine(400,240,10,tabConvoyeur[1]);
tabConvoyeur[0]= new Convoyeur(250,300,150,20,tabMachine[0]);
tabArriveeManuelle[0] = new ArriveeManuelle(200,240,"tabArriveeManuelle[0]",tabConvoyeur[0]);



drawCanvas();