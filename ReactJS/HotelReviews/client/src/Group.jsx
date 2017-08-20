import React, { Component } from 'react';
import { Label } from 'react-bootstrap';
import './App.css';

class Group extends Component {
  render(){
    let group = [];
    group = (this.props.group !== undefined && this.props.group !== null) ? this.props.group : group;

    return (
      <div>
        {group.type}:&nbsp;
        <Label bsStyle={
          parseFloat(group.generalRate)>8 ? 'success' :
            (parseFloat(group.generalRate) > 5 ? 'primary' :
              (parseFloat(group.generalRate) > 3 ? 'warning' : 'danger'))
        }>
          {
            group.generalRate
          }
      </Label>
      </div>
    )
  }
}

export default Group;
