'use strict';
var reviews = require('db/reviews.json');
var _ = require('lodash');
var moment = require('moment');


//?sort= 
//travel_date_asc / travel_date_desc
//review_date_asc / review_date_desc

//?traveled_with=
//ALL
//FAMILY
//FRIENDS
//OTHER
//COUPLE
//SINGLE

exports.getAll = function (req, callback) {
	
	var auxReviews = reviews;
	
	_.forEach(req.query, function(value, key) {
		switch (key) {
			case 'sort':
			var sortKey = value.split('_');
			
			if(sortKey !== undefined && sortKey !== null && sortKey.length === 3) {
				if(sortKey[0]==='travel')
					auxReviews = _.orderBy(auxReviews, ['travelDate'],[sortKey[2]]);
				
				if(sortKey[0]==='review')
					auxReviews = _.orderBy(auxReviews, ['entryDate'], [sortKey[2]]);
			}
			
			break;
			
			case 'traveled_with':
			
			if(value.toUpperCase().trim() !=='ALL'){
				auxReviews = _.filter(auxReviews, { 'traveledWith': value.toUpperCase().trim() });
			}
			
			break;
			default:
			break;
		}
	});
	
	callback({
		status: 200,
		res: auxReviews
	});
};

exports.getAllTraveledWith = function(req, callback) {
	callback({
		status: 200,
		res: getUnique(reviews, 'traveledWith')
	});
};

exports.getAcomodationRatings = function(req, callback) {
	var traveledWithSum = initTravelWithRate();
	
	var generalRate = 0, locationRate = 0, serviceRate = 0, priceQualityRate = 0, foodRate = 0, 
	roomRate = 0, childFriendlyRate = 0, interiorRate = 0, sizeRate = 0, activitiesRate = 0, 
	restaurantsRate = 0, sanitaryStateRate = 0, accessibilityRate = 0, nightlifeRate = 0, 
	cultureRate = 0, surroundingRate = 0, atmosphereRate = 0, noviceSkiAreaRate = 0, 
	advancedSkiAreaRate = 0, apresSkiRate = 0, beachRate = 0, entertainmentRate = 0, 
	environmentalRate = 0, poolRate = 0, terraceRate = 0, count  = 0;
	
	for (var i = 0, ii = reviews.length; i < ii; ++i) {
		var review = reviews[i];
		
		var weight = getWeight(review.entryDate);
		
		generalRate+=(review.ratings.general.general*weight);
		locationRate += (review.ratings.aspects.location*weight);
		serviceRate += (review.ratings.aspects.service*weight);
		priceQualityRate += (review.ratings.aspects.priceQuality*weight);
		foodRate += (review.ratings.aspects.food*weight);
		roomRate += (review.ratings.aspects.room*weight);
		childFriendlyRate += (review.ratings.aspects.childFriendly*weight);
		interiorRate += (review.ratings.aspects.interior*weight);
		sizeRate += (review.ratings.aspects.size*weight);
		activitiesRate += (review.ratings.aspects.activities*weight);
		restaurantsRate += (review.ratings.aspects.restaurants*weight);
		sanitaryStateRate += (review.ratings.aspects.sanitaryState*weight);
		accessibilityRate += (review.ratings.aspects.accessibility*weight);
		nightlifeRate += (review.ratings.aspects.nightlife*weight);
		cultureRate += (review.ratings.aspects.culture*weight);
		surroundingRate += (review.ratings.aspects.surrounding*weight);
		atmosphereRate += (review.ratings.aspects.atmosphere*weight);
		noviceSkiAreaRate += (review.ratings.aspects.noviceSkiArea*weight);
		advancedSkiAreaRate += (review.ratings.aspects.advancedSkiArea*weight);
		apresSkiRate += (review.ratings.aspects.apresSki*weight);
		beachRate += (review.ratings.aspects.beach*weight);
		entertainmentRate += (review.ratings.aspects.entertainment*weight);
		environmentalRate += (review.ratings.aspects.environmental*weight);
		poolRate += (review.ratings.aspects.pool*weight);
		terraceRate += (review.ratings.aspects.terrace*weight);
		
		traveledWithSum[review.traveledWith].rate+=(review.ratings.general.general*weight);
		traveledWithSum[review.traveledWith].count++;
		
		count++;
	}

	var traveledWithRate = [];

	_.forEach(traveledWithSum, function(value, key) {
		var item = {
			type: key.toLowerCase(),
			generalRate: (value.rate / value.count).toFixed(1)
		};

		traveledWithRate.push(item);
	});


	
	var data = {
		total: count,
		general: (generalRate/count).toFixed(1),
		aspects:{
			location: (locationRate/count).toFixed(1),
			service: (serviceRate/count).toFixed(1),
			priceQuality: (priceQualityRate/count).toFixed(1),
			food: (foodRate/count).toFixed(1),
			room: (roomRate/count).toFixed(1),
			childFriendly: (childFriendlyRate/count).toFixed(1),
			interior: (interiorRate/count).toFixed(1),
			size: (sizeRate/count).toFixed(1),
			activities: (activitiesRate/count).toFixed(1),
			restaurants: (restaurantsRate/count).toFixed(1),
			sanitaryState: (sanitaryStateRate/count).toFixed(1),
			accessibility: (accessibilityRate/count).toFixed(1),
			nightlife: (nightlifeRate/count).toFixed(1),
			culture: (cultureRate/count).toFixed(1),
			surrounding: (surroundingRate/count).toFixed(1),
			atmosphere: (atmosphereRate/count).toFixed(1),
			noviceSkiArea: (noviceSkiAreaRate/count).toFixed(1),
			advancedSkiArea: (advancedSkiAreaRate/count).toFixed(1),
			apresSki: (apresSkiRate/count).toFixed(1),
			beach: (beachRate/count).toFixed(1),
			entertainment: (entertainmentRate/count).toFixed(1),
			environmental: (environmentalRate/count).toFixed(1),
			pool: (poolRate/count).toFixed(1),
			terrace: (terraceRate/count).toFixed(1)
		},
		traveledWithRate: traveledWithRate
	};

	
	callback({
		status: 200,
		res: data
	});
	
};

function getWeight(reviewDate) {
	
	var today = new Date();

	var diff = moment(today) - moment(reviewDate);
	var years = moment.duration(diff).years();
	if(years > 5)
		return 0.5;
	else
		return 1 - (years * 0.1);
}

function getUnique(value, key) {
	return _.uniq(_.map(value, key));
}

function initTravelWithRate() {
	var obj = getUnique(reviews, 'traveledWith');
	var json = {};
	for (var i in obj) {

		var key = obj[i];
		var js = { rate: 0 , count: 0 }
		json[key] = js;
		json[key] = js;
	}

	return json;
}






