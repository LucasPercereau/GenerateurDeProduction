var canvas = document.getElementById('test');
var ctx = canvas.getContext('2d');
var raf;
var tabConvoyeur = [];
var tabStock = [];
var tabMachine = [];
var tabArriveeManuelle = [];
var tabMatch = [];
var tabBatch = [];
var tabUnBatch = [];
var tabRouter = [];
var tabMux = [];
var tabMerge = [];
var tabFeu = [];

function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  
  tabStock.forEach(element => element.draw());

  tabConvoyeur.forEach(element => element.draw());
  tabConvoyeur.forEach(element => element.drawAllBall());
  tabConvoyeur.forEach(element => element.avance());
  tabConvoyeur.forEach(element => element.checkBall());

  tabMachine.forEach(element => element.draw());
  tabMachine.forEach(element => element.checkStock());

  tabArriveeManuelle.forEach(element => element.draw());

  tabMatch.forEach(element => element.draw());
  tabMatch.forEach(element => element.check());

  tabBatch.forEach(element => element.draw());
  tabUnBatch.forEach(element => element.draw());

  tabRouter.forEach(element => element.draw());
  tabMux.forEach(element => element.draw());

  tabMerge.forEach(element => element.draw());
  tabFeu.forEach(element => element.draw());

  window.requestAnimationFrame(drawCanvas);
}