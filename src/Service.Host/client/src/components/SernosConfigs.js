import React, { Component } from 'react';
import { Grid, Row, Col, Alert } from 'react-bootstrap';
import { Loading } from './common/Loading';

class SernosConfigs extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const { sernosConfigs, loading, errorMessage } = this.props;

        if (loading || !sernosConfigs) {
            return( 
                errorMessage?
                <Grid>
                <Row>
                    <Col sm={8}>
                        <Alert style={{ marginTop: "15px" }} bsStyle="warning" >
                        <strong>{errorMessage}</strong>
                        </Alert >
                    </Col>
                </Row>                
                </Grid>
        :  <Loading />);
        }

        return (
            <div className="container">
                <Grid>
                    {sernosConfigs.map((sc, i) => (<div>a</div>))}
                </Grid>
            </div>
        );
    }
}

export default SernosConfigs;

