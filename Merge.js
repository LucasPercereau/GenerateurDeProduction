function Merge(ID,posX,posY,objS,linkID){
  this.ID=ID;
  this.x=posX;
  this.y=posY;
  this.objS=objS;
  this.linkID=linkID;
}

Merge.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x+5, this.y+25, 30, 15);
  ctx.fillText("[MERGE]", this.x-50,this.y+36);
}
Merge.prototype.SetSuiv = function(obj){
  this.objS = obj;
}

Merge.prototype.ProductArrive= function(ball)
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
  }
}