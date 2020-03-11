var canvas = document.getElementById('test');
var ctx = canvas.getContext('2d');
var raf;
var tabConvoyeur = [];
var tabStock = [];
var tabMachine = [];
var tabArriveeManuelle = [];
var tabArriveePredefinie = [];
var tabMatch = [];
var tabBatch = [];
var tabUnBatch = [];
var tabRouter = [];
var tabMux = [];
var tabMerge = [];
var tabFeu = [];
var tabElem=[];
var json="";
let framesPerSecond = 60;

var pause=false;
var stop = false;
var frameCount = 0;
var fps, fpsInterval, startTime, now, then, elapsed;

///////////////////////////////
//////////PROGRAMME////////////
///////////////////////////////
Json.onchange = readJSON;

function _(id) { return document.getElementById(id);}


function difference(a, b){
	return Math.abs(a - b);
}
function readJSON()
{
  var file = _("Json").files[0];
  if(!file)
    return;

  file.text().then(function(val){ init(val);});
}
function init(val)
{
  json = val; 
  json = JSON.parse(json);
  
  _("Loading").style.display = "none";
   
  GenerateFromJson(); 
}

function GenerateFromJson(){ 
	json.forEach(function(value){
		const name = value.name;
		switch (name) {
		case 'ArriveeManuelle':
			tabArriveeManuelle[tabArriveeManuelle.length]=new ArriveeManuelle(value.id,value.X,value.Y,"tabArriveeManuelle["+tabArriveeManuelle.length+"]",null,1);
			break;
		case 'ArriveePredefinie':
			tabArriveePredefinie[tabArriveePredefinie.length]=new ArriveePredefinie(value.id,value.X,value.Y,"tabArriveePredefinie["+tabArriveePredefinie.length+"]",[2,2,2,2],null,1);
			break;
		case 'Machine':
			tabMachine[tabMachine.length]=new Machine(value.id,value.X,value.Y,value.taille,null,1); 
			break;
		case 'Match':
			tabMatch[tabMatch.length]=new Match(value.id,value.X,value.Y,null,1); 
			break;
		case 'Batch':
			tabBatch[tabBatch.length]=new Batch(value.id,value.X,value.Y,value.tailleLot,null,1); 
			break;
		case 'Unbatch':
			tabUnBatch[tabUnBatch.length]=new UnBatch(value.id,value.X,value.Y,value.tailleLot,null,1); 
			break;
		case 'Router':
			tabRouter[tabRouter.length]=new Router(value.id,value.X,value.Y,[1,0,1,1],null,null,1); 
			break;
		case 'Mux':
			tabMux[tabMux.length]=new Mux(value.id,value.X,value.Y,[0,0,0],null,1); 
			break;
		case 'Merge':
			tabMerge[tabMerge.length]=new Merge(value.id,value.X,value.Y,null,1); 
			break;
		case 'Feu':
			tabFeu[tabFeu.length]=new Feu(value.id,value.X,value.Y,2000,3000,null,1); 
			break;
		case 'Convoyeur':
			tabConvoyeur[tabConvoyeur.length]=new Convoyeur(value.id,value.X,value.Y,value.segments,7,null,1);
			 
			break;	
		case 'WTEG':
			break;
		case 'liaison':
			if(tabElem.length===0)
			{tabElem.push(tabConvoyeur,tabStock,tabMux,tabRouter,tabUnBatch,tabArriveeManuelle,tabArriveePredefinie,tabRouter,tabMachine,tabMerge,tabBatch,tabFeu);}
			var ElementProv1 =null;
			var ElementProv2 =null;
			tabElem.forEach(element => element.forEach(function(element){if (element.ID===value.element1){ElementProv1=element} }   ));
			tabElem.forEach(element => element.forEach(function(element){if (element.ID===value.element2){ElementProv2=element} }   ));

			ElementProv1.SetSuiv(ElementProv2,value.element1Id);
			if(value.element2Id!=1)
			{
				ElementProv1.SetLinkId(value.element2Id);
			}		
			break;
		default:
			break;
	}
	});
	
	fpsInterval = 1000 / 60;
    then = Date.now();
    startTime = then;

	drawCanvas();
}
///////////////////////////////

function drawCanvas() {
 
  	window.requestAnimationFrame(drawCanvas);

  	now = Date.now();
    elapsed = now - then;

    if (elapsed > fpsInterval && !pause) {
        then = now - (elapsed % fpsInterval);

        ctx.clearRect(0,0, canvas.width, canvas.height);
  		tabElem.forEach(element => element.forEach(element => element.draw()));
    }
}