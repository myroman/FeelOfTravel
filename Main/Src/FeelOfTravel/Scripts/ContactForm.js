function initialize() {
  initializeContactForm();
}

function initializeContactForm() {
  if (document.URL.indexOf("About.aspx") > 0) {
    showMap();
    showMail();
  }

}
function showMap() {
  if (GBrowserIsCompatible()) {

    var x = 59.738904;
    var y = 30.612588;
    var marker = new GLatLng(x, y);
    //show map
    var mapContainer = $('.about-contacts-map').get(0);
    var map = new GMap2(mapContainer);
    map.setCenter(marker, 14);
    map.setUIToDefault();

    //    //set marker
    map.addOverlay(new GMarker(marker));
  }
}


function showMail() {

  var login = 'turizmu_da';
  var server = 'mail.ru';
  var email = login + '@' + server;
  var url = 'mailto:' + email;
  var phMail = $('.about-contacts-mail');
  if (phMail != null)
    phMail.innerHTML = 'e-mail: <a href="' + url + '">' + email + '</a>';

}