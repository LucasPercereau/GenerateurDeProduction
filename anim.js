var canvas = document.getElementById('test');
var ctx = canvas.getContext('2d');
var raf;

function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  convoyeur1.draw();
  convoyeur2.draw();
  convoyeur3.draw();
  convoyeur4.draw();
  convoyeur5.draw();
  convoyeur1.drawAllBall();
  convoyeur2.drawAllBall();
  convoyeur3.drawAllBall();
  convoyeur4.drawAllBall();
  convoyeur5.drawAllBall();
  convoyeur1.avance();
  convoyeur2.avance();
  convoyeur3.avance();
  convoyeur4.avance();
  convoyeur5.avance();
  convoyeur1.checkBall();
  convoyeur2.checkBall();
  convoyeur3.checkBall();
  convoyeur4.checkBall();
  convoyeur5.checkBall();
  window.requestAnimationFrame(drawCanvas);
}

var convoyeur5 = new convoyeur(100,300,600,20,null);
convoyeur5.draw();

var convoyeur4 = new convoyeur(500,200,300,20,convoyeur5);
convoyeur4.draw();

var convoyeur3 = new convoyeur(100,200,300,20,convoyeur4);
convoyeur3.draw();

var convoyeur2 = new convoyeur(500,100,300,20,convoyeur3);
convoyeur2.draw();

var convoyeur1 = new convoyeur(100,100,300,20,convoyeur2);
convoyeur1.draw();

var ball1 = new ball(convoyeur1.x,convoyeur1.y,3,0,10);
convoyeur1.addBall(ball1);

drawCanvas();