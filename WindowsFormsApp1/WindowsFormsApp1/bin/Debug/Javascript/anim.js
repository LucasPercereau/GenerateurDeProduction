var canvas = document.getElementById('default');
var ctx = canvas.getContext('2d');
var raf;
var tabConvoyeur = [];
var tabStock = [];
var tabMachine = [];
var tabArriveeManuelle = [];
var tabRouter = [];
var json="";

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
			console.log("arrive manuelle");
			tabArriveeManuelle[tabArriveeManuelle.length]=new ArriveeManuelle(value.X,value.Y,"tabArriveeManuelle[tabArriveeManuelle.length]",null);
			break;
		case 'Machine':
			tabMachine[tabMachine.length]=new Machine(value.X,value.Y,value.buffer,value.taille,null); 
			break;
		case 'Match':
			break;
		case 'Batch':
			break;
		case 'Unbatch':
			break;
		case 'Router':
			break;
		case 'Mux':
			break;
		case 'Merge':
			break;
		case 'Feu':
			break;
		case 'WTEG':
			break;
		default:
			break;
	}
	});
	console.log(tabMachine);
	drawCanvas();
}



/*
function GenerateFromJson()
{
	if(json._nom === "Arrivee Manuelle1")
	{
		tabArriveeManuelle[tabArriveeManuelle.length] = new ArriveeManuelle(json.X1,json.Y1,"tabArriveeManuelle[0]",null);
		SkimJson(json.Sorties,tabArriveeManuelle[tabArriveeManuelle.length-1]);
	}
	
	console.log(tabMachine);
	console.log(tabConvoyeur);
	
	drawCanvas();
}


function SkimJson(sortie,entree){
	sortie.forEach(function(value){
		var nextEntree = AddRightMachine(value,entree);
		if(value.Sorties.length !== 0)
			this.SkimJson(value.Sorties,nextEntree);
	});
}


function AddRightMachine(value,entree){
	const name = value._nom;
	var retour;
	switch (name) {
		case 'Convoyeur':
			tabConvoyeur[tabConvoyeur.length]= new Convoyeur(value.X1,value.Y1,difference(value.X1,value.X2),difference(value.Y1,value.Y2),null); 
			retour = tabConvoyeur[tabConvoyeur.length-1];
			if(typeof entree !== 'undefined')
				entree.next(tabConvoyeur[tabConvoyeur.length-1]);
			break;
		case 'Machine':
			tabMachine[tabMachine.length]=new Machine(value.X1,value.Y1,10,null); 
			retour = tabMachine[tabMachine.length-1];
			if(typeof entree !== 'undefined')
				entree.next(tabMachine[tabMachine.length-1]);
			break;
		case 'Match':
			break;
		case 'Batch':
			break;
		case 'Unbatch':
			break;
		case 'Router':
			break;
		case 'Mux':
			break;
		case 'Merge':
			break;
		case 'Feu':
			break;
		case 'WTEG':
			break;
		default:
			break;
	}
	
	return retour;
	
}




loadJSON(function(response){
	monJSON= JSON.parse(response);
});



 function loadJSON(callback) {   

    var xobj = new XMLHttpRequest();
        xobj.overrideMimeType("application/json");
    xobj.open('GET', 'BONJOUR.json', true); 
    xobj.onreadystatechange = function () {
          if (xobj.readyState == 4 && xobj.status == "200") {
            callback(xobj.responseText);
          }
    };
    xobj.send(null);  
 }


function init(){
	if(typeof monJSON !== 'undefined'){
		draw();
	}
	else{
		setTimeout(init,250);
	}

}
*/



function drawCanvas() {
  ctx.clearRect(0,0, canvas.width, canvas.height);
  
  tabStock.forEach(element => element.draw());

  tabConvoyeur.forEach(element => element.draw());
  tabConvoyeur.forEach(element => element.drawAllBall());
  tabConvoyeur.forEach(element => element.avance());
  tabConvoyeur.forEach(element => element.checkBall());

  tabMachine.forEach(element => element.draw());
  tabMachine.forEach(element => element.checkStock());
  
  tabRouter.forEach(element => element.draw());

  tabArriveeManuelle.forEach(element => element.draw());

  window.requestAnimationFrame(drawCanvas);
}



