class ball {

  constructor(posX,posY,vx,vy,radius) {
    this.vx = vx;
    this.vy = vy;
    this.x=posX;
   	this.y=posY-radius/2;
   	this.radius=radius;
  }
  draw(color) {
    ctx.beginPath();
    ctx.arc(this.x, this.y, this.radius, 0, Math.PI*2, true);
    ctx.closePath();
    ctx.fillStyle = color;
    ctx.fill();
  }
}
