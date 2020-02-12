function Convoyeur(posX,posY,largeur,hauteur,objS,linkID) {
  this.hauteur = hauteur;
  this.largeur = largeur;
  this.x=posX;
  this.y=posY;
  this.tabBall=[];
  this.objS = objS;
  this.linkID=linkID;
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
	let id = this.linkID;
	var self = this;
	this.tabBall.forEach(function Coord(e){
		if(e.x>=m_x+m_largeur)
		{
			if(suiv!=null)
			{
				if(suiv instanceof Machine)
				{
					suiv.addToMachine(e);
				}
				if(suiv instanceof Match)
				{
					suiv.addToEnter(e,id);
				}
				if(suiv instanceof Batch)
				{
					suiv.Enter(e);
				}
				if(suiv instanceof UnBatch)
				{
					suiv.sortir(e);
				}
				if(suiv instanceof Mux)
				{
					suiv.addToBuffer(e,id);
				}	
				if(suiv instanceof Merge)
				{
					suiv.sortir(e);
				}
				if(suiv instanceof Feu)
				{
					suiv.enter(e);
				}						
			}			
			self.delBall();				
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

