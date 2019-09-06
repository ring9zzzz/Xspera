import React, { Component } from 'react';
import { Setting } from './Config/Setting';
import './AddingReview.css';

export class AddingReview extends Component {
    static displayName = AddingReview.name;

    constructor(props) {
        super(props);
        this.state = {
            product: null, loading: true, message: null, review:
            {
                email: "",
                rating: 0,
                comment: ""
            }
        };
        console.log(Setting.rootAPI + Setting.GetProduct(this.props.match.params.id));
        fetch(Setting.rootAPI + Setting.GetProduct(this.props.match.params.id))
            .then(response => response.json())
            .then(data => {
                console.log(data);
                this.setState({ product: data, loading: false });
            });
    }

    renderProduct(state) {
        return (
            <div className="container prod-detail">
                {state.product.map(product =>
                    <div className="card product-item" style={{ width: '40rem', display: 'inline-table', height: '500px' }} key={product.id}>
                        <div className="course-item grid clearfix">
                            <div className="grid-inner col-inner">
                                <div>
                                    <div className="title">
                                        <strong> Created </strong>: {Setting.formatDate(product.dateCreated)}
                                    </div>
                                    <div className="title">
                                        <strong> Price </strong> : {product.price}
                                    </div>
                                    <div className="title">
                                        <strong> Name </strong> : {product.name}
                                    </div>
                                </div>
                                <div className="item-body">
                                    <div className="adding-title">
                                        <strong> Review form </strong>
                                        <div className="review-content">
                                            <div className="title">
                                                <strong> Email </strong> :  <input type="text" onChange={this.handleEmailChange.bind(this)} />
                                            </div>
                                            <div className="title rating">
                                                <strong> Rating </strong> :
                                                <label className="container">One
                                                  <input type="radio" name="radio" value="1" onChange={this.handleRatingChange.bind(this)} />
                                                    <span className="checkmark"></span>
                                                </label>
                                                <label className="container">Two
                                                  <input type="radio" name="radio" value="2" onChange={this.handleRatingChange.bind(this)} />
                                                    <span className="checkmark"></span>
                                                </label>
                                                <label className="container">Three
                                                  <input type="radio" name="radio" value="3" onChange={this.handleRatingChange.bind(this)} />
                                                    <span className="checkmark"></span>
                                                </label>
                                                <label className="container">Four
                                                  <input type="radio" name="radio" value="4" onChange={this.handleRatingChange.bind(this)} />
                                                    <span className="checkmark"></span>
                                                </label>
                                                <label className="container">Five
                                                  <input type="radio" name="radio" value="5" onChange={this.handleRatingChange.bind(this)} />
                                                    <span className="checkmark"></span>
                                                </label>
                                            </div>
                                            <div className="title">
                                                <strong> Comment </strong> :  <textarea onChange={this.handleCommentChange.bind(this)} />
                                            </div>
                                            {this.state.message !== null ? <label className="api-message">{this.state.message}</label> : null}
                                        </div>
                                    </div>
                                    <div className="button-area">
                                        <button className="btn btn-block btn-danger" onClick={this.AddingReviewData.bind(this)}>Adding review</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </div>
        );
    }
    handleEmailChange(e) {
        //console.log(e);
        var obj = {}
        obj['email'] = e.target.value
        this.setState({ review: { ...this.state.review, ...obj } })
    }
    handleRatingChange(e) {
        console.log(e);
        var obj = {}
        obj['rating'] = e.target.value
        this.setState({ review: { ...this.state.review, ...obj } })
    }
    handleCommentChange(e) {
        console.log(e);
        var obj = {}
        obj['comment'] = e.target.value
        this.setState({ review: { ...this.state.review, ...obj } })
    }
    AddingReviewData() {
        if (this.state.review.email === "" ||!/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[A-Za-z]+$/.test(this.state.review.email)) {
            this.setState({ message: "The email incorrect format." })
        }
        if (this.state.review.rating == 0) {
            this.setState({ message: "Please vote the rating before submit." })
        }
   
        let formData =
        {
            productId: this.state.product[0].id,
            userid: 3, //set default
            email: this.state.review.email,
            rating: this.state.review.rating,
            comment: this.state.review.comment,
        }

        console.log(JSON.stringify(formData));
        fetch(Setting.rootAPI + Setting.AddReview, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        }).then(response => response.json())
            .then(data => {
                //this.context.router.history.push(`/product-list`)
                this.setState({ message: data })
            });
    }
    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.state.product.length === 0 ? <p><em>Data not found</em></p> : this.renderProduct(this.state);

        return (
            <div>
                <h1>Adding review</h1>
                {contents}
            </div>
        );
    }
}