class Machine {

  constructor(posX,posY,capacite,objS) {
    this.x=posX;
   	this.y=posY;
   	this.capacite=capacite;
    this.tabBall=[];
    this.tabStock=[];
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
    if(this.nbBall==this.capacite)
    {
      this.addToStock(ball);
    }else{
      this.tabBall.push(ball);
      this.nbBall+=1;

      setTimeout(this.sortir.bind(this), 4000);  
    }
    this.draw();
  }

  addToStock(ball)
  {
    this.tabStock[this.nbStock]=ball;
    this.nbStock+=1;
  }
  checkStock()
  {
    if(this.nbBall<this.capacite && this.nbStock>0)
    {
      this.addToMachine(this.tabStock[0]);
      this.tabStock.shift();
      this.nbStock-=1;
    }
  }
  sortir(tabBall)
  {
    if(this.objS != null)
    {
      this.objS.addBall(this.tabBall[0]);
    }
    this.tabBall.shift();
    this.nbBall-=1;
  }
}
