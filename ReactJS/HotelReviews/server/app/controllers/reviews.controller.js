'use strict';
var db = require("app/services/review.service.js");

exports.getAll = function (req, res) {
    db.getAll(req, function (result) {
        res.status(result.status)
            .json({
                status: result.status,
                data: result.res
            });
    });
};


exports.getAllTraveledWith = function (req, res) {
    db.getAllTraveledWith(req, function (result) {
        res.status(result.status)
            .json({
                status: result.status,
                data: result.res
            });
    });
};

exports.getAcomodationRatings = function (req, res) {
    db.getAcomodationRatings(req, function (result) {
        res.status(result.status)
            .json({
                status: result.status,
                data: result.res
            });
    });
};