function Machine(ID,posX,posY,capacite,objS,linkID){
  this.ID=ID;
  this.x=posX;
 	this.y=posY;
 	this.capacite=capacite;
  this.tabRessource=[];
  this.tabStock=[];
  this.objS=objS;
  this.nbRessource=0;
  this.nbStock=0;
  this.linkID=linkID;
}

Machine.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y-50, 30, 50);
  ctx.fillRect(this.x-20, this.y-10, 20, 10);
  ctx.fillText(this.nbRessource+"/"+this.capacite, this.x,this.y-55);
  ctx.fillText(this.nbStock, this.x-15,this.y+10);
  this.checkStock();
}
Machine.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Machine.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Machine.prototype.ProductArrive= function(ressource)
{

  if(ressource instanceof Paquet)
  {
    for(i=0;i<ressource.nbRessources;i++)
    {
      if(this.nbRessource==this.capacite)
      {
      this.addToStock(new Ressource(this.objS.x,this.objS.y));
      }else{
      this.tabRessource.push(new Ressource(this.objS.x,this.objS.y));
      this.nbRessource+=1;
      setTimeout(this.sortir.bind(this), 2000);  
      }
    }
  }
  else
  {
    if(this.nbRessource==this.capacite)
    {
      this.addToStock(Ressource);
    }else{
      this.tabRessource.push(Ressource);
      this.nbRessource+=1;
      setTimeout(this.sortir.bind(this), 2000);  
    }
  }   
  this.draw();
}

Machine.prototype.addToStock= function(Ressource)
{
  this.tabStock[this.nbStock]=Ressource;
  this.nbStock+=1;
}
Machine.prototype.checkStock= function()
{
  if(this.nbRessource<this.capacite && this.nbStock>0)
  {
    this.ProductArrive(this.tabStock[0]);
    this.tabStock.shift();
    this.nbStock-=1;
  }
}
Machine.prototype.sortir= function()
{
  if(this.objS!=null)
  {   
    this.objS.ProductArrive(new Ressource(this.objS.x,this.objS.y),this.linkID);               
  }
  this.tabRessource.shift();
  this.nbRessource-=1;
}