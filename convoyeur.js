function Convoyeur(posX,posY,largeur,hauteur,objS) {
  this.hauteur = hauteur;
  this.largeur = largeur;
  this.x=posX;
 	this.y=posY;
 	this.tabBall=[];
 	this.objS = objS;
}
Convoyeur.prototype.draw = function(color) {
	ctx.fillStyle = color;
  ctx.fillRect(this.x, this.y, this.largeur, this.hauteur);
}

Convoyeur.prototype.addBall = function(ball){
	ball.x=this.x;
	ball.y=this.y-ball.radius/2;
	this.tabBall.push(ball);
}
Convoyeur.prototype.delBall = function()
{
	this.tabBall.shift();
}
Convoyeur.prototype.checkBall = function()
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

Convoyeur.prototype.drawAllBall = function()
{
	this.tabBall.forEach(function Coord(e){e.draw();});
}

Convoyeur.prototype.avance = function()
{
	this.tabBall.forEach(function Coord(e){e.x+=e.vx;});
}

