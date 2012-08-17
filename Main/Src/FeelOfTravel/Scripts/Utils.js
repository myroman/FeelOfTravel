function replaceSelection(elementRef, valueToInsert) {

  if (document.selection) {
    // Internet Explorer...
    elementRef.focus();
    var selectionRange = document.selection.createRange();
    selectionRange.text = valueToInsert;
  }
  else if ((elementRef.selectionStart) || (elementRef.selectionStart == '0')) {
    // Mozilla/Netscape...

    var startPos = elementRef.selectionStart;
    var endPos = elementRef.selectionEnd;
    elementRef.value = elementRef.value.substring(0, startPos) +
   valueToInsert + elementRef.value.substring(endPos, elementRef.value.length);
  }
}

//check for IE
function wrapSelection(elementRef, startTag, endTag) {
  if (document.selection) {
    // Internet Explorer...
    elementRef.focus();
    var selectionRange = document.selection.createRange();
    selectionRange.text = valueToInsert;
  } else if ((elementRef.selectionStart) || (elementRef.selectionStart == '0')) {
    // Mozilla/Netscape...

    var startPos = elementRef.selectionStart;
    var endPos = elementRef.selectionEnd;
    var selection = elementRef.value.substring(startPos, endPos);

    elementRef.value = elementRef.value.substring(0, startPos) +
      startTag + selection + endTag +
        elementRef.value.substring(endPos, elementRef.value.length);
  }
}

function insertImageTag(textBoxId, fileName) {
  var reportLabel = document.getElementById(textBoxId);
  replaceSelection(reportLabel, '<img src="' + getUploadedImagesDir() + fileName + '" width="200px" />');
}

function getUploadedImagesDir() {
  return getRoot() + 'UploadedImages/';
}

function getRoot() {
  return location.protocol + '//' + location.host + '/';
}

function confirmDelete(message) {
  if (confirm(message) == true)
    return true;
  else return false;
}

function linkImageFile(imageId, fileName) {
  var image = document.getElementById(imageId);
  image.src = getUploadedImagesDir() + 'Offers/' + fileName;
}

// Effects
function showTooltip(elem) {
  var tooltip = $("<div id='tooltip' class='tooltip'>I'm the tooltip!</div>");
  tooltip.appendTo($(elem));
}

function hideTooltip(tooltipTimeout) {
  clearTimeout(tooltipTimeout);
  $("#tooltip").fadeOut().remove();
} 