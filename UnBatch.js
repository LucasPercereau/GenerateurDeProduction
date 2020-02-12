function UnBatch(posX,posY,tailleLot,objS,linkID){
  this.x=posX;
 	this.y=posY;
  this.tailleLot = tailleLot;
  this.objS=objS;
  this.linkID=linkID;
}

UnBatch.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText("1 > "+this.tailleLot, this.x+5,this.y-10);
}

UnBatch.prototype.ProductArrive= function()
{
  if(this.objS!=null)
  {
    if(this.objS instanceof Match)
    {
      this.objS.ProductArrive(ball,this.linkID);
    }else if(this.objS instanceof Mux)
    {
      this.objS.ProductArrive(ball,this.linkID);
    }
    else
    {
      this.objS.ProductArrive(ball);
    }                 
    for(i=0;i<this.tailleLot;i++)
    {
      objS.addBall(new ball(10,10,3,0,10));   
    }  
  }
}