class convoyeur {

  constructor(posX,posY,largeur,hauteur,objS) {
    this.hauteur = hauteur;
    this.largeur = largeur;
    this.x=posX;
   	this.y=posY;
   	this.tabBall=[];
   	this.objS = objS;
  }
  draw(color) {
  	ctx.fillStyle = color;
    ctx.fillRect(this.x, this.y, this.largeur, this.hauteur);
  }

  addBall(ball){
  	ball.x=this.x;
  	ball.y=this.y-ball.radius/2;
  	this.tabBall.push(ball);
  }
  delBall()
  {
  	this.tabBall.shift();
  }
  checkBall()
  {
  	let m_x = this.x;
  	let m_largeur = this.largeur;
  	let suiv = this.objS;
  	var self = this;
  	this.tabBall.forEach(function Coord(e){
  		if(e.x>=m_x+m_largeur)
  		{
  			if(suiv!=null)
  			{
  				suiv.addToMachine(e); 
  				self.delBall();		
  			}
  			else
  			{
  				self.delBall();
  			}	
  		}
  	});
  }

  drawAllBall()
  {
  	this.tabBall.forEach(function Coord(e){e.draw();});
  }

  avance()
  {
  	this.tabBall.forEach(function Coord(e){e.x+=e.vx;});
  }
}
