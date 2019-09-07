import React, { Component } from 'react';
import { Setting } from './Config/Setting';
import { Collapse, Container, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './ProductList.css';

export class ProductList extends Component {
    static displayName = ProductList.name;

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
        console.log(Setting.rootAPI);
        this.GetProductList();
    }

    renderProducts(products) {
        //console.log(products);
        return (
            <div className="container">
                {products.map(product =>
                    <div className="card product-item" style={{ width: '20rem', display: 'inline-table' }} key={product.id}>
                        <div className="course-item grid clearfix">
                            <div className="grid-inner col-inner">
                                <div>
                                    <div className="title">
                                        <strong> Brand </strong>: {product.brand.name}
                                    </div>
                                    <div className="title">
                                        <strong> Created </strong>: {Setting.formatDate(product.dateCreated)}
                                    </div>
                                    <div className="title">
                                        <strong> Price </strong> : {product.price}
                                    </div>
                                </div>
                                <div className="item-body">
                                    <div className="title">
                                        <strong> Name </strong> : {product.name}
                                    </div>
                                    <div className="title">
                                        <strong> Color </strong> : {product.color}
                                    </div>
                                    <div className="title">
                                        <strong> Description </strong> : {product.description}
                                    </div>
                                    <div className="review-title">
                                        <strong> Review from customer </strong>
                                        {product.review.length > 0 ?
                                            <div className="review-content">
                                                <div className="title">
                                                    <strong> Customer </strong> :  {product.review[0].user.username}
                                                </div>
                                                <div className="title">
                                                    <strong> Rating </strong> :  {product.review[0].rating}
                                                </div>
                                                <div className="title">
                                                    <strong> Comment </strong>  {product.review[0].comment}
                                                </div>
                                            </div>
                                            : null}
                                    </div>
                                    <div className="button-area">
                                        <NavLink tag={Link} className="btn btn-block btn-danger" to={`/adding-review/${product.id}`}>Adding review</NavLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </div>
        );
    }
    GetProductList(id) {
        var param = Setting.GetProductByBrand(id);
        fetch(Setting.rootAPI + param)
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ products: data, loading: false });
            });
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Array.isArray(this.state.products) ? this.renderProducts(this.state.products) : <p><em>Data not found</em></p>;

        return (
            <div>
                <h1>List Product</h1>
                <Container>
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" navbar>
                        <ul className="navbar-nav display-content">
                            <NavItem>
                                <NavLink onClick={() => this.GetProductList(1)} className="btn btn-danger nav-prod text-white">Tech</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink onClick={() => this.GetProductList(2)} className="btn btn-danger nav-prod text-white">Book</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink onClick={() => this.GetProductList(3)} className="btn btn-danger nav-prod text-white">Car</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink onClick={() => this.GetProductList(4)} className="btn btn-danger nav-prod text-white">Food</NavLink>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Container>
                {contents}
            </div>
        );
    }
}