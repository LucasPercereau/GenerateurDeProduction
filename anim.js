var canvas = document.getElementById('test');
var ctx = canvas.getContext('2d');
var raf;
var tabConvoyeur = [];
var tabStock = [];

function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  
  tabStock.forEach(element => element.draw());

  tabConvoyeur.forEach(element => element.draw());
  tabConvoyeur.forEach(element => element.drawAllBall());
  tabConvoyeur.forEach(element => element.avance());
  tabConvoyeur.forEach(element => element.checkBall());

  window.requestAnimationFrame(drawCanvas);
}

function addBall() {
  tabConvoyeur[0].addBall(new ball(tabConvoyeur[0].x,tabConvoyeur[0].y,3,0,10));
}

tabConvoyeur[4]= new convoyeur(100,300,600,20,null);
tabConvoyeur[3]= new convoyeur(500,200,300,20,tabConvoyeur[4]);
tabConvoyeur[2]= new convoyeur(100,200,300,20,tabConvoyeur[3]);
tabConvoyeur[1]= new convoyeur(500,100,300,20,tabConvoyeur[2]);

tabStock[1] = new stockage(460,70,5,tabConvoyeur[1]);
tabStock[0] = new stockage(420,70,5,tabStock[1]);

tabConvoyeur[0] = new convoyeur(100,100,300,20,tabStock[0]);

drawCanvas();