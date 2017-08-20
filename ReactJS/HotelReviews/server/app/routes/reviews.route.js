'use strict';
module.exports = function(server) {

	var review = server.app.controllers['reviews.controller'];

	server.get('/api/reviews/', review.getAll);
	server.get('/api/reviews/travel_with', review.getAllTraveledWith);
	server.get('/api/reviews/rating', review.getAcomodationRatings);

};