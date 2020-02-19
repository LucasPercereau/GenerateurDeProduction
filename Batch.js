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
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillText(this.nbStock+" / "+this.tailleLot, this.x+5,this.y-10);
}
Batch.prototype.SetSuiv = function(obj){
  this.objS = obj;
}

Batch.prototype.check= function()
{
  if(this.nbStock>=this.tailleLot)
  {
    this.sortir(this.tabStock[0]);
  }
}


Batch.prototype.ProductArrive= function(ball)
{
  this.tabStock.push(ball);
  this.nbStock+=1;
  this.check();
}
Batch.prototype.sortir= function(ball)
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
      this.tabStock.shift();
       this.nbStock-=1;
    }
  }
}