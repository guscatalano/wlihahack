// See post: http://asmaloney.com/2014/01/code/creating-an-interactive-map-with-leaflet-and-openstreetmap/

//var map = L.map( 'map', {
//  center: [47, -121],
//  minZoom: 2,
//  zoom: 6
//})

var corner1 = L.latLng(45.541111, -124.111031),
corner2 = L.latLng(49.113552, -116.882027),
bounds = L.latLngBounds(corner2, corner1);

var map = L.map('map').setView([47.4062, -119.8321], 7);


// L.tileLayer( 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//   attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
//   subdomains: ['a', 'b', 'c']
// }).addTo( map )


// var positron = L.tileLayer('https://{s}.basemaps.cartocdn.com/light_nolabels/{z}/{x}/{y}.png', {
//         attribution: 'Â©OpenStreetMap, Â©CartoDB'
// }).addTo(map);

var mapboxAccessToken = 'pk.eyJ1Ijoid2xpaGEiLCJhIjoiY2p5ODlxNGllMDZsbjNjcndiNXd4cTl3aSJ9.0WA_GXV_CocrFGP-hWdPcQ';

L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=' + mapboxAccessToken, {
    id: 'mapbox.light',
    attribution: 'Â©OpenStreetMap, Â©CartoDB'
}).addTo(map);


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
    this._div.innerHTML = '<div>' + 'People Affected: ' + props.peopleAffected +'</div>' + '<div>' +'Address: ' + props.address + '</div>';
};

info.addTo(map);

var tempHttp;
var evictionInfo;
const Http = new XMLHttpRequest();
const url='http://neighborevictions.azurewebsites.net/api/Eviction';
Http.open("GET", url);
Http.send();

Http.onload = function() {
  console.log(Http.responseText)
  var evictionInfo = JSON.parse(Http.responseText);

  addressPoints = evictionInfo.map(function (p) { return [p.addressInfo.latitude, p.addressInfo.longitude]; });
  var heat = L.heatLayer(addressPoints, {radius: 50, blur: 15, gradient: {0.0: 'blue', 1: 'purple'}}).addTo(map);

  addressPoints = evictionInfo.map(function (p) { 
    L.marker( [p.addressInfo.latitude,
                p.addressInfo.longitude],
                {icon: myIcon, title: p.numberOfPpl, alt: p.addressInfo.streetAddress } )
    .on('click', function(e) { info.update({peopleAffected: e.target.options.title, address: e.target.options.alt}) })
    .addTo( map );
  });

  // for ( var i=0; i < addressPoints.length; ++i )
  // {
  //   L.marker( [markers[i].lat, markers[i].lng], {icon: myIcon, title: markers[i].name, alt: markers[i].url } )
  //   .on('click', function(e) { info.update({name: e.target.options.title, address: e.target.options.alt}) })
  //   .addTo( map );
  // }

}

  

// washington state outline data 
var statesData = {"type":"FeatureCollection","features":[{"type":"Feature","id":"53","properties":{"name":"Washington","density":102.6},"geometry":{"type":"MultiPolygon","coordinates":[[[[-117.033359,49.000239],[-117.044313,47.762451],[-117.038836,46.426077],[-117.055267,46.343923],[-116.92382,46.168661],[-116.918344,45.993399],[-118.988627,45.998876],[-119.125551,45.933153],[-119.525367,45.911245],[-119.963522,45.823614],[-120.209985,45.725029],[-120.505739,45.697644],[-120.637186,45.746937],[-121.18488,45.604536],[-121.217742,45.670259],[-121.535404,45.725029],[-121.809251,45.708598],[-122.247407,45.549767],[-122.762239,45.659305],[-122.811531,45.960537],[-122.904639,46.08103],[-123.11824,46.185092],[-123.211348,46.174138],[-123.370179,46.146753],[-123.545441,46.261769],[-123.72618,46.300108],[-123.874058,46.239861],[-124.065751,46.327492],[-124.027412,46.464416],[-123.895966,46.535616],[-124.098612,46.74374],[-124.235536,47.285957],[-124.31769,47.357157],[-124.427229,47.740543],[-124.624399,47.88842],[-124.706553,48.184175],[-124.597014,48.381345],[-124.394367,48.288237],[-123.983597,48.162267],[-123.704273,48.167744],[-123.424949,48.118452],[-123.162056,48.167744],[-123.036086,48.080113],[-122.800578,48.08559],[-122.636269,47.866512],[-122.515777,47.882943],[-122.493869,47.587189],[-122.422669,47.318818],[-122.324084,47.346203],[-122.422669,47.576235],[-122.395284,47.800789],[-122.230976,48.030821],[-122.362422,48.123929],[-122.373376,48.288237],[-122.471961,48.468976],[-122.422669,48.600422],[-122.488392,48.753777],[-122.647223,48.775685],[-122.795101,48.8907],[-122.756762,49.000239],[-117.033359,49.000239]]],[[[-122.718423,48.310145],[-122.586977,48.35396],[-122.608885,48.151313],[-122.767716,48.227991],[-122.718423,48.310145]]],[[[-123.025132,48.583992],[-122.915593,48.715438],[-122.767716,48.556607],[-122.811531,48.419683],[-123.041563,48.458022],[-123.025132,48.583992]]]]}}]};

//click listener that zooms to state
var geojson;
function zoomToFeature(e) {
    map.fitBounds(e.target.getBounds());
}

function onEachFeature(feature, layer) {
    layer.on({
        // mouseover: highlightFeature,
        // mouseout: resetHighlight,
        click: zoomToFeature
    });
}

function style(feature) {
    return {
        fillColor: '#F1592A',
        weight: 2,
        opacity: 1,
        color: '#D71A21',
        dashArray: '3',
        fillOpacity: 0.05
    };
}

geojson = L.geoJson(statesData, {
    style: style,
    onEachFeature: onEachFeature
}).addTo(map);

// function highlightFeature(e) {
//     var layer = e.target;

//     layer.setStyle({
//         weight: 5,
//         color: '#666',
//         dashArray: '',
//         fillOpacity: 0.7
//     });

//     if (!L.Browser.ie && !L.Browser.opera && !L.Browser.edge) {
//         layer.bringToFront();
//     }
// }

// function resetHighlight(e) {
//     geojson.resetStyle(e.target);
// }