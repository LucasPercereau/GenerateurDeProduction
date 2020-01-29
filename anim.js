var canvas = document.getElementById('test');
var ctx = canvas.getContext('2d');
var raf;
var tabConvoyeur = [];
var tabStock = [];
var tabMachine = [];

function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  
  tabStock.forEach(element => element.draw());

  tabConvoyeur.forEach(element => element.draw());
  tabConvoyeur.forEach(element => element.drawAllBall());
  tabConvoyeur.forEach(element => element.avance());
  tabConvoyeur.forEach(element => element.checkBall());

  tabMachine.forEach(element => element.draw());

  window.requestAnimationFrame(drawCanvas);
}

function addBall() {
  tabConvoyeur[0].addBall(new ball(tabConvoyeur[0].x,tabConvoyeur[0].y,3,0,10));
}
