import React, { Component } from 'react';
import { Label } from 'react-bootstrap';
import './App.css';

class Aspect extends Component {
  render(){

    let aspect = [];
    aspect = (this.props.aspect !== undefined && this.props.aspect !== null) ? this.props.aspect : aspect;

    return (
      <div>
            {aspect[0]} :&nbsp;
            <Label
              bsStyle=
              {
                parseFloat(aspect[1])>8 ? 'success' :
                  ( parseFloat(aspect[1]) > 5 ? 'primary' :
                    (parseFloat(aspect[1]) > 3 ? 'warning' : 'danger'))
              }
              className="pull-right">
               {aspect[1]}
            </Label>
      </div>
    )
  }
}

export default Aspect;
