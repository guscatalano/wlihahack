// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

var map = L.map( 'map', {
  center: [47, -121],
  minZoom: 2,
  zoom: 6
})

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

var info = L.control();

info.onAdd = function (map) {
    this._div = L.DomUtil.create('div', 'info'); // create a div with a class "info"
    this._div.style.width= "200px";
    this._div.style.height= "200px";
    this.update({name: "s1", address: "a1"});
    return this._div;
};

// method that we will use to update the control based on feature properties passed
info.update = function (props) {
    this._div.innerHTML = '<p>' + 'Name: ' + props.name + 'Address: ' + props.address + '</p>';
};

info.addTo(map);

for ( var i=0; i < markers.length; ++i )
{
  console.log(markers[i].name)
  console.log(markers[i].url)
 L.marker( [markers[i].lat, markers[i].lng], {icon: myIcon, title: markers[i].name, alt: markers[i].url } )
  .on('click', function(e) { info.update({name: e.target.options.title, address: e.target.options.alt}) })
  .addTo( map );
}


