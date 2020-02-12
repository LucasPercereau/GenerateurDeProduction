function Feu(posX,posY,tmpsV,tmpsR,objS){
  this.x=posX;
  this.y=posY;
  this.objS=objS;
  this.tmpsV=tmpsV;
  this.tmpsR=tmpsR;
  this.bool="R";
  this.buffer=[];
  this.cpt=0;
  this.doOnce=0;
}

Feu.prototype.draw = function() {
  
  ctx.fillRect(this.x, this.y, 20, 70);
  if(this.bool === "V") {ctx.fillText("[FEU VERT]", this.x-10,this.y-36);}
  if(this.bool === "R") {ctx.fillText("[FEU ROUGE]", this.x-10,this.y-36);} 
  ctx.fillText(this.cpt, this.x+7,this.y-10);
  this.check();
  if(this.doOnce===0) {this.FeuRouge(); this.doOnce=1;}
}

Feu.prototype.enter = function(ball) {
  this.buffer.push(ball);
  this.cpt++;
}

Feu.prototype.FeuVert = function() {
  this.bool = "V";
  setTimeout(this.FeuRouge.bind(this), this.tmpsV);
}
Feu.prototype.FeuRouge = function() {
  this.bool = "R";
  setTimeout(this.FeuVert.bind(this), this.tmpsR);
}

Feu.prototype.check = function() {
  if(this.bool === "V" && this.cpt>0)
  {
    for(i=0;i<this.cpt;i++)
    {
      this.sortir(this.buffer[0]);
      this.buffer.shift();
      this.cpt--;
    }    
  }
}

Feu.prototype.sortir= function(ball)
{
  if(this.objS!=null)
  {
    if(this.objS instanceof Convoyeur)
    {
      this.objS.addBall(ball);
    }
    if(this.objS instanceof Machine)
    {
      this.objS.addToMachine(ball);
    }
    if(this.objS instanceof Match)
    {
      this.objS.addToEnter(ball,id);
    }
    if(this.objS instanceof Batch)
    {
      this.objS.Enter(ball);
    }
    if(this.objS instanceof UnBatch)
    {
      this.objS.sortir(ball);
    }
    if(this.objS instanceof Mux)
    {
      this.objS.addToBuffer(ball,id);
    } 
    if(this.objS instanceof Merge)
    {
      this.objS.sortir(ball);
    }
    if(this.objS instanceof Feu)
    {
      this.objS.enter(ball);
    }           
  }   
}