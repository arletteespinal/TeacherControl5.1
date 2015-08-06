// JavaScript Document
$(function(){
	$(".titulo-acordeon").click(function(e){
		e.preventDefault();
		var contenido = $(this).next(".contenido-acordeon");
		if(contenido.css("display")=="none"){//abrir
			contenido.slideDown(250);
			$(this).addClass("open");
		}
		else{//close
			contenido.slideUp(250);
			$(this).removeClass("open");
		}
	});
});