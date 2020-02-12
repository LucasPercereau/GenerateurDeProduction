function UnBatch(posX,posY,tailleLot,objS){
  this.x=posX;
 	this.y=posY;
  this.tailleLot = tailleLot;
  this.objS=objS;
}

UnBatch.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText("1 > "+this.tailleLot, this.x+5,this.y-10);
}

UnBatch.prototype.sortir= function()
{
  if(this.objS != null)
  {
    let objS = this.objS;
    for(i=0;i<this.tailleLot;i++)
    {
      objS.addBall(new ball(10,10,3,0,10));   
    }  
  }
}