require('rootpath')();
var express = require('express'); 
var path = require('path');
var cookieParser = require('cookie-parser');
var bodyParser = require('body-parser');
var consign = require('consign');
var cors = require('cors');
var http = require("http");

var app = express();

app.use(cookieParser());

app.use(cors());
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));


app.use(require('stylus').middleware(path.join(__dirname, 'client')));
app.use(express.static(path.join(__dirname, 'client')));

 
consign()
  .include('app/controllers')
  .then('app/routes')
  .then('config')
  .into(app);


http.createServer(app).listen(app.config.index.port, function () {
    
    console.log('Express server listening on port ' + app.config.index.port +' mode: ' + process.env.NODE_ENV);
});


module.exports = app;
