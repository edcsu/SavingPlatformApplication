import * as React from 'react';
import { connect } from 'react-redux';
import hero from '../images/savings.jpg';
const Home = () => (
    <div>
        <img width="100%" src={hero} alt="savings" /> 
  </div>
);

export default connect()(Home);
