function Mux(ID,posX,posY,sequence,objS,linkID){
  this.ID=ID;
  this.x=posX;
  this.y=posY;
  this.sequence=sequence;
  this.objS=objS;
  this.buffer1=[];
  this.buffer2=[];
  this.compteur=0;
  this.nbStock1=0;
  this.nbStock2=0;
  this.linkID=linkID;
}

Mux.prototype.draw = function() {
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x, this.y-40, 20, 70);
  ctx.fillRect(this.x+5, this.y-15, 30, 15);
  ctx.fillText(this.nbStock1, this.x-15,this.y-30);
  ctx.fillText(this.nbStock2, this.x-15,this.y+25);
  ctx.fillText("["+this.sequence+"]", this.x-50,this.y-4);
  this.check();
}
Mux.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
Mux.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Mux.prototype.ProductArrive = function(ressource,id){  
  if(ressource instanceof Paquet)
  {
    for(i=0;i<ressource.nbRessources;i++)
    {
      if(id==1) 
      {    
        this.buffer1.push(new Ressource(this.objS.x,this.objS.y));
        this.nbStock1 +=1;
      }
      if(id==2) 
      {    
        this.buffer2.push(new Ressource(this.objS.x,this.objS.y));
        this.nbStock2 +=1;
      }
    }
  }
  else
  {
    if(id==1) 
    {    
      this.buffer1.push(ressource);
      this.nbStock1 +=1;
    }
    if(id==2) 
    {    
      this.buffer2.push(ressource);
      this.nbStock2 +=1;
    }
  }
  
  this.check();
}

Mux.prototype.check= function(Ressource)
{
  if(this.sequence[this.compteur%this.sequence.length] ===0){
    if(this.nbStock1 > 0)
    {
      this.sortir(this.buffer1[0]);
      this.buffer1.shift();
      this.compteur++;
      this.nbStock1 -=1;
    }   
  }
  else if (this.sequence[this.compteur%this.sequence.length] ===1){
    if(this.nbStock2 > 0)
    {
      this.sortir(this.buffer2[0]);
      this.buffer2.shift();
      this.compteur++;
      this.nbStock2 -=1;
    }
  }
}
Mux.prototype.sortir= function(ressource)
{
  if(this.objS!=null)
  {   
    this.objS.ProductArrive(ressource,this.linkID);               
  }
}