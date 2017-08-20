import React, { Component } from 'react';
import Aspect from './Aspect';
import Group from './Group';

import { Grid, Row, Col } from 'react-bootstrap';
import './App.css';

class Summary extends Component {
  render(){
    let geral_ratings =
    {
      total: '',
      general: '',
        aspects: { location: '' , service: '', priceQuality: '', food: '', room: '', childFriendly: '', interior: '', size: '', activities: '', restaurants: '', sanitaryState: '', accessibility: '', nightlife: '', culture:'',
        surrounding: '', atmosphere: '', noviceSkiArea: '', advancedSkiArea: '', apresSki: '', beach: '', entertainment: '', environmental: '', pool: '', terrace: ''},
        traveledWithRate: []
    }
    geral_ratings = this.props.geral_ratings !== null ? this.props.geral_ratings: geral_ratings;


    return (
      <Grid>
        <Row>
          <Col xs={2} md={2}>
            <div className="rating-block rating-block-padding center">
              <h4>Average rating</h4>
              <h2 className="bold padding-bottom">{geral_ratings.general} <small>/ 10</small></h2>
              <h5>{geral_ratings.total} reviews</h5>
            </div>

          </Col>
          <Col xs={8} md={10}>
            <Row>
              <Col>
                <h4>Aspects ratings</h4>
                <Row>
                  {
                    Object.entries(geral_ratings.aspects).map((type, k) => {
                      return (
                          <Col key={k} xs={4} md={3}>
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
              <Col>
                <h4>Group Type ratings</h4>
                <Row>
                  {
                    geral_ratings.traveledWithRate.map((type, k) => {
                      return (
                        <Col key={k} xs={3} md={2}>
                          <Group
                            group = {type}
                           />
                        </Col>
                      )
                    })
                  }
                </Row>
              </Col>
            </Row>
          </Col>
        </Row>
        <Row>
          <hr/>
        </Row>
      </Grid>
    )
  }
}

export default Summary;
