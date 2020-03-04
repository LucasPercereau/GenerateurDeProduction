function Paquet(posX,posY,nb) {
  this.x=posX;
  this.y=posY;
  this.nbRessources=nb;
}

Paquet.prototype.draw= function() {
  ctx.fillStyle = 'blue';
  ctx.strokeStyle = 'blue';
  ctx.fillText(this.nbRessources, this.x+7,this.y-5)
  ctx.fillRect(this.x, this.y, 20, 20); 
}

