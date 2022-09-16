import React from 'react';
import CategoryListComponent from "../Components/MenuComponents/CategoryListComponent"
import {Col, Container, Row} from "react-bootstrap";
function Menu() {

    return (
        <Container>
            <Row>
                <Col>
                    <CategoryListComponent/>
                </Col>
                <Col>

                </Col>
            </Row>
        </Container>
    );
}

export default Menu;