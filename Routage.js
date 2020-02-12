function Router(posX,posY,dispersion,objS1,objS2){
  this.x=posX;
  this.y=posY;
  this.dispersion=dispersion;
  this.objS1=objS1;
  this.objS2=objS2;
  this.compteur=0;
}

Router.prototype.draw = function() {
  ctx.fillRect(this.x, this.y, 20, 70);
  ctx.fillRect(this.x-20, this.y+25, 30, 15);
  ctx.fillText("["+this.dispersion+"]", this.x+25,this.y+36);
}

Router.prototype.addBall = function(ball){
	this.addToMachine(ball);
}

Router.prototype.addToMachine = function(ball){  //obligé de passe addToMachine 
	if(this.dispersion[this.compteur%this.dispersion.length] ===0){
		this.objS1.addBall(ball);
	}
	else if (this.dispersion[this.compteur%this.dispersion.length] ===1){
		this.objS2.addBall(ball);
	}
	this.compteur++;
}
