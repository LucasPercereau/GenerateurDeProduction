function Merge(ID,posX,posY,objS,linkID){
  this.ID=ID;
  this.x=posX;
  this.y=posY;
  this.objS=objS;
  this.linkID=linkID;
}

Merge.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x+5, this.y+25, 30, 15);
  ctx.fillText("[MERGE]", this.x-50,this.y+36);
}
Merge.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Merge.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Merge.prototype.ProductArrive= function(ressource)
{
  if(this.objS!=null)
  {  
    if(ressource instanceof Paquet)
    {
      this.objS.ProductArrive(new Paquet(this.objS.x,this.objS.y,ressource.nbRessources),this.linkID);
    }
    else
    {
      this.objS.ProductArrive(new Ressource(this.objS.x,this.objS.y),this.linkID);
    }                   
  }
}