function ArriveeManuelle(ID,posX,posY,firstElement,objS,linkID) {

    this.ID=ID;
    this.x=posX;
    this.y=posY;
    this.objS=objS;
    this.linkID=linkID;

    var input = document.createElement("input");
    input.type = "button";
    input.value = "Ball";
    input.setAttribute("onclick", firstElement+".CreateBall();");

    var body = document.getElementsByTagName("header")[0];
    body.appendChild(input);
}

ArriveeManuelle.prototype.draw = function(){
  ctx.fillRect(this.x-20, this.y, 30, 10);  
  ctx.fillRect(this.x, this.y-20, 10, 30);
  ctx.fillRect(this.x-20, this.y-20, 30, 10);
  ctx.fillRect(this.x-20, this.y-20, 10, 30); 
}
ArriveeManuelle.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
  
ArriveeManuelle.prototype.CreateBall = function()
{
  this.objS.ProductArrive(new ball(this.objS.x,this.objS.y,3,0,10));
}