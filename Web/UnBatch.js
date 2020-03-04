function UnBatch(ID,posX,posY,tailleLot,objS,linkID){
  this.ID=ID;
  this.x=posX;
 	this.y=posY;
  this.tailleLot = tailleLot;
  this.objS=objS;
  this.linkID=linkID;
}

UnBatch.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText("1 > "+this.tailleLot, this.x+5,this.y-10);
}
UnBatch.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
UnBatch.prototype.SetLinkId = function(id){
  this.linkID=id;
}

UnBatch.prototype.ProductArrive= function(Ressource)
{
  if(this.objS!=null)
  {
    this.objS.ProductArrive(new Paquet(this.objS.x,this.objS.y,this.tailleLot),this.linkID);  
  }
}