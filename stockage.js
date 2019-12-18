class stockage {

  constructor(posX,posY,capacite,objS) {
    this.x=posX;
   	this.y=posY;
   	this.capacite=capacite;
    this.tabBall=[];
    this.objS=objS;
    this.nbBall=0;
  }
  draw() {
    ctx.fillRect(this.x, this.y, 20, 50);
    ctx.fillText(this.capacite, this.x+25,this.y);
  }

  addBall(ball)
  {
    this.tabBall[this.nbBall]=ball;
    this.nbBall+=1;
    this.capacite-=1;
    if(this.capacite==0)
    {
      this.sortir();
    }
    this.draw();
  }

  sortir()
  {
    this.objS.addBall(this.tabBall[0]);
   

    this.tabBall.shift();
    this.nbBall-=1;
    this.capacite+=1;
  }
}