// JScript File
var ns4 = document.layers;

var ns6 = document.getElementById && !document.all;

var ie4 = document.all;

offsetX = 10;

offsetY = 5;

var toolTipSTYLE="";

function initToolTips()

{


    if(ns4) toolTipSTYLE = document.toolTipLayer;

    else if(ns6) toolTipSTYLE = document.getElementById("toolTipLayer").style;

    else if(ie4) toolTipSTYLE = document.all.toolTipLayer.style;
	else  toolTipSTYLE = document.getElementById("toolTipLayer").style;

    if(ns4) document.captureEvents(Event.MOUSEMOVE);

    else

    {

      toolTipSTYLE.visibility = "visible";

      toolTipSTYLE.display = "none";

    }

    document.onmousemove = moveToMouseLoc;

  
}

function toolTip(msg, width)

{

  if(toolTip.arguments.length < 1) // hide

  {

    if(ns4) toolTipSTYLE.visibility = "hidden";

    else toolTipSTYLE.display = "none";

  }

  else // show

  {
    var content =

'<table style="line-height: normal;" width="'+width+'" border="0" cellspacing="0" cellpadding="0">'+
  '<tr>'+
    '<td ><img src="images/Tooltip_Box_TopLeftCorner.gif" width="6" height="6" /></td>'+
    '<td class="TooltipTop">&nbsp\;</td>'+
    '<td><img src="images/Tooltip_Box_TopRightCorner.gif" width="6" height="6" /></td>'+
  '</tr>'+
  '<tr>'+
    '<td class="TooltipLeft">&nbsp\;</td>'+
    '<td width="100%" class="TooltipMiddle" dir="rtl">' + msg +
    '</td>'+
    '<td class="TooltipRight">&nbsp\;</td>'+
  '</tr>'+
  '<tr>'+
    '<td><img src="images/Tooltip_Box_BottomLeftCorne.gif" width="6" height="6" /></td>'+
    '<td class="TooltipBottom">&nbsp\;</td>'+
    '<td><img src="images/Tooltip_Box_BottomRightCorn.gif" width="6" height="6" /></td>'+
  '</tr>'+
'</table>';

    if(ns4)

    {

      toolTipSTYLE.document.write(content);

      toolTipSTYLE.document.close();

      toolTipSTYLE.visibility = "visible";

    } else

    if(ns6)

    {

      document.getElementById("toolTipLayer").innerHTML = content;

      toolTipSTYLE.display='block'

    } else
	

    if(ie4)

    {

      document.all("toolTipLayer").innerHTML=content;

      toolTipSTYLE.display='block'

    }
else
{

      document.getElementById("toolTipLayer").innerHTML = content;

      toolTipSTYLE.display='block'

    }

  }
}

function moveToMouseLoc(e)

{

var evt = e ? e:window.event;
 var clickX=0, clickY=0;

if ((evt.clientX || evt.clientY) &&
     document.compatMode=='CSS1Compat' && 
     document.documentElement && 
     document.documentElement.scrollLeft!=null) {
  clickX = evt.clientX + document.documentElement.scrollLeft;
  clickY = evt.clientY + document.documentElement.scrollTop;
 } else
 if ((evt.clientX || evt.clientY) &&
     document.body &&
     document.body.scrollLeft!=null) {
  clickX = evt.clientX + document.body.scrollLeft;
  clickY = evt.clientY + document.body.scrollTop;
 } else
 
 if (evt.pageX || evt.pageY) {
  clickX = evt.pageX;
  clickY = evt.pageY;
 } else
if( evt.screenX || evt.screenY)
{
  clickX = evt.screenX;
  clickY = evt.screenY;
}

   

  toolTipSTYLE.left = clickX + offsetX + "px";

  toolTipSTYLE.top = clickY + offsetY + "px";


  
  return true;
}
