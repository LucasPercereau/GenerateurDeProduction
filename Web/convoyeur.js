function Convoyeur(ID,posX,posY,posX2,posY2,duree,objS,linkID) {
  this.ID=ID;
  this.X1 = posX;
  this.Y1 = posY;
  this.X2 = posX2;
  this.Y2 = posY2;
  this.duree=duree;
  this.tabRessource=[];
  this.tabPaquet=[];
  this.objS = objS;
  this.linkID=linkID;
}
Convoyeur.prototype.draw = function() {
  this.drawLine();
  this.drawAllRessource();
  this.avance();
  this.checkRessource();
}
Convoyeur.prototype.drawLine = function() {
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
Convoyeur.prototype.SetLinkId = function(id){
  this.linkID=id;
}

Convoyeur.prototype.avance = function()
{
	var nb = ((this.X2-this.X1)/this.duree)/60
	this.tabRessource.forEach(function Coord(e){e.x+=nb;});
	this.tabPaquet.forEach(function Coord(e){e.x+=nb;});
}

Convoyeur.prototype.ProductArrive = function(ressource)
{
	if(ressource instanceof Paquet)
	{
	   ressource.x=this.X1;
	   ressource.y=this.Y1-10;	  
	   this.tabPaquet.push(ressource); 	  
	}
	else
	{
	   ressource.x=this.X1;
	   ressource.y=this.Y1-ressource.radius/2;
	   this.tabRessource.push(ressource); 
	} 
}
Convoyeur.prototype.delRessource = function()
{
	this.tabRessource.shift();
}
Convoyeur.prototype.delPaquet = function()
{
	this.tabPaquet.shift();
}
Convoyeur.prototype.checkRessource = function()
{
	let m_x = this.X1;
	let m_largeur = this.X2-this.X1;
	let suiv = this.objS;
	let id = this.linkID;
	var self = this;
	this.tabRessource.forEach(function Coord(e){
		if(e.x>=m_x+m_largeur)
		{
			if(suiv!=null)
			{
				suiv.ProductArrive(e,id);												
			}			
			self.delRessource();				
		}
	});
	this.tabPaquet.forEach(function Coord(e){
		if(e.x>=m_x+m_largeur)
		{
			if(suiv!=null)
			{
				suiv.ProductArrive(e,id);												
			}			
			self.delPaquet();				
		}
	});
}

Convoyeur.prototype.drawAllRessource = function()
{
	this.tabRessource.forEach(function Coord(e){e.draw();});
	this.tabPaquet.forEach(function Coord(e){e.draw();});
}



