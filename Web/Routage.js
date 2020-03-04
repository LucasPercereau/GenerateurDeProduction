function Router(ID,posX,posY,dispersion,objS1,objS2,linkID){
  this.ID=ID;
  this.x=posX;
  this.y=posY;
  this.dispersion=dispersion;
  this.objS1=objS1;
  this.objS2=objS2;
  this.compteur=0;
  this.linkID=linkID;
}

Router.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y-40, 20, 70);
  ctx.fillRect(this.x-20, this.y-15, 30, 15);
  ctx.fillText("["+this.dispersion+"]", this.x+25,this.y-4);
}
Router.prototype.SetSuiv = function(obj,idE){
  if(idE===1)
  {
    this.objS1 = obj;
  }
  else
  {
    this.objS2 = obj;
  }
}
Router.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Router.prototype.ProductArrive = function(ressource){
	if(ressource instanceof Paquet)
  {
    for(i=0;i<ressource.nbRessources;i++)
    {
      this.addToMachine(new Ressource(this.x,this.y)); 
    }
  }
  else
  {
    this.addToMachine(ressource);  
  } 
}

Router.prototype.addToMachine = function(ressource){  //obligé de passe addToMachine 
	if(this.dispersion[this.compteur%this.dispersion.length] ===0){
		if(this.objS1!=null)
    {     
        this.objS1.ProductArrive(ressource,this.linkID);               
    }
	}
	else if (this.dispersion[this.compteur%this.dispersion.length] ===1){
		if(this.objS2!=null)
    {     
      this.objS2.ProductArrive(ressource,this.linkID);                     
    }
	}
	this.compteur++;
}
