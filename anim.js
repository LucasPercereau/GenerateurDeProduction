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
var tabElem=[];

function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  
  tabElem.forEach(element => element.forEach(element => element.draw()));

  window.requestAnimationFrame(drawCanvas);
}