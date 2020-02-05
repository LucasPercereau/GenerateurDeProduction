function Batch(posX,posY,tailleLot,objS){
  this.x=posX;
 	this.y=posY;
  this.tailleLot = tailleLot;
  this.tabStock=[];
  this.objS=objS;
  this.nbStock=0;
}

Batch.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText(this.nbStock+" / "+this.tailleLot, this.x+5,this.y-10);
}

Batch.prototype.check= function()
{
  if(this.nbStock>=this.tailleLot)
  {
    this.sortir(this.tabStock[0]);
  }
}


Batch.prototype.Enter= function(ball)
{
  this.tabStock.push(ball);
  this.nbStock+=1;
  this.check();
}
Batch.prototype.sortir= function(ball)
{
  if(this.objS != null)
  {
    this.objS.addBall(ball);
  }
  for(i=0;i<this.tailleLot;i++)
  {
    this.tabStock.shift();
     this.nbStock-=1;
  }
}