import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

   constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
        this.location = [];
   }

  componentDidMount() {
    //this.populateWeatherData();
    }


  static renderForecastsTable(forecasts) {
    console.log(forecasts)
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Description</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temp}</td>
              <td>{forecast.desc}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }


    getValuesFromInput(location) {
        location[0] = document.getElementById('city_input').value;
        location[1] = document.getElementById('country_input').value;
        //console.log(location)
    }

  render() {
    let contents = this.state.loading
      ? <p><em>Waiting for input...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
        <div>
            <h1>Weather forecast for a city of your want!</h1>
            <p>This page presents you the tomorrow weather forecast for a city of your want.</p>
            <p>Please input city name and country code in the formats of "Helsinki" and "FI".</p>
            <form id="form1" onSubmit={this.populateWeatherData.bind(this)}>
                City: <input type="text" id="city_input"/> <br></br>
                <br></br>
                Country code: <input type="text" id="country_input"/>
                <br></br>
                <br></br>
                <button type="submit"onClick={()=>this.getValuesFromInput(this.location)} >Submit</button>
            </form>
            <h2 id="tabelLabel" >{this.location[0]} {this.state.loading ? "" : this.state.forecasts[0].date}</h2>
        {contents}
      </div>
    );
  }

    async populateWeatherData(e) {
      e.preventDefault()
    //const response = await fetch('weatherforecast');
        //const data = await response.json();
        console.log(this.location)
      const response2 = await fetch('weatherforecast/test?city=' + this.location[0]+ '&code=' + this.location[1]);
      const data2 = await response2.json();
      console.log(data2)
    this.setState({ forecasts: data2, loading: false });
  }
}
