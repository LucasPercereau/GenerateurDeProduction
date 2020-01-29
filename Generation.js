tabMachine[1]= new Machine(700,240,10,);
tabConvoyeur[2]= new convoyeur(400,300,300,20,tabMachine[1]);
tabMachine[2]= new Machine(400,240,10,tabConvoyeur[2]);
tabConvoyeur[4]= new convoyeur(0,300,400,20,tabMachine[2]);
drawCanvas();