function Merge(posX,posY,objS){
  this.x=posX;
  this.y=posY;
  this.objS=objS;
}

Merge.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x+5, this.y+25, 30, 15);
  ctx.fillText("[MERGE]", this.x-50,this.y+36);
}

Merge.prototype.sortir= function(ball)
{
  if(this.objS != null)
  {
    this.objS.addBall(ball);
  }
}