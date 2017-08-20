import React, { Component } from 'react';
import moment from 'moment';

import Aspect from './Aspect';

import { Grid, Row, Col, Label } from 'react-bootstrap';
import './App.css';

class Review extends Component {
  render(){

    let review =
    {
      parents: [{id:'' }],
      id:'',
      traveledWith:'',
      entryDate:'',
      travelDate:'',
      ratings:{
        general: {
          general:''
        }
      },
      aspects: { location: '' , service: '', priceQuality: '', food: '', room: '', childFriendly: '', interior: '', size: '', activities: '', restaurants: '', sanitaryState: '', accessibility: '', nightlife: '', culture:'',
      surrounding: '', atmosphere: '', noviceSkiArea: '', advancedSkiArea: '',  apresSki: '', beach: '', entertainment: '', environmental: '', pool: '', terrace: '' },
      titles:{
        nl:''
      },
      texts:{
        nl:''
      },
      user:'',
      locale:''
    };

    review = this.props.review !== null ?this.props.review: review;

    return (
      <Grid className="review">
        <Row>
          <Col xs={1} md={1} >
            <div className="rating-block-review center">
              <h3 className="bold padding-bottom-7">{review.ratings.general.general}</h3>
              <h5><Label bsStyle="primary">{review.traveledWith}</Label></h5>
            </div>
          </Col>
          <Col xs={8} md={10}>
            <Row>
              <Col>
                <h4>{review.titles.en ||
                  review.titles.it ||
                  review.titles.de ||
                  review.titles.es ||
                  review.titles.nl ||
                  review.titles['nl-be'] ||
                  review.titles.dk ||
                  review.titles.fr ||
                  review.titles.se ||
                  review.titles.pl ||
                  review.titles.ru ||
                  review.titles.no ||
                  review.titles.cz ||
                  review.titles['fr-be']
                }</h4>
              </Col>
            </Row>
            <Row>
              <Col>
                <h5>{review.user}, { moment(review.entryDate).format('Do MMMM YYYY')}</h5>
              </Col>
            </Row>
          </Col>
        </Row>
        <Row>
          <Col xs={12} md={12}>
            <h4>Aspects ratings</h4>
            <Row>
              {
                Object.entries(review.ratings.aspects).map((type, k) => {
                  return (
                    <Col key={k} xs={4} md={2}>
                      <Aspect
                        aspect = {type}
                      />
                    </Col>
                  )
                })
              }
            </Row>
          </Col>
        </Row>
        <Row>
          <Col xs={12} md={12}>
            <br/>
            <h4>Review</h4>
            {review.texts.en ||
              review.texts.it ||
              review.texts.de ||
              review.texts.es ||
              review.texts.nl ||
              review.texts['nl-be'] ||
              review.texts.dk ||
              review.texts.fr ||
              review.texts.se ||
              review.texts.pl ||
              review.texts.ru ||
              review.texts.no ||
              review.texts.cz ||
              review.texts['fr-be']
            }
          </Col>
        </Row>
        <Row>
          <Col xs={8} md={12}>
            <h5>Traveled, { moment(review.travelDate).format('Do MMMM YYYY')}</h5>
          </Col>
        </Row>
      </Grid>
    )
  }
}

export default Review;
