$(function() {
	$("table").tablesorter();
	
	//===== Resizable columns =====//
	
	$("#resize, #resize2").colResizable({
		liveDrag:true,
		draggingClass:"dragging" 
	});

	//===== Dynamic data table =====//
	
	oTable = $('.dTable').dataTable({
		"bJQueryUI": false,
		"bAutoWidth": false,
		"sPaginationType": "full_numbers",
		"sDom": '<"H"fl>t<"F"ip>'
	});
	
	//===== Dynamic table toolbars =====//		
	$('#dyn .tOptions').click(function () {
		$('#dyn .tablePars').slideToggle(200);
	});	
	
	$('#dyn2 .tOptions').click(function () {
		$('#dyn2 .tablePars').slideToggle(200);
	});	
	
	$('.tOptions').click(function () {
		$(this).toggleClass("act");
	});
	
	//===== Form elements styling =====//
	$("select, .check, .check :checkbox, input:radio, input:file").uniform();
});

	
