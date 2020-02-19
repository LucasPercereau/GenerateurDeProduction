function Feu(ID,posX,posY,tmpsV,tmpsR,objS,linkID){
  this.ID=ID;
  this.x=posX;
  this.y=posY;
  this.objS=objS;
  this.tmpsV=tmpsV;
  this.tmpsR=tmpsR;
  this.bool="R";
  this.buffer=[];
  this.cpt=0;
  this.doOnce=0;
  this.linkID =linkID;
}

Feu.prototype.draw = function() {
  
  //
  if(this.bool === "V") {this.drawFeu("green");}
  if(this.bool === "R") {this.drawFeu("red");} 
  ctx.fillText(this.cpt, this.x+7,this.y-25);
  this.check();
  if(this.doOnce===0) {this.FeuRouge(); this.doOnce=1;}
}
Feu.prototype.drawFeu = function(color) {
  ctx.lineWidth='20';
  ctx.strokeStyle=color;
  ctx.beginPath();
  ctx.moveTo(this.x+10,this.y-20);
  ctx.lineTo(this.x+10,this.y+20);
  ctx.stroke();
  ctx.fillRect(this.x+5, this.y+20, 10, 20);
}
Feu.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Feu.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Feu.prototype.ProductArrive = function(ball) {
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