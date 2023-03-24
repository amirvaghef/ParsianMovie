function getScreenWidth() {
	var result = 2000;

	if (window.innerWidth) {
		// all except Explorer
		result = parseInt(window.innerWidth);
	} else if (document.documentElement && document.documentElement.clientWidth) {
		// Explorer 6 Strict Mode
		result = parseInt(document.documentElement.clientWidth);
	} else if (document.body) {
		// other Explorers
		result = parseInt(document.body.clientWidth);
	}
	if (isNaN(result)) {
		result = 2000;
	}
	return result;
}

function getScreenHeight() {
	var result = 2000;

	if (window.innerHeight) {
		// all except Explorer
		result = parseInt(window.innerHeight);
	} else if (document.documentElement && document.documentElement.clientHeight) {
		// Explorer 6 Strict Mode
		result = parseInt(document.documentElement.clientHeight);
	} else if (document.body) {
		// other Explorers
		result = parseInt(document.body.clientHeight);
	}
	if (isNaN(result)) {
		result = 2000;
	}
	return result;
}

function getScreenOffsetX() {
	var result = 2000;

	if (window.pageXOffset) {
		// all except Explorer
		result = parseInt(window.pageXOffset);
	} else if (document.documentElement && document.documentElement.scrollLeft) {
		// Explorer 6 Strict Mode
		result = parseInt(document.documentElement.scrollLeft);
	} else if (document.body) {
		// other Explorers
		result = parseInt(document.body.scrollLeft);
	}
	if (isNaN(result)) {
		result = 2000;
	}
	return result;
}

function getScreenOffsetY() {
	var result = 2000;

	if (window.innerHeight) {
		// all except Explorer
		result = parseInt(window.pageYOffset);
	} else if (document.documentElement && document.documentElement.scrollTop) {
		// Explorer 6 Strict Mode
		result = parseInt(document.documentElement.scrollTop);
	} else if (document.body) {
		// other Explorers
		result = parseInt(document.body.scrollTop);
	}
	if (isNaN(result)) {
		result = 2000;
	}
	return result;
}
function TogglePreloader(fl) {
	var x,y;
	x = getScreenWidth();
	y = getScreenHeight();
	var iframe=document.getElementById('preloader_iframe');
	var table=document.getElementById('preloader_table');
	var td=document.getElementById('preloader_td');
	var el=document.getElementById('div_desktop');
	if(null!=el) {
		el.style.visibility = (fl==1)?'visible':'hidden';
		el.style.display = (fl==1)?'block':'none';
		el.style.width = x + "px";
		el.style.height = y + "px";
		el.style.zIndex = 1;
	}

	var el=document.getElementById('loader');
	if(null!=el) {
		var top = (y/2) - 50;
		var left = (x/2) - 200;
		if( left<=0 ) left = 10;
		td.style.width = (getScreenWidth() + getScreenOffsetX()) + "px";
		td.style.height = (getScreenHeight() + getScreenOffsetY()) + "px";
		top += getScreenOffsetY();
		left += getScreenOffsetX(); 
		table.style.display=(fl==1)?'block':'none';
		iframe.style.left = left + "px";
		iframe.style.top = top + "px";
		iframe.style.display=(fl==1)?'block':'none';
		el.style.visibility = (fl==1)?'visible':'hidden';
		el.style.display = (fl==1)?'block':'none';
		el.style.left = left + "px"
		el.style.top = top + "px";
	}
}