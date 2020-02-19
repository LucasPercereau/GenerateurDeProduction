function ArriveeManuelle(posX,posY,firstElement,objS) {

    this.x=posX;
    this.y=posY;
    this.objS=objS;

    var input = document.createElement("input");
    input.type = "button";
    input.value = "Ball";
    input.setAttribute("onclick", firstElement+".CreateBall();");

    var body = document.getElementsByTagName("header")[0];
    body.appendChild(input);
  }

ArriveeManuelle.prototype.draw = function(){
  ctx.fillRect(this.x, this.y, 30, 50);
  ctx.fillRect(this.x-20, this.y+40, 20, 10);   
}
  
ArriveeManuelle.prototype.CreateBall = function()
{
  this.objS.addBall(new ball(this.objS.x,this.objS.y,3,0,10));
}

ArriveeManuelle.prototype.next = function (objS) {
	this.objS = objS; 
}