function Convoyeur(ID,posX,posY,posX2,posY2,objS,linkID) {
  this.ID=ID;
  this.X1 = posX;
  this.Y1 = posY;
  this.X2 = posX2;
  this.Y2 = posY2;
  this.tabBall=[];
  this.objS = objS;
  this.linkID=linkID;
}
Convoyeur.prototype.draw = function(color) {
  this.drawLine(color);
  this.drawAllBall();
  this.avance();
  this.checkBall();
}
Convoyeur.prototype.drawLine = function(color) {
  ctx.lineWidth='8';
  ctx.strokeStyle='green';
  ctx.beginPath();
  ctx.moveTo(this.X1,this.Y1);
  ctx.lineTo(this.X2,this.Y2);
  ctx.stroke();
}
Convoyeur.prototype.SetSuiv = function(obj){
  this.objS = obj;
}


Convoyeur.prototype.ProductArrive = function(ball){
	ball.x=this.X1;
	ball.y=this.Y1-ball.radius/2;
	this.tabBall.push(ball);
}
Convoyeur.prototype.delBall = function()
{
	this.tabBall.shift();
}
Convoyeur.prototype.checkBall = function()
{
	let m_x = this.X1;
	let m_largeur = this.X2-this.X1;
	let suiv = this.objS;
	let id = this.linkID;
	var self = this;
	this.tabBall.forEach(function Coord(e){
		if(e.x>=m_x+m_largeur)
		{
			if(suiv!=null)
			{
				if(suiv instanceof Match)
				{
					suiv.ProductArrive(e,id);
				}
							
				if(suiv instanceof Mux)
				{
					suiv.ProductArrive(e,id);
				}else
				{
					suiv.ProductArrive(e);
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

