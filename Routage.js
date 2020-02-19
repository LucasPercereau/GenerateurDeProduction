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
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x-20, this.y+25, 30, 15);
  ctx.fillText("["+this.dispersion+"]", this.x+25,this.y+36);
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

Router.prototype.ProductArrive = function(ball){
	this.addToMachine(ball);
}

Router.prototype.addToMachine = function(ball){  //obligé de passe addToMachine 
	if(this.dispersion[this.compteur%this.dispersion.length] ===0){
		if(this.objS1!=null)
    {
      if(this.objS1 instanceof Match)
      {
        this.objS1.ProductArrive(ball,1);
      }else if(this.objS1 instanceof Mux)
      {
        this.objS1.ProductArrive(ball,1);
      }
      else
      {
        this.objS1.ProductArrive(ball);
      }                 
    }
	}
	else if (this.dispersion[this.compteur%this.dispersion.length] ===1){
		if(this.objS2!=null)
    {
      if(this.objS2 instanceof Match)
      {
        this.objS2.ProductArrive(ball,this.linkID);
      }else if(this.objS2 instanceof Mux)
      {
        this.objS2.ProductArrive(ball,this.linkID);
      }
      else
      {
        this.objS2.ProductArrive(ball);
      }                 
    }
	}
	this.compteur++;
}
