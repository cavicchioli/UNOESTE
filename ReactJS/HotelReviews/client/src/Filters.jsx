import React, { Component } from 'react';
import { ButtonToolbar, DropdownButton, MenuItem, Glyphicon} from 'react-bootstrap';
import './App.css';

class Filters extends Component {

  constructor(props){
    super(props);

    this.state = {
      travel_group: null,
      sort_by:'',
      filter_by:''
    }
  }

  componentWillMount() {
    this.getAllTravelWith();
  }

  getAllTravelWith(){
    const BASE_URL = 'http://localhost:4000/api/reviews/travel_with';
    var myOptions = {
      method: 'GET',
      mode: 'cors',
      cache: 'default'
    };

    fetch(BASE_URL, myOptions )
    .then(response => response.json())
    .then(json => {
      const travel_group = json.data;
      this.setState({travel_group});
    })
  }

  sort(sort_by){
    this.setState({sort_by});

    const BASE_URL = 'http://localhost:4000/api/reviews';
    let FETCH_URL='';
    if(this.state.filter_by!==''){
      FETCH_URL = `${BASE_URL}?traveled_with=${this.state.filter_by}&sort=${sort_by}`;
    }
    else {
      FETCH_URL = `${BASE_URL}?sort=${sort_by}`;
    }

    var myOptions = {
      method: 'GET',
      mode: 'cors',
      cache: 'default'
    };

    fetch(FETCH_URL, myOptions )
    .then(response => response.json())
    .then(json => {
      const reviews = json.data;
      
    })
  }

  filter(filter_by){
    this.setState({filter_by});

    const BASE_URL = 'http://localhost:4000/api/reviews';
    let FETCH_URL='';
    if(this.state.sort_by!==''){
      FETCH_URL = `${BASE_URL}?traveled_with=${filter_by}&sort=${this.state.sort_by}`;
    }
    else if (filter_by!=='ALL'){
      FETCH_URL = `${BASE_URL}?traveled_with=${filter_by}`;
    }
    else {
      FETCH_URL = BASE_URL;
    }

    var myOptions = {
      method: 'GET',
      mode: 'cors',
      cache: 'default'
    };

    fetch(FETCH_URL, myOptions )
    .then(response => response.json())
    .then(json => {
      const reviews = json.data;
      //this.setProps(reviews);
      //his.props.reviews = reviews;
    })
  }

  render(){

    let travel_group = [];
    travel_group = this.state.travel_group !== null ? this.state.travel_group : travel_group;

    return (
      <div>
        <ButtonToolbar className="pull-right">
          <DropdownButton bsStyle="primary" title="Filter by" id="ddlFilterBy"
            onSelect={eventKey=>{this.filter(eventKey)}}>
            <MenuItem key='-1' eventKey="ALL">ALL</MenuItem>
            {
              travel_group.map((type, k) => {
                return (
                  <MenuItem key={k} eventKey={type}>{type}</MenuItem>
                )
              })
            }
          </DropdownButton>
          <DropdownButton bsStyle="primary" title="Sort by" id="ddlSortBy" onSelect={event=>{this.sort(event)}}>
            <MenuItem eventKey="travel_date_asc"><Glyphicon glyph="sort-by-alphabet"></Glyphicon> TRAVEL DATE</MenuItem>
            <MenuItem eventKey="travel_date_desc"><Glyphicon glyph="sort-by-alphabet-alt"></Glyphicon> TRAVEL DATE</MenuItem>
            <MenuItem divider />
            <MenuItem eventKey="review_date_asc"><Glyphicon glyph="sort-by-alphabet"></Glyphicon> REVIEW DATE</MenuItem>
            <MenuItem eventKey="review_date_desc"><Glyphicon glyph="sort-by-alphabet-alt"></Glyphicon> REVIEW DATE</MenuItem>
          </DropdownButton>
        </ButtonToolbar>
        <br/>
      </div>

    )
  }
}

export default Filters;
