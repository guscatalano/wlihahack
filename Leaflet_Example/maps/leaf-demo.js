// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

//var map = L.map( 'map', {
//  center: [47, -121],
//  minZoom: 2,
//  zoom: 6
//})

var map = L.map('map').setView([47, -121], 6);


L.tileLayer( 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
  attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
  subdomains: ['a', 'b', 'c']
}).addTo( map )

var myURL = jQuery( 'script[src$="leaf-demo.js"]' ).attr( 'src' ).replace( 'leaf-demo.js', '' )

var myIcon = L.icon({
  iconUrl: myURL + 'images/pin24.png',
  iconRetinaUrl: myURL + 'images/pin48.png',
  iconSize: [29, 24],
  iconAnchor: [9, 21],
  popupAnchor: [0, -14]
})

for ( var i=0; i < markers.length; ++i )
{
 L.marker( [markers[i].lat, markers[i].lng], {icon: myIcon} )
  .bindPopup( '<a href="' + markers[i].url + '" target="_blank">' + markers[i].name + '</a>' )
  .addTo( map );
}

var addressPoints = [
  [47.457436,	-121.858749, 1],
  [45.590374,	-122.576965, 1],
  [45.695595,	-122.49395, 1],
  [47.561943,	-122.206146, 1],
  [46.733456,	-120.412842, 1],
  [47.6347503662109,	-122.136993408203, 1]
];

addressPoints = addressPoints.map(function (p) { return [p[0], p[1]]; });

var heat = L.heatLayer(addressPoints).addTo(map);