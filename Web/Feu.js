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
  ctx.fillStyle = 'blue';
  ctx.fillText(this.cpt, this.x+7,this.y-50);
  this.check();
  if(this.doOnce===0) {this.FeuRouge(); this.doOnce=1;}
}
Feu.prototype.drawFeu = function(color) {
  ctx.lineWidth='20';
  ctx.strokeStyle=color;
  ctx.beginPath();
  ctx.moveTo(this.x+10,this.y-45);
  ctx.lineTo(this.x+10,this.y-5);
  ctx.stroke();
  ctx.fillRect(this.x+5, this.y-5, 10, 20);
}
Feu.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Feu.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Feu.prototype.ProductArrive = function(ressource) {
  if(ressource instanceof Paquet)
  {
    for(i=0;i<ressource.nbRessources;i++)
    {
      this.buffer.push(new Ressource(this.objS.x,this.objS.y));
      this.cpt++; 
    }
  }
  else
  {
    this.buffer.push(ressource);
    this.cpt++;   
  } 
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
    this.sortir(this.cpt);    
    
    for(i=0;i<this.cpt;i++)
    {      
      this.buffer.shift();
    }  
    this.cpt=0;
  }
}

Feu.prototype.sortir= function(cpt)
{
  if(this.objS!=null)
  { 
    if(cpt===1)
    {
      this.objS.ProductArrive(new Ressource(this.objS.x,this.objS.y),this.linkID);
    }
    else
    {
      this.objS.ProductArrive(new Paquet(this.objS.x,this.objS.y,cpt),this.linkID);       
    }             
  }
}