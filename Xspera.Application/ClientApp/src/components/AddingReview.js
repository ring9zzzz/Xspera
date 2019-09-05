import React, { Component } from 'react';
import { Setting } from './Config/Setting';
import './AddingReview.css';

export class AddingReview extends Component {
    static displayName = AddingReview.name;

    constructor(props) {
        super(props);
        this.state = { products: [], loading: true };
        console.log(Setting.rootAPI + Setting.GetProduct);
        //fetch(Setting.rootAPI + Setting.GetProduct)
        //    .then(response => response.json())
        //    .then(data => {
        //        console.log(data);
        //        this.setState({ products: data, loading: false });
        //    });
    }

    static renderProductsTable(products) {
        //console.log(products);
        return (
            <div className="container">
                {products.map(product =>
                    <div className="card product-item" style={{ width: '20rem', display: 'inline-table' }} key={product.id}>
                        <div className="course-item grid clearfix">
                            <div className="grid-inner col-inner">
                                <div className="image">
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
                                    {product.review.length > 0 ?
                                        <div className="review-title">
                                            <strong> Recently review from customer </strong>
                                            <div className="review-content">
                                                <div className="title">
                                                    <strong> Customer </strong> :  {product.review[0].user.username}
                                                </div>
                                                <div className="title">
                                                    <strong> Rating </strong> :  {product.review[0].rating}
                                                </div>
                                                <div className="title">
                                                    <strong> Comment </strong> :  {product.review[0].comment}
                                                </div>
                                            </div>
                                        </div> : null}
                                    <div className="button-area">
                                        <button className="btn btn-block btn-danger" onClick={this.redirectToAddReview}>Adding review</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </div>
        );
    }
    redirectToAddReview() {
        this.props.history.push('/adding-review');
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.state.products.length === 0 ? <p><em>Data not found</em></p> : AddingReview.renderProductsTable(this.state.products);

        return (
            <div>
                <h1>List Product</h1>
                {contents}
            </div>
        );
    }
}