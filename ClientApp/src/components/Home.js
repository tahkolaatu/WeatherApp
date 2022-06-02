import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
        <div>
            <h1 style={{ fontStyle: "italic" }}>Welcome,visitor!</h1>
            <hr></hr>
            <p> On this website you can get tomorrow weather forecast for a city of your want. You can find the tool in the Weather-site.</p>
            <img src="weatherpic2.png" alt="Weather" />
      </div>
    );
  }
}
