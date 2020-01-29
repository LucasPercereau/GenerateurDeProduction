class Machine {

  constructor(posX,posY,capacite,objS) {
    this.x=posX;
   	this.y=posY;
   	this.capacite=capacite;
    this.tabBall=[];
    this.objS=objS;
    this.nbBall=0;
    this.nbStock=0;
  }
  draw() {
    ctx.fillRect(this.x, this.y, 30, 50);
    ctx.fillRect(this.x-20, this.y+40, 20, 10);
    ctx.fillText(this.nbBall+"/"+this.capacite, this.x,this.y-5);
    ctx.fillText(this.nbStock, this.x-15,this.y+60);
  }

  addToMachine(ball)
  {
    if(this.nbBall=this.capacite)
    {
      this.addToStock(ball);
      this.nbStock+=1;
    }else{
      this.tabBall[this.nbBall]=ball;
      this.nbBall+=1;
    }
    this.draw();
  }

  sortir()
  {
    if(this.objS != null)
    {
      this.objS.addBall(this.tabBall[0]);
    }
    this.tabBall.shift();
    this.nbBall-=1;
  }
}
