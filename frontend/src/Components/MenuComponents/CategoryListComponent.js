import {AccordionContext, Button, Card, Col, Container, Row, useAccordionButton} from "react-bootstrap";
import ListGroup from "react-bootstrap/ListGroup";
import Accordion from 'react-bootstrap/Accordion';
import React, {useContext, useEffect, useState} from "react";
import GetMenuCategoriesWithPositions from '../../Services/MenuService.js'
import {useCookies} from "react-cookie";
import jwt_decode from "jwt-decode";
import AccordionHeader from "react-bootstrap/AccordionHeader";

function CategoryListComponent(){
    const [categoryList, setCategoryList] = useState([]);
    const [cookies] = useCookies();
    const decodedHeader = jwt_decode(cookies.jwt);

    useEffect(()=>{
        GetCategoryList(decodedHeader.userId, cookies.jwt)
        console.log(JSON.stringify(categoryList))
    }, [])

    const GetCategoryList = (userId, jwt) =>{
           GetMenuCategoriesWithPositions(userId, jwt).then((x)=>{
               setCategoryList(x.data);
           })
    }

    function ContextAwareToggle({ children, eventKey, callback }) {
        const { activeEventKey } = useContext(AccordionContext);

        const decoratedOnClick = useAccordionButton(
            eventKey,
            () => callback && callback(eventKey),
        );

        const isCurrentEventKey = activeEventKey === eventKey;

        return (
            <button
                type="button"
                style={{ backgroundColor: isCurrentEventKey ? 'pink' : 'lavender' }}
                onClick={decoratedOnClick}
            >
                {children}
            </button>
        );
    }

    return(
            <Accordion defaultActiveKey="0">
                    {categoryList.map((x, index)=>
                        <Card>
                            <Card.Header>
                                <ContextAwareToggle eventKey={index}>{x.category.name}</ContextAwareToggle>
                            </Card.Header>
                            <Accordion.Collapse eventKey={index}>
                                <Card.Body>
                                    <Container>
                                        <Row>
                                            <Col>
                                                {x.menuPosition.map((y,index)=>
                                                    <Button>
                                                        {y.name}
                                                    </Button>
                                                )}
                                            </Col>
                                            <Col>
                                                <Button>
                                                    Add Position
                                                </Button>
                                            </Col>
                                        </Row>
                                    </Container>
                                </Card.Body>
                            </Accordion.Collapse>
                        </Card>)
                    }
                    <Card>
                        <Card.Header>
                            <Button>Add Category</Button>
                        </Card.Header>
                    </Card>
            </Accordion>

    )
}

export default CategoryListComponent;