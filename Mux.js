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
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x+5, this.y+25, 30, 15);
  ctx.fillText(this.nbStock1, this.x-15,this.y+10);
  ctx.fillText(this.nbStock2, this.x-15,this.y+65);
  ctx.fillText("["+this.sequence+"]", this.x-50,this.y+36);
  this.check();
}
Mux.prototype.SetSuiv = function(obj){
  this.objS = obj;
}

Mux.prototype.ProductArrive = function(ball,id){  
  
  if(id==1) 
  {    
    this.buffer1.push(ball);
    this.nbStock1 +=1;
  }
  if(id==2) 
  {    
    this.buffer2.push(ball);
    this.nbStock2 +=1;
  }
  this.check();
}

Mux.prototype.check= function(ball)
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
Mux.prototype.sortir= function(ball)
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