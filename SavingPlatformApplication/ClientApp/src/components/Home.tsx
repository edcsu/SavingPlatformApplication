import * as React from 'react';
import { connect } from 'react-redux';
import { Card, CardTitle, CardText, CardImg, CardImgOverlay } from 'reactstrap';
import hero from '../images/savings.jpg';

const Home = () => (
    <div>
        <Card inverse>
            <CardImg width="100%" src={hero} alt="savings"/>
            <CardImgOverlay>
                <CardTitle className="text-primary text-center" tag="h1">Savings Platform Application</CardTitle>
                <CardText className="text-primary text-center">Save when you can with us.</CardText>
            </CardImgOverlay>
        </Card>
  </div>
);

export default connect()(Home);
