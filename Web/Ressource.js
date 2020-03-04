function Ressource(posX,posY) {
  this.radius=10;
  this.x=posX;
  this.y=posY-this.radius/2;
}

Ressource.prototype.draw= function() {
  ctx.beginPath();
  ctx.arc(this.x, this.y, this.radius, 0, Math.PI*2, true);
  ctx.closePath();
  ctx.fillStyle = 'red';
  ctx.fill();
}