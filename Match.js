function Match(posX,posY,objS,linkID){
  this.x=posX;
 	this.y=posY;
  this.tabStock=[];
  this.objS=objS;
  this.nbStock1=0;
  this.nbStock2=0;
  this.Buffer1=[];
  this.Buffer2=[];
  this.entre1=null;
  this.entre2=null;
  this.linkID=linkID;
}

Match.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillRect(this.x-20, this.y+20, 20, 10);
  ctx.fillText(this.nbStock1, this.x-15,this.y+10);
  ctx.fillText(this.nbStock2, this.x-15,this.y+45);
  if(this.entre1!=null) {ctx.fillText("1", this.x+15,this.y-10);}
  if(this.entre2!=null) {ctx.fillText("1", this.x+15,this.y+65);}
  this.check();
}

Match.prototype.check= function()
{
  if(this.entre1!=null && this.entre2!=null)
  {
    this.sortir();
    if(this.nbStock1>0) 
    {
      this.ProductArrive(this.Buffer1=[0],1);
      this.Buffer1.shift();
      this.nbStock1-=1;
    }
    if(this.nbStock2>0) 
    {
      this.ProductArrive(this.Buffer2=[0],2);
      this.Buffer2.shift();
      this.nbStock2-=1;
    }
  }
}

Match.prototype.addBuff= function(ball,id)
{
  if(id==1) 
  {    
    this.Buffer1.push(ball);
    this.nbStock1 +=1;
  }
  if(id==2) 
  {    
    this.Buffer2.push(ball);
    this.nbStock2 +=1;
  }
}
Match.prototype.ProductArrive= function(ball,id)
{

  if(id===1) 
  {
    if(this.entre1==null)
    {
      this.entre1 = ball;    
    }
    else {this.addBuff(ball,1);}  
  }
  if(id===2) 
  {
    if(this.entre2==null)
    {
      this.entre2 = ball;    
    }
    else {this.addBuff(ball,2);}   
  }
}
Match.prototype.sortir= function()
{
  if(this.objS!=null)
  {
    if(this.objS instanceof Match)
    {
      this.objS.ProductArrive(new ball(10,10,3,0,10),this.linkID);
    }else if(this.objS instanceof Mux)
    {
      this.objS.ProductArrive(new ball(10,10,3,0,10),this.linkID);
    }
    else
    {
      this.objS.ProductArrive(new ball(10,10,3,0,10));
    }                 
  }
  this.entre1=null;
  this.entre2=null;
}