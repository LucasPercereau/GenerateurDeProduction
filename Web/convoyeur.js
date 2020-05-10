function Convoyeur(ID,posX,posY,points,duree,objS,linkID) {
  this.ID=ID;
  this.X = posX;
  this.Y = posY;
  this.duree=duree;
  this.tabRessource=[];
  this.tabPaquet=[];
  this.objS = objS;
  this.linkID=linkID;
  this.points=points
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
  
  ctx.moveTo(this.points[0][0],this.points[0][1]);
  let i=1;
  for (i = 1; i < this.points.length; i++) 
  {
  	ctx.lineTo(this.points[i][0],this.points[i][1]);
  }
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
	var nb = ((this.points[this.points.length-1][0]-this.X)/this.duree)/60
	
	if(this.tabRessource.length>0)
	{
		for (i = 0; i < this.tabRessource.length; i++) 
		{
			if(this.tabRessource[i].x<this.points[this.points.length-1][0])
			{
			var point1=null;
			var point2=null;
			var coeff=null;
			for (j = 1; j < this.points.length; j++) 
			{
				if(this.tabRessource[i].x<=this.points[j][0])
				{
					point1=this.points[j-1];
					point2=this.points[j];
					break;
				}
			}

			coeff = (point2[1]-point1[1])/(point2[0]-point1[0]);
			this.tabRessource[i].x+=nb;
			this.tabRessource[i].y+=coeff*nb;
			}
		}
	}
	if(this.tabPaquet.length>0)
	{
		for (i = 0; i < this.tabPaquet.length; i++) 
		{
			if(this.tabPaquet[i].x<this.points[this.points.length-1][0])
			{
			var point1=null;
			var point2=null;
			var coeff=null;
			for (j = 1; j < this.points.length; j++) 
			{
				if(this.tabPaquet[i].x<=this.points[j][0])
				{
					point1=this.points[j-1];
					point2=this.points[j];
					break;
				}
			}
			coeff = (point2[1]-point1[1])/(point2[0]-point1[0]);
			this.tabPaquet[i].x+=nb;
			this.tabPaquet[i].y+=coeff*nb;		
			}	
		}	
	}
}

Convoyeur.prototype.ProductArrive = function(ressource)
{
	if(ressource instanceof Paquet)
	{
	   ressource.x=this.points[0][0]+2;	
	   ressource.y=this.points[0][1]-10;	  
	   this.tabPaquet.push(ressource); 	  
	}
	else
	{
	   ressource.x=this.points[0][0]+2;
	   ressource.y=this.points[0][1]-ressource.radius/2;
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
	let m_x = this.X;
	let m_largeur = this.points[this.points.length-1][0]-this.X;
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



