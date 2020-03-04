function Batch(ID,posX,posY,tailleLot,objS,linkID){
  this.ID=ID;
  this.x=posX;
 	this.y=posY;
  this.tailleLot = tailleLot;
  this.tabStock=[];
  this.objS=objS;
  this.nbStock=0;
  this.linkID=linkID;
}

Batch.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText(this.nbStock+" / "+this.tailleLot, this.x+5,this.y-10);
}
Batch.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Batch.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Batch.prototype.check= function()
{
  if(this.nbStock>=this.tailleLot)
  {
    this.sortir();
  }
}


Batch.prototype.ProductArrive= function(ressource)
{
  if(ressource instanceof Paquet)
  {
    for(i=0;i<ressource.nbRessources;i++)
    {
      this.tabStock.push(new Ressource(this.objS.x,this.objS.y));
      this.nbStock+=1;
    }
  }
  else
  {
    this.tabStock.push(ressource);
    this.nbStock+=1;   
  } 
  this.check();
}
Batch.prototype.sortir= function()
{
  if(this.objS!=null)
  {
                           
    this.objS.ProductArrive(new Paquet(this.objS.x,this.objS.y,this.tailleLot),this.linkID);
    this.nbStock-=this.tailleLot;
    for(i=0;i<this.tailleLot;i++)
    {
      this.tabStock.shift();      
    }
  }
}